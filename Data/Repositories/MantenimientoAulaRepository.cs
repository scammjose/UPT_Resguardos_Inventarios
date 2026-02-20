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
    public class MantenimientoAulaRepository : IMantenimientoAulaRepository
    {
        private readonly string _baseSelect = @"
            SELECT 
                m.Id, 
                m.EdificioId, 
                m.FechaEjecucion, 
                m.TipoMantenimiento, 
                m.Observaciones,
                e.Nombre AS EdificioNombre
            FROM Mantenimientos_Aulas m
            INNER JOIN Edificios e ON m.EdificioId = e.Id";

        public IEnumerable<MantenimientoAula> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " ORDER BY m.FechaEjecucion DESC;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<MantenimientoAula>();
            while (reader.Read()) lista.Add(MapToEntity(reader));
            return lista;
        }

        public IEnumerable<MantenimientoAula> GetByEdificio(int edificioId)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " WHERE m.EdificioId = @edificioId ORDER BY m.FechaEjecucion DESC;";
            cmd.Parameters.AddWithValue("@edificioId", edificioId);

            using var reader = cmd.ExecuteReader();
            var lista = new List<MantenimientoAula>();
            while (reader.Read()) lista.Add(MapToEntity(reader));
            return lista;
        }

        public MantenimientoAula? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " WHERE m.Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read()) return MapToEntity(reader);
            return null;
        }

        public void Add(MantenimientoAula mantenimiento)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Mantenimientos_Aulas (EdificioId, FechaEjecucion, TipoMantenimiento, Observaciones)
                VALUES (@edificioId, @fecha, @tipo, @obs);";

            AsignarParametros(cmd, mantenimiento);
            cmd.ExecuteNonQuery();
        }

        public void Update(MantenimientoAula mantenimiento)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Mantenimientos_Aulas 
                SET EdificioId = @edificioId, 
                    FechaEjecucion = @fecha, 
                    TipoMantenimiento = @tipo, 
                    Observaciones = @obs
                WHERE Id = @id;";

            cmd.Parameters.AddWithValue("@id", mantenimiento.Id);
            AsignarParametros(cmd, mantenimiento);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Mantenimientos_Aulas WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        // --- Helpers internos ---
        private void AsignarParametros(SqliteCommand cmd, MantenimientoAula m)
        {
            cmd.Parameters.AddWithValue("@edificioId", m.EdificioId);
            cmd.Parameters.AddWithValue("@fecha", m.FechaEjecucion);
            cmd.Parameters.AddWithValue("@tipo", m.TipoMantenimiento);
            cmd.Parameters.AddWithValue("@obs", string.IsNullOrWhiteSpace(m.Observaciones) ? (object)DBNull.Value : m.Observaciones);
        }

        private MantenimientoAula MapToEntity(SqliteDataReader reader)
        {
            return new MantenimientoAula
            {
                Id = reader.GetInt32(0),
                EdificioId = reader.GetInt32(1),
                FechaEjecucion = reader.GetString(2),
                TipoMantenimiento = reader.GetString(3),
                Observaciones = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                EdificioNombre = reader.GetString(5)
            };
        }
    }
}
