using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{

    public class EdificioRepository : IEdificioRepository
    {
        // Consulta base con el JOIN hacia Responsables y Administrativos
        private readonly string _baseSelect = @"
        SELECT 
            e.Id, 
            e.Nombre, 
            e.Ubicacion, 
            e.CantidadAulas, 
            e.ResponsableSistemasId,
            a.NombreCompleto AS ResponsableNombre
        FROM Edificios e
        INNER JOIN ResponsablesSistemas rs ON e.ResponsableSistemasId = rs.Id
        INNER JOIN Administrativos a ON rs.AdministrativoId = a.Id";

        public IEnumerable<Edificio> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " ORDER BY e.Nombre;";

            using var reader = cmd.ExecuteReader();
            var lista = new List<Edificio>();

            while (reader.Read())
            {
                lista.Add(MapToDto(reader));
            }

            return lista;
        }

        public Edificio? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = _baseSelect + " WHERE e.Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapToDto(reader);
            }

            return null;
        }

        public void Add(Edificio edificio)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
            INSERT INTO Edificios (Nombre, Ubicacion, CantidadAulas, ResponsableSistemasId)
            VALUES (@nombre, @ubicacion, @cantidadAulas, @responsableId);";

            cmd.Parameters.AddWithValue("@nombre", edificio.Nombre);
            cmd.Parameters.AddWithValue("@ubicacion", edificio.Ubicacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@cantidadAulas", edificio.CantidadAulas);
            cmd.Parameters.AddWithValue("@responsableId", edificio.ResponsableSistemasId);

            cmd.ExecuteNonQuery();
        }

        public void Update(Edificio edificio)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
            UPDATE Edificios 
            SET Nombre = @nombre, 
                Ubicacion = @ubicacion, 
                CantidadAulas = @cantidadAulas, 
                ResponsableSistemasId = @responsableId
            WHERE Id = @id;";

            // Cuidando las minúsculas como aprendimos con @id 😉
            cmd.Parameters.AddWithValue("@id", edificio.Id);
            cmd.Parameters.AddWithValue("@nombre", edificio.Nombre);
            cmd.Parameters.AddWithValue("@ubicacion", edificio.Ubicacion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@cantidadAulas", edificio.CantidadAulas);
            cmd.Parameters.AddWithValue("@responsableId", edificio.ResponsableSistemasId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            // Borrado seguro: validamos que coincida el @id
            cmd.CommandText = "DELETE FROM Edificios WHERE Id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        // Método auxiliar para no repetir código de mapeo
        private Edificio MapToDto(Microsoft.Data.Sqlite.SqliteDataReader reader)
        {
            return new Edificio
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Ubicacion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                CantidadAulas = reader.GetInt32(3),
                ResponsableSistemasId = reader.GetInt32(4),
                ResponsableNombre = reader.GetString(5)
            };
        }
    }
}
