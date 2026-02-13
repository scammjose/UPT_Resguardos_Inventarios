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
    public class ResponsableSistemasRepository : IResponsableSistemasRepository
    {
        private const string BaseSelect = @"
            SELECT
                rs.Id,
                rs.AdministrativoId,
                a.NombreCompleto,
                ar.Nombre AS AreaNombre
            FROM ResponsablesSistemas rs
            INNER JOIN Administrativos a ON a.Id = rs.AdministrativoId
            INNER JOIN Areas ar ON ar.Id = a.AreaId
        ";

        public IEnumerable<ResponsableSistemas> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = BaseSelect + " ORDER BY a.NombreCompleto;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<ResponsableSistemas>();

            while (reader.Read())
            {
                lista.Add(MapResponsable(reader));
            }

            return lista;
        }

        public ResponsableSistemas? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = BaseSelect + " WHERE rs.Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapResponsable(reader);

            return null;
        }

        public void Add(int administrativoId)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO ResponsablesSistemas (AdministrativoId)
                VALUES (@AdministrativoId);
            ";
            cmd.Parameters.AddWithValue("@AdministrativoId", administrativoId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM ResponsablesSistemas WHERE Id = @Id;";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        public bool ExistsByAdministrativo(int administrativoId)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT COUNT(1)
                FROM ResponsablesSistemas
                WHERE AdministrativoId = @AdministrativoId;
            ";
            cmd.Parameters.AddWithValue("@AdministrativoId", administrativoId);

            var count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        // ======== Helper ========

        private static ResponsableSistemas MapResponsable(SqliteDataReader reader)
        {
            return new ResponsableSistemas
            {
                Id = reader.GetInt32(0),
                AdministrativoId = reader.GetInt32(1),
                AdministrativoNombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                AreaNombre = reader.IsDBNull(3) ? null : reader.GetString(3)
            };
        }
    }
}
