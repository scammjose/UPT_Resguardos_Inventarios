using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using Microsoft.Data.Sqlite;

namespace AppEscritorioUPT.Data.Repositories
{
    public class TipoEquipoRepository : ITipoEquipoRepository
    {

        public IEnumerable<TipoEquipo> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, Nombre
                FROM TiposEquipos
                ORDER BY Nombre;
            ";

            using var reader = cmd.ExecuteReader();
            var lista = new List<TipoEquipo>();

            while (reader.Read())
            {
                var tipo = new TipoEquipo
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                };
                lista.Add(tipo);
            }

            return lista;
        }

        public TipoEquipo? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, Nombre
                FROM TiposEquipos
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@id", id));

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new TipoEquipo
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                };
            }

            return null;
        }

        public int Add(TipoEquipo tipo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO TiposEquipos (Nombre)
                VALUES (@nombre);
                SELECT last_insert_rowid();
            ";

            cmd.Parameters.Add(new SqliteParameter("@nombre", tipo.Nombre));

            var result = cmd.ExecuteScalar();
            var newId = Convert.ToInt32(result);
            tipo.Id = newId;
            return newId;
        }

        public void Update(TipoEquipo tipo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE TiposEquipos
                SET Nombre = @nombre
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@nombre", tipo.Nombre));
            cmd.Parameters.Add(new SqliteParameter("@id", tipo.Id));

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM TiposEquipos WHERE Id = @id;";
            cmd.Parameters.Add(new SqliteParameter("@id", id));
            cmd.ExecuteNonQuery();
        }

    }
}
