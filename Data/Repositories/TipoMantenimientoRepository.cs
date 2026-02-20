using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class TipoMantenimientoRepository : ITipoMantenimientoRepository
    {
        public IEnumerable<TipoMantenimiento> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nombre FROM TiposMantenimiento ORDER BY Nombre;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<TipoMantenimiento>();
            while (reader.Read())
            {
                lista.Add(new TipoMantenimiento
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                });
            }
            return lista;
        }

        public TipoMantenimiento? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nombre FROM TiposMantenimiento WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new TipoMantenimiento
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                };
            }
            return null;
        }

        public void Add(TipoMantenimiento tipo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO TiposMantenimiento (Nombre) VALUES (@nombre);";
            cmd.Parameters.AddWithValue("@nombre", tipo.Nombre);
            cmd.ExecuteNonQuery();
        }

        public void Update(TipoMantenimiento tipo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE TiposMantenimiento SET Nombre = @nombre WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@id", tipo.Id);
            cmd.Parameters.AddWithValue("@nombre", tipo.Nombre);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM TiposMantenimiento WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public bool ExistsNombre(string nombre, int idIgnorar = 0)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(1) FROM TiposMantenimiento WHERE LOWER(Nombre) = LOWER(@nombre) AND Id != @idIgnorar;";
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@idIgnorar", idIgnorar);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}
