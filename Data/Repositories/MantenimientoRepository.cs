using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class MantenimientoRepository : IMantenimientoRepository
    {
        public int Add(Mantenimiento mantenimiento)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Mantenimientos_administrativos 
                (EquipoId, AdministrativoId, ResponsableSistemasId, Fecha, Tipo, Observaciones)
                VALUES 
                (@equipoId, @adminId, @respId, @fecha, @tipo, @obs);
                SELECT last_insert_rowid();";

            cmd.Parameters.AddWithValue("@equipoId", mantenimiento.EquipoId);
            cmd.Parameters.AddWithValue("@adminId", mantenimiento.AdministrativoId);
            cmd.Parameters.AddWithValue("@respId", mantenimiento.ResponsableSistemasId);
            cmd.Parameters.AddWithValue("@fecha", mantenimiento.Fecha);
            cmd.Parameters.AddWithValue("@tipo", mantenimiento.Tipo);
            // Manejo de nulos para observaciones
            cmd.Parameters.AddWithValue("@obs", (object?)mantenimiento.Observaciones ?? DBNull.Value);

            // Retornamos el ID generado
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool ExisteMantenimiento(int equipoId, string fecha)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            // Verificamos si ya existe un registro para ese equipo en esa fecha
            cmd.CommandText = @"
                SELECT COUNT(1) 
                FROM Mantenimientos_administrativos 
                WHERE EquipoId = @equipoId AND Fecha = @fecha";

            cmd.Parameters.AddWithValue("@equipoId", equipoId);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            long count = (long?)cmd.ExecuteScalar() ?? 0;
            return count > 0;
        }

        public IEnumerable<Mantenimiento> GetByAdministrativoId(int administrativoId)
        {
            var lista = new List<Mantenimiento>();

            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, EquipoId, AdministrativoId, ResponsableSistemasId, Fecha, Tipo, Observaciones
                FROM Mantenimientos_administrativos
                WHERE AdministrativoId = @adminId
                ORDER BY Fecha DESC"; // Ordenado por fecha descendente (lo más reciente primero)

            cmd.Parameters.AddWithValue("@adminId", administrativoId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(MapFromReader(reader));
            }

            return lista;
        }

        public IEnumerable<Mantenimiento> GetAll()
        {
            var lista = new List<Mantenimiento>();

            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, EquipoId, AdministrativoId, ResponsableSistemasId, Fecha, Tipo, Observaciones
                FROM Mantenimientos_administrativos
                ORDER BY Fecha DESC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(MapFromReader(reader));
            }

            return lista;
        }

        public Mantenimiento? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, EquipoId, AdministrativoId, ResponsableSistemasId, Fecha, Tipo, Observaciones
                FROM Mantenimientos_administrativos
                WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapFromReader(reader);
            }

            return null;
        }

        public void Update(Mantenimiento mantenimiento)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Mantenimientos_administrativos
                SET EquipoId = @equipoId,
                    AdministrativoId = @adminId,
                    ResponsableSistemasId = @respId,
                    Fecha = @fecha,
                    Tipo = @tipo,
                    Observaciones = @obs
                WHERE Id = @id";

            cmd.Parameters.AddWithValue("@equipoId", mantenimiento.EquipoId);
            cmd.Parameters.AddWithValue("@adminId", mantenimiento.AdministrativoId);
            cmd.Parameters.AddWithValue("@respId", mantenimiento.ResponsableSistemasId);
            cmd.Parameters.AddWithValue("@fecha", mantenimiento.Fecha);
            cmd.Parameters.AddWithValue("@tipo", mantenimiento.Tipo);
            cmd.Parameters.AddWithValue("@obs", (object?)mantenimiento.Observaciones ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", mantenimiento.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Mantenimientos_administrativos WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        // Método auxiliar para mapear de SqliteDataReader a Objeto
        private Mantenimiento MapFromReader(SqliteDataReader reader)
        {
            return new Mantenimiento
            {
                Id = reader.GetInt32(0),
                EquipoId = reader.GetInt32(1),
                AdministrativoId = reader.GetInt32(2),
                ResponsableSistemasId = reader.GetInt32(3),
                Fecha = reader.GetString(4),
                Tipo = reader.GetString(5),
                Observaciones = reader.IsDBNull(6) ? string.Empty : reader.GetString(6)
            };
        }

        public IEnumerable<MantenimientoDetalleDto> GetDetalladoPorFecha(string fecha)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT 
                    m.Id, 
                    m.Fecha, 
                    m.Tipo, 
                    m.Observaciones,
                    -- Concatenamos datos del equipo
                    e.Marca || ' ' || e.Modelo || ' (' || ifnull(e.NumeroSerie,'S/N') || ')' as EquipoInfo,
                    -- Nombre del administrativo dueño
                    a.NombreCompleto as AdminNombre,
                    -- Nombre del técnico (Join doble: Mantenimiento -> RespSistemas -> Administrativo)
                    a_tec.NombreCompleto as TecnicoNombre
                FROM Mantenimientos_administrativos m
                INNER JOIN Equipos e ON m.EquipoId = e.Id
                INNER JOIN Administrativos a ON m.AdministrativoId = a.Id
                INNER JOIN ResponsablesSistemas rs ON m.ResponsableSistemasId = rs.Id
                INNER JOIN Administrativos a_tec ON rs.AdministrativoId = a_tec.Id
                WHERE m.Fecha = @fecha
                ORDER BY m.Id DESC;
            ";

            cmd.Parameters.AddWithValue("@fecha", fecha);

            using var reader = cmd.ExecuteReader();
            var lista = new List<MantenimientoDetalleDto>();

            while (reader.Read())
            {
                lista.Add(new MantenimientoDetalleDto
                {
                    Id = reader.GetInt32(0),
                    Fecha = reader.GetString(1),
                    Tipo = reader.GetString(2),
                    Observaciones = reader.IsDBNull(3) ? "" : reader.GetString(3),

                    // CORRECCIÓN: Usar los nombres exactos del DTO
                    EquipoInfo = reader.GetString(4),     // Antes decía Equipo
                    AdminNombre = reader.GetString(5),    // Antes decía Administrativo
                    TecnicoNombre = reader.GetString(6)   // Antes decía Responsable
                });
            }

            return lista;
        }

        public IEnumerable<MantenimientoDetalleDto> GetByAdministrativoYFecha(int administrativoId, string fecha)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            // Reutilizamos la misma lógica de JOINS que usamos para el historial general
            cmd.CommandText = @"
        SELECT 
            m.Id, m.Fecha, m.Tipo, m.Observaciones,
            e.Marca || ' ' || e.Modelo || ' (' || ifnull(e.NumeroSerie,'S/N') || ')' as EquipoInfo,
            a.NombreCompleto as AdminNombre,
            a_tec.NombreCompleto as TecnicoNombre,
            -- Necesitamos datos extra para el reporte (que no estaban en el DTO original)
            te.Nombre as TipoEquipoNombre,
            r.CodigoInventario,
            a.AreaId, -- Solo el ID, luego buscamos el nombre si hace falta o hacemos join con Areas
            ar.Nombre as AreaNombre,
            ifnull(e.NumeroSerie, '') as Serie
        FROM Mantenimientos_administrativos m
        INNER JOIN Equipos e ON m.EquipoId = e.Id
        INNER JOIN TiposEquipos te ON e.TipoEquipoId = te.Id
        INNER JOIN Administrativos a ON m.AdministrativoId = a.Id
        INNER JOIN Areas ar ON a.AreaId = ar.Id
        INNER JOIN ResponsablesSistemas rs ON m.ResponsableSistemasId = rs.Id
        INNER JOIN Administrativos a_tec ON rs.AdministrativoId = a_tec.Id
        -- Join con Resguardos para sacar el Código de Inventario (asumiendo que sigue activo)
        LEFT JOIN Resguardos r ON r.EquipoId = e.Id AND r.AdministrativoId = m.AdministrativoId
        
        WHERE m.AdministrativoId = @adminId AND m.Fecha = @fecha";

            cmd.Parameters.AddWithValue("@adminId", administrativoId);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            using var reader = cmd.ExecuteReader();
            var lista = new List<MantenimientoDetalleDto>();

            while (reader.Read())
            {
                // Nota: Tendrás que extender tu DTO 'MantenimientoDetalleDto' 
                // con estas propiedades extra si quieres usarlas en el reporte,
                // o crear una clase dedicada 'MantenimientoReporteDto'.
                // Por simplicidad, aquí asumo que modificas el DTO existente o usas variables locales.

                var dto = new MantenimientoDetalleDto
                {
                    Id = reader.GetInt32(0),
                    Fecha = reader.GetString(1),
                    Tipo = reader.GetString(2),
                    Observaciones = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    EquipoInfo = reader.GetString(4),
                    AdminNombre = reader.GetString(5),
                    TecnicoNombre = reader.GetString(6),

                    // --- AQUÍ ESTABA EL ERROR: FALTABA LEER ESTOS CAMPOS ---
                    TipoEquipoNombre = reader.IsDBNull(7) ? "" : reader.GetString(7),   // <--- Esto arreglará el IF
                    CodigoInventario = reader.IsDBNull(8) ? "" : reader.GetString(8),   // <--- Esto llenará CODIGO INV
                                                                                        // El índice 9 es AreaId, no lo usamos en el reporte visual
                    AreaNombre = reader.IsDBNull(10) ? "" : reader.GetString(10),       // <--- Esto llenará ÁREA
                    Serie = reader.IsDBNull(11) ? "" : reader.GetString(11)
                };

                // Propiedades extendidas (Añádelas a tu clase MantenimientoDetalleDto si no existen)
                // dto.TipoEquipoNombre = reader.GetString(7);
                // dto.CodigoInventario = reader.IsDBNull(8) ? "S/N" : reader.GetString(8);
                // dto.AreaNombre = reader.GetString(10);
                // dto.Serie = reader.GetString(11);

                lista.Add(dto);
            }

            return lista;
        }

        public IEnumerable<MantenimientoDetalleDto> GetByAreaYFecha(int areaId, string fecha)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
            SELECT 
                m.Id, m.Fecha, m.Tipo, m.Observaciones,
                e.Marca || ' ' || e.Modelo || ' (' || ifnull(e.NumeroSerie,'S/N') || ')' as EquipoInfo,
                a.NombreCompleto as AdminNombre,
                a_tec.NombreCompleto as TecnicoNombre,
                te.Nombre as TipoEquipoNombre,
                ifnull(r.CodigoInventario, 'S/N') as CodigoInventario,
                ar.Nombre as AreaNombre,
                ifnull(e.NumeroSerie, '') as Serie
            FROM Mantenimientos_administrativos m
            INNER JOIN Equipos e ON m.EquipoId = e.Id
            INNER JOIN TiposEquipos te ON e.TipoEquipoId = te.Id
            INNER JOIN Administrativos a ON m.AdministrativoId = a.Id
            INNER JOIN Areas ar ON a.AreaId = ar.Id
            INNER JOIN ResponsablesSistemas rs ON m.ResponsableSistemasId = rs.Id
            INNER JOIN Administrativos a_tec ON rs.AdministrativoId = a_tec.Id
            LEFT JOIN Resguardos r ON r.EquipoId = e.Id AND r.AdministrativoId = m.AdministrativoId
        
            WHERE a.AreaId = @areaId AND m.Fecha = @fecha
            ORDER BY a.NombreCompleto, te.Nombre"; // Ordenado por persona y luego por equipo

            cmd.Parameters.AddWithValue("@areaId", areaId);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            using var reader = cmd.ExecuteReader();
            var lista = new List<MantenimientoDetalleDto>();

            while (reader.Read())
            {
                // Reutilizamos el DTO que ya corregimos antes
                var dto = new MantenimientoDetalleDto
                {
                    Id = reader.GetInt32(0),
                    Fecha = reader.GetString(1),
                    Tipo = reader.GetString(2),
                    Observaciones = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    EquipoInfo = reader.GetString(4),
                    AdminNombre = reader.GetString(5),
                    TecnicoNombre = reader.GetString(6),
                    TipoEquipoNombre = reader.IsDBNull(7) ? "" : reader.GetString(7),
                    CodigoInventario = reader.IsDBNull(8) ? "" : reader.GetString(8),
                    AreaNombre = reader.IsDBNull(9) ? "" : reader.GetString(9),
                    Serie = reader.IsDBNull(10) ? "" : reader.GetString(10)
                };
                lista.Add(dto);
            }

            return lista;
        }

    }
}
