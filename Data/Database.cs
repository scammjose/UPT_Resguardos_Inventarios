using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace AppEscritorioUPT.Data
{
    public static class Database
    {
        private static readonly string _dbFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private static readonly string _dbPath = Path.Combine(_dbFolder, "app_esc_uptecamac.db");
        private static readonly string _connectionString = $"Data Source={_dbPath}";

        /// <summary>
        /// Crea la carpeta y la base de datos si no existen,
        /// y genera las tablas principales.
        /// </summary>
        public static void EnsureCreated()
        {
            // Crear carpeta Data si no existe
            if (!Directory.Exists(_dbFolder))
            {
                Directory.CreateDirectory(_dbFolder);
            }

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            // Activar llaves foráneas en SQLite
            using (var pragma = connection.CreateCommand())
            {
                pragma.CommandText = "PRAGMA foreign_keys = ON;";
                pragma.ExecuteNonQuery();
            }

            // Crear tablas en orden de dependencias

            // 1. Áreas
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Areas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Descripcion TEXT,
                    NomenclaturaInventario TEXT NOT NULL
                );
            ");

            // 2. Administrativos (tienen FK a Areas)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Administrativos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NombreCompleto TEXT NOT NULL,
                    Puesto TEXT,
                    AreaId INTEGER NOT NULL,
                    FOREIGN KEY (AreaId) REFERENCES Areas (Id)
                );
            ");

            // 3. Tipos de equipo
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS TiposEquipos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL
                );
            ");

            // 4. Equipos (FK a TipoEquipo y Administrativo)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Equipos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TipoEquipoId INTEGER NOT NULL,
                    

                    Marca TEXT,
                    Modelo TEXT,
                    NumeroSerie TEXT,
                    DireccionIp TEXT,

                    MemoriaRam TEXT,
                    Procesador TEXT,
                    DiscoDuro TEXT,
                    TieneLectorCd INTEGER, -- NULL/0/1

                    MarcaMonitor TEXT,
                    ModeloMonitor TEXT,
                    SerieMonitor TEXT,

                    MarcaTeclado TEXT,
                    ModeloTeclado TEXT,
                    SerieTeclado TEXT,

                    MarcaMouse TEXT,
                    ModeloMouse TEXT,
                    SerieMouse TEXT,

                    MarcaWebcam TEXT,
                    ModeloWebcam TEXT,
                    SerieWebcam TEXT,

                    TipoImpresion TEXT,

                    MacAddress TEXT,
                    NumeroExtension TEXT,
                    PrivilegiosLlamadas TEXT,

                    EsPcEscritorio INTEGER NOT NULL DEFAULT 0,
                    EsAllInOne INTEGER NOT NULL DEFAULT 0,

                    FOREIGN KEY (TipoEquipoId) REFERENCES TiposEquipos (Id)
                );
            ");

            // 5. Responsables de Sistemas
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS ResponsablesSistemas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    AdministrativoId INTEGER NOT NULL,
                    FOREIGN KEY (AdministrativoId) REFERENCES Administrativos (Id)
                );
            ");

            // 6. Resguardos (relación Equipo - Administrativo - Responsable Sistemas)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Resguardos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    EquipoId INTEGER NOT NULL,
                    AdministrativoId INTEGER NOT NULL,
                    ResponsableSistemasId INTEGER NOT NULL,
                    CodigoInventario TEXT NOT NULL,
                    FechaResguardo TEXT,
                    Notas TEXT,
                    FOREIGN KEY (EquipoId) REFERENCES Equipos (Id),
                    FOREIGN KEY (AdministrativoId) REFERENCES Administrativos (Id),
                    FOREIGN KEY (ResponsableSistemasId) REFERENCES ResponsablesSistemas (Id)
                );
            ");

            // 7. Mantenimientos (Historial de revisiones)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Mantenimientos_administrativos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    EquipoId INTEGER NOT NULL,
                    AdministrativoId INTEGER NOT NULL,
                    ResponsableSistemasId INTEGER NOT NULL, -- El técnico que hace el mantenimiento
                    Fecha TEXT NOT NULL,
                    Tipo TEXT NOT NULL, -- 'Programado' o 'Correctivo'
                    Observaciones TEXT,
                    CreadoAutomaticamente INTEGER DEFAULT 1, -- Para saber si fue por el botón masivo
                    FOREIGN KEY (EquipoId) REFERENCES Equipos (Id),
                    FOREIGN KEY (AdministrativoId) REFERENCES Administrativos (Id),
                    FOREIGN KEY (ResponsableSistemasId) REFERENCES ResponsablesSistemas (Id)
                );
            ");

            // 8. Edificios (Catálogo de espacios físicos)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Edificios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Ubicacion TEXT,
                    CantidadAulas INTEGER NOT NULL DEFAULT 0,
                    ResponsableSistemasId INTEGER NOT NULL,
                    FOREIGN KEY (ResponsableSistemasId) REFERENCES ResponsablesSistemas (Id)
                );
            ");

            // 9. Mantenimientos de Aulas (Historial de checklists por edificio)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Mantenimientos_Aulas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    EdificioId INTEGER NOT NULL,
                    FechaEjecucion TEXT NOT NULL,
                    TipoMantenimiento TEXT NOT NULL, -- 'Predictivo' o 'Correctivo'
                    Observaciones TEXT,
                    FOREIGN KEY (EdificioId) REFERENCES Edificios (Id)
                );
            ");

            // 10. Catálogo de Tipos de Mantenimiento
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS TiposMantenimiento (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL UNIQUE
                );
            ");

            // 10.1 Insertamos los valores por defecto si la tabla está vacía
            ExecuteNonQuery(connection, @"
                INSERT INTO TiposMantenimiento (Nombre)
                SELECT 'PREDICTIVO'
                WHERE NOT EXISTS (SELECT 1 FROM TiposMantenimiento WHERE Nombre = 'PREDICTIVO');

                INSERT INTO TiposMantenimiento (Nombre)
                SELECT 'CORRECTIVO'
                WHERE NOT EXISTS (SELECT 1 FROM TiposMantenimiento WHERE Nombre = 'CORRECTIVO');
            ");

            // 11. Tabla de Laboratorios
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Laboratorios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    EdificioId INTEGER NOT NULL,
                    AreaId INTEGER NOT NULL,
                    ResponsableSistemasId INTEGER NOT NULL,
                    CantidadEquipos INTEGER NOT NULL DEFAULT 0,
                    FOREIGN KEY(EdificioId) REFERENCES Edificios(Id),
                    FOREIGN KEY(AreaId) REFERENCES Areas(Id),
                    FOREIGN KEY(ResponsableSistemasId) REFERENCES ResponsablesSistemas(Id)
                );
            ");

            //  12. Tabla de Mantenimientos de Laboratorios
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Mantenimientos_Laboratorios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    LaboratorioId INTEGER NOT NULL,
                    FechaEjecucion TEXT NOT NULL,
                    TipoMantenimientoId INTEGER NOT NULL,
                    Observaciones TEXT,
                    FOREIGN KEY(LaboratorioId) REFERENCES Laboratorios(Id),
                    FOREIGN KEY(TipoMantenimientoId) REFERENCES TiposMantenimiento(Id)
                );
            ");

            // 13. Historial de Resguardos (Rastreo de reasignaciones y bajas)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Historico_Resguardos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    EquipoId INTEGER NOT NULL,
                    AdministrativoId INTEGER NOT NULL, -- La persona que TENÍA el equipo
                    ResponsableSistemasId INTEGER NOT NULL, -- El técnico que recibió el equipo
                    CodigoInventario TEXT NOT NULL,
                    FechaInicio TEXT NOT NULL, -- Cuándo se le asignó originalmente
                    FechaFin TEXT NOT NULL, -- Cuándo se le quitó o reasignó
                    Motivo TEXT NOT NULL, -- Ej: 'Reasignación', 'Baja por daño', 'Devolución a inventario'
                    Notas TEXT,
                    FOREIGN KEY (EquipoId) REFERENCES Equipos (Id),
                    FOREIGN KEY (AdministrativoId) REFERENCES Administrativos (Id),
                    FOREIGN KEY (ResponsableSistemasId) REFERENCES ResponsablesSistemas (Id)
                );
            ");

            // 14. Catálogo de Tipos de Uso
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS TiposUso (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL UNIQUE
                );
            ");

            // 14.1 Insertamos los valores por defecto si no existen
            ExecuteNonQuery(connection, @"
                INSERT INTO TiposUso (Nombre)
                SELECT 'USO ADMINISTRATIVO'
                WHERE NOT EXISTS (SELECT 1 FROM TiposUso WHERE Nombre = 'USO ADMINISTRATIVO');

                INSERT INTO TiposUso (Nombre)
                SELECT 'USO ESTUDIANTIL / KIOSCO'
                WHERE NOT EXISTS (SELECT 1 FROM TiposUso WHERE Nombre = 'USO ESTUDIANTIL / KIOSCO');

                INSERT INTO TiposUso (Nombre)
                SELECT 'LABORATORIO GENERAL'
                WHERE NOT EXISTS (SELECT 1 FROM TiposUso WHERE Nombre = 'LABORATORIO GENERAL');
            ");

            // 15. MIGRACIÓN: Agregar la columna TipoUsoId a Resguardos sin perder datos
            bool columnaExiste = false;
            using (var cmdInfo = connection.CreateCommand())
            {
                // PRAGMA table_info nos da la lista de columnas de una tabla
                cmdInfo.CommandText = "PRAGMA table_info(Resguardos);";
                using var reader = cmdInfo.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["name"].ToString() == "TipoUsoId")
                    {
                        columnaExiste = true;
                        break;
                    }
                }
            }

            // 16. Catálogo de Consumibles (El Almacén)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Consumibles (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Modelo TEXT NOT NULL,
                    Tipo TEXT NOT NULL,
                    StockActual INTEGER NOT NULL DEFAULT 0,
                    StockMinimo INTEGER NOT NULL DEFAULT 0
                );
            ");

            // 17. Compatibilidad (Tabla ternaria Equipos - Consumibles)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS EquiposConsumibles (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    EquipoId INTEGER NOT NULL,
                    ConsumibleId INTEGER NOT NULL,
                    FOREIGN KEY (EquipoId) REFERENCES Equipos (Id),
                    FOREIGN KEY (ConsumibleId) REFERENCES Consumibles (Id)
                );
            ");

            // 18. Historial de Entregas (Instalación de tóners/tintas)
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS EntregasConsumibles (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ConsumibleId INTEGER NOT NULL,
                    EquipoId INTEGER NOT NULL,
                    AdministrativoId INTEGER NOT NULL,
                    ResponsableSistemasId INTEGER NOT NULL,
                    FechaEntrega TEXT NOT NULL,
                    Cantidad INTEGER NOT NULL DEFAULT 1,
                    FOREIGN KEY (ConsumibleId) REFERENCES Consumibles (Id),
                    FOREIGN KEY (EquipoId) REFERENCES Equipos (Id),
                    FOREIGN KEY (AdministrativoId) REFERENCES Administrativos (Id),
                    FOREIGN KEY (ResponsableSistemasId) REFERENCES ResponsablesSistemas (Id)
                );
            ");

            // 19. MIGRACIÓN: Agregar la columna Color a Consumibles
            bool columnaColorExiste = false;
            using (var cmdInfo = connection.CreateCommand())
            {
                cmdInfo.CommandText = "PRAGMA table_info(Consumibles);";
                using var reader = cmdInfo.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["name"].ToString() == "Color") { columnaColorExiste = true; break; }
                }
            }

            if (!columnaColorExiste)
            {
                // Agregamos la columna y le ponemos "N/A" a lo que ya existiera
                ExecuteNonQuery(connection, "ALTER TABLE Consumibles ADD COLUMN Color TEXT NOT NULL DEFAULT 'N/A';");
            }

            // Si la columna no existe (porque es una versión vieja de la base de datos), la agregamos
            if (!columnaExiste)
            {
                // DEFAULT 1 hace que todas tus computadoras actuales se queden como 'USO ADMINISTRATIVO' automáticamente
                ExecuteNonQuery(connection, "ALTER TABLE Resguardos ADD COLUMN TipoUsoId INTEGER NOT NULL DEFAULT 1;");
            }

            // 20. MIGRACIÓN: Agregar columnas para Resguardos Colectivos (Lotes)
            bool columnaFolioLoteExiste = false;
            using (var cmdInfo = connection.CreateCommand())
            {
                cmdInfo.CommandText = "PRAGMA table_info(Resguardos);";
                using var reader = cmdInfo.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["name"].ToString() == "FolioLote") { columnaFolioLoteExiste = true; break; }
                }
            }

            if (!columnaFolioLoteExiste)
            {
                // Agregamos un identificador de Lote y un Tipo ('INDIVIDUAL' o 'COLECTIVO')
                ExecuteNonQuery(connection, "ALTER TABLE Resguardos ADD COLUMN FolioLote TEXT;");
                ExecuteNonQuery(connection, "ALTER TABLE Resguardos ADD COLUMN TipoResguardo TEXT NOT NULL DEFAULT 'INDIVIDUAL';");
            }
        }

        /// <summary>
        /// Devuelve una conexión abierta.
        /// Recuerda usar 'using' al consumirla.
        /// </summary>
        public static SqliteConnection GetOpenConnection()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using (var pragma = connection.CreateCommand())
            {
                pragma.CommandText = "PRAGMA foreign_keys = ON;";
                pragma.ExecuteNonQuery();
            }

            return connection;
        }

        private static void ExecuteNonQuery(SqliteConnection connection, string sql)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

    }
}
