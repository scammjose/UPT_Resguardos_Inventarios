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
                    NombreCompleto TEXT NOT NULL,
                    Puesto TEXT
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
