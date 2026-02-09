using System;
using System.Collections.Generic;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using Microsoft.Data.Sqlite;

namespace AppEscritorioUPT.Data.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        public IEnumerable<Area> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, Nombre, Descripcion, NomenclaturaInventario
                FROM Areas
                ORDER BY Nombre;
            ";

            using var reader = cmd.ExecuteReader();
            var lista = new List<Area>();

            while (reader.Read())
            {
                var area = new Area
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                    NomenclaturaInventario = reader.GetString(3)
                };

                lista.Add(area);
            }

            return lista;
        }

        public Area? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, Nombre, Descripcion, NomenclaturaInventario
                FROM Areas
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@id", id));

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Area
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                    NomenclaturaInventario = reader.GetString(3)
                };
            }

            return null;
        }

        public int Add(Area area)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Areas (Nombre, Descripcion, NomenclaturaInventario)
                VALUES (@nombre, @descripcion, @nomenclatura);
                SELECT last_insert_rowid();
            ";

            cmd.Parameters.Add(new SqliteParameter("@nombre", area.Nombre));
            cmd.Parameters.Add(new SqliteParameter("@descripcion",
                (object?)area.Descripcion ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@nomenclatura", area.NomenclaturaInventario));

            var result = cmd.ExecuteScalar();
            var newId = Convert.ToInt32(result);
            area.Id = newId;
            return newId;
        }

        public void Update(Area area)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE Areas
                SET Nombre = @nombre,
                    Descripcion = @descripcion,
                    NomenclaturaInventario = @nomenclatura
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@nombre", area.Nombre));
            cmd.Parameters.Add(new SqliteParameter("@descripcion",
                (object?)area.Descripcion ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@nomenclatura", area.NomenclaturaInventario));
            cmd.Parameters.Add(new SqliteParameter("@id", area.Id));

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Areas WHERE Id = @id;";
            cmd.Parameters.Add(new SqliteParameter("@id", id));
            cmd.ExecuteNonQuery();
        }
    }
}
