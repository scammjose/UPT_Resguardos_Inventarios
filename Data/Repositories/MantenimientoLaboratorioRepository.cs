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
    public class MantenimientoLaboratorioRepository : IMantenimientoLaboratorioRepository
    {
        private readonly string _baseSelect = @"
            SELECT 
                m.Id, m.LaboratorioId, m.FechaEjecucion, m.TipoMantenimientoId, m.Observaciones,
                l.Nombre AS LaboratorioNombre,
                t.Nombre AS TipoMantenimientoNombre,
                adm.NombreCompleto AS ResponsableSistemasNombre
            FROM Mantenimientos_Laboratorios m
            INNER JOIN Laboratorios l ON m.LaboratorioId = l.Id
            INNER JOIN TiposMantenimiento t ON m.TipoMantenimientoId = t.Id
            INNER JOIN ResponsablesSistemas r ON l.ResponsableSistemasId = r.Id
            INNER JOIN Administrativos adm ON r.AdministrativoId = adm.Id";

        public IEnumerable<MantenimientoLaboratorio> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " ORDER BY m.FechaEjecucion DESC;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<MantenimientoLaboratorio>();
            while (reader.Read()) lista.Add(MapToEntity(reader));
            return lista;
        }

        public IEnumerable<MantenimientoLaboratorio> GetByLaboratorio(int laboratorioId)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " WHERE m.LaboratorioId = @labId ORDER BY m.FechaEjecucion DESC;";
            cmd.Parameters.AddWithValue("@labId", laboratorioId);

            using var reader = cmd.ExecuteReader();
            var lista = new List<MantenimientoLaboratorio>();
            while (reader.Read()) lista.Add(MapToEntity(reader));
            return lista;
        }

        public MantenimientoLaboratorio? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " WHERE m.Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read()) return MapToEntity(reader);
            return null;
        }

        public void Add(MantenimientoLaboratorio m)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Mantenimientos_Laboratorios (LaboratorioId, FechaEjecucion, TipoMantenimientoId, Observaciones)
                VALUES (@labId, @fecha, @tipoId, @obs);";

            AsignarParametros(cmd, m);
            cmd.ExecuteNonQuery();
        }

        public void Update(MantenimientoLaboratorio m)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Mantenimientos_Laboratorios 
                SET LaboratorioId = @labId, FechaEjecucion = @fecha, 
                    TipoMantenimientoId = @tipoId, Observaciones = @obs
                WHERE Id = @id;";

            cmd.Parameters.AddWithValue("@id", m.Id);
            AsignarParametros(cmd, m);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Mantenimientos_Laboratorios WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private void AsignarParametros(SqliteCommand cmd, MantenimientoLaboratorio m)
        {
            cmd.Parameters.AddWithValue("@labId", m.LaboratorioId);
            cmd.Parameters.AddWithValue("@fecha", m.FechaEjecucion);
            cmd.Parameters.AddWithValue("@tipoId", m.TipoMantenimientoId);
            cmd.Parameters.AddWithValue("@obs", string.IsNullOrWhiteSpace(m.Observaciones) ? (object)DBNull.Value : m.Observaciones);
        }

        private MantenimientoLaboratorio MapToEntity(SqliteDataReader reader)
        {
            return new MantenimientoLaboratorio
            {
                Id = reader.GetInt32(0),
                LaboratorioId = reader.GetInt32(1),
                FechaEjecucion = reader.GetString(2),
                TipoMantenimientoId = reader.GetInt32(3),
                Observaciones = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                LaboratorioNombre = reader.GetString(5),
                TipoMantenimientoNombre = reader.GetString(6),
                ResponsableSistemasNombre = reader.GetString(7)
            };
        }
    }
}
