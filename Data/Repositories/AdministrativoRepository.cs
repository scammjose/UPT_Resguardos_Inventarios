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
    public class AdministrativoRepository : IAdministrativoRepository
    {

        public IEnumerable<Administrativo> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, NombreCompleto, Puesto, AreaId
                FROM Administrativos
                ORDER BY NombreCompleto;
            ";

            using var reader = cmd.ExecuteReader();
            var lista = new List<Administrativo>();

            while (reader.Read())
            {
                var admin = new Administrativo
                {
                    Id = reader.GetInt32(0),
                    NombreCompleto = reader.GetString(1),
                    Puesto = reader.IsDBNull(2) ? null : reader.GetString(2),
                    AreaId = reader.GetInt32(3)
                };

                lista.Add(admin);
            }

            return lista;
        }

        public Administrativo? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, NombreCompleto, Puesto, AreaId
                FROM Administrativos
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@id", id));

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Administrativo
                {
                    Id = reader.GetInt32(0),
                    NombreCompleto = reader.GetString(1),
                    Puesto = reader.IsDBNull(2) ? null : reader.GetString(2),
                    AreaId = reader.GetInt32(3)
                };
            }

            return null;
        }

        public int Add(Administrativo admin)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Administrativos (NombreCompleto, Puesto, AreaId)
                VALUES (@nombre, @puesto, @areaId);
                SELECT last_insert_rowid();
            ";

            cmd.Parameters.Add(new SqliteParameter("@nombre", admin.NombreCompleto));
            cmd.Parameters.Add(new SqliteParameter("@puesto",
                (object?)admin.Puesto ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@areaId", admin.AreaId));

            var result = cmd.ExecuteScalar();
            var newId = Convert.ToInt32(result);
            admin.Id = newId;
            return newId;
        }

        public void Update(Administrativo admin)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE Administrativos
                SET NombreCompleto = @nombre,
                    Puesto = @puesto,
                    AreaId = @areaId
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@nombre", admin.NombreCompleto));
            cmd.Parameters.Add(new SqliteParameter("@puesto",
                (object?)admin.Puesto ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@areaId", admin.AreaId));
            cmd.Parameters.Add(new SqliteParameter("@id", admin.Id));

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Administrativos WHERE Id = @id;";
            cmd.Parameters.Add(new SqliteParameter("@id", id));
            cmd.ExecuteNonQuery();
        }

    }
}
