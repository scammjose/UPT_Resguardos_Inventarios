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
    public class LaboratorioRepository : ILaboratorioRepository
    {
        private readonly string _baseSelect = @"
            SELECT 
                l.Id, l.Nombre, l.EdificioId, l.AreaId, l.ResponsableSistemasId, l.CantidadEquipos,
                e.Nombre AS EdificioNombre, 
                a.Nombre AS AreaNombre, 
                adm.NombreCompleto AS ResponsableSistemasNombre
            FROM Laboratorios l
            INNER JOIN Edificios e ON l.EdificioId = e.Id
            INNER JOIN Areas a ON l.AreaId = a.Id
            INNER JOIN ResponsablesSistemas r ON l.ResponsableSistemasId = r.Id
            INNER JOIN Administrativos adm ON r.AdministrativoId = adm.Id";

        public IEnumerable<Laboratorio> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " ORDER BY l.Nombre ASC;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<Laboratorio>();
            while (reader.Read()) lista.Add(MapToEntity(reader));
            return lista;
        }

        public Laboratorio? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " WHERE l.Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read()) return MapToEntity(reader);
            return null;
        }

        public void Add(Laboratorio lab)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Laboratorios (Nombre, EdificioId, AreaId, ResponsableSistemasId, CantidadEquipos)
                VALUES (@nombre, @edificioId, @areaId, @respId, @cantidad);";

            AsignarParametros(cmd, lab);
            cmd.ExecuteNonQuery();
        }

        public void Update(Laboratorio lab)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE Laboratorios 
                SET Nombre = @nombre, EdificioId = @edificioId, AreaId = @areaId, 
                    ResponsableSistemasId = @respId, CantidadEquipos = @cantidad
                WHERE Id = @id;";

            cmd.Parameters.AddWithValue("@id", lab.Id);
            AsignarParametros(cmd, lab);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Laboratorios WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private void AsignarParametros(SqliteCommand cmd, Laboratorio lab)
        {
            cmd.Parameters.AddWithValue("@nombre", lab.Nombre);
            cmd.Parameters.AddWithValue("@edificioId", lab.EdificioId);
            cmd.Parameters.AddWithValue("@areaId", lab.AreaId);
            cmd.Parameters.AddWithValue("@respId", lab.ResponsableSistemasId);
            cmd.Parameters.AddWithValue("@cantidad", lab.CantidadEquipos);
        }

        private Laboratorio MapToEntity(SqliteDataReader reader)
        {
            return new Laboratorio
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                EdificioId = reader.GetInt32(2),
                AreaId = reader.GetInt32(3),
                ResponsableSistemasId = reader.GetInt32(4),
                CantidadEquipos = reader.GetInt32(5),
                EdificioNombre = reader.GetString(6),
                AreaNombre = reader.GetString(7),
                ResponsableSistemasNombre = reader.GetString(8)
            };
        }
    }
}
