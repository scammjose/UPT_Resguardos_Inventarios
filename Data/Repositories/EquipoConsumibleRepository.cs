using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class EquipoConsumibleRepository : IEquipoConsumibleRepository
    {
        public IEnumerable<Consumible> ObtenerConsumiblesPorEquipo(int equipoId)
        {
            var lista = new List<Consumible>();
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();

            // Consultamos la tabla Consumibles haciendo JOIN con la tabla de relación
            command.CommandText = @"
                SELECT c.Id, c.Modelo, c.Tipo, c.Color, c.StockActual, c.StockMinimo
                FROM Consumibles c
                INNER JOIN EquiposConsumibles ec ON c.Id = ec.ConsumibleId
                WHERE ec.EquipoId = @equipoId
                ORDER BY c.Modelo ASC;";

            command.Parameters.AddWithValue("@equipoId", equipoId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Consumible
                {
                    Id = reader.GetInt32(0),
                    Modelo = reader.GetString(1),
                    Tipo = reader.GetString(2),
                    Color = reader.GetString(3),
                    StockActual = reader.GetInt32(4),
                    StockMinimo = reader.GetInt32(5)
                });
            }
            return lista;
        }

        public void AsignarCompatibilidad(int equipoId, int consumibleId)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO EquiposConsumibles (EquipoId, ConsumibleId) VALUES (@eId, @cId);";
            command.Parameters.AddWithValue("@eId", equipoId);
            command.Parameters.AddWithValue("@cId", consumibleId);
            command.ExecuteNonQuery();
        }

        public void QuitarCompatibilidad(int equipoId, int consumibleId)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM EquiposConsumibles WHERE EquipoId = @eId AND ConsumibleId = @cId;";
            command.Parameters.AddWithValue("@eId", equipoId);
            command.Parameters.AddWithValue("@cId", consumibleId);
            command.ExecuteNonQuery();
        }

        public bool ExisteRelacion(int equipoId, int consumibleId)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(1) FROM EquiposConsumibles WHERE EquipoId = @eId AND ConsumibleId = @cId;";
            command.Parameters.AddWithValue("@eId", equipoId);
            command.Parameters.AddWithValue("@cId", consumibleId);
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        public IEnumerable<Equipo> ObtenerEquiposPorConsumible(int consumibleId)
        {
            // Implementación similar si necesitas saber qué impresoras usan X tóner
            return new List<Equipo>();
        }
    }
}
