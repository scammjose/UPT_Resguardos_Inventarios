using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class TipoUsoRepository : ITipoUsoRepository // Si no usas interfaz, quítale el ": ITipoUsoRepository"
    {
        public IEnumerable<TipoUso> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nombre FROM TiposUso ORDER BY Id;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<TipoUso>();
            while (reader.Read())
            {
                lista.Add(new TipoUso { Id = reader.GetInt32(0), Nombre = reader.GetString(1) });
            }
            return lista;
        }

        public TipoUso? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nombre FROM TiposUso WHERE Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new TipoUso { Id = reader.GetInt32(0), Nombre = reader.GetString(1) };

            return null;
        }

        public void Add(TipoUso tipoUso)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO TiposUso (Nombre) VALUES (@Nombre);";
            cmd.Parameters.AddWithValue("@Nombre", tipoUso.Nombre);
            cmd.ExecuteNonQuery();
        }

        public void Update(TipoUso tipoUso)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE TiposUso SET Nombre = @Nombre WHERE Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", tipoUso.Id);
            cmd.Parameters.AddWithValue("@Nombre", tipoUso.Nombre);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM TiposUso WHERE Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
