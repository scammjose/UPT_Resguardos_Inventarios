using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class EntregaConsumibleRepository : IEntregaConsumibleRepository
    {
        public IEnumerable<EntregaConsumible> ObtenerTodas()
        {
            var entregas = new List<EntregaConsumible>();

            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();
            // Traemos las entregas ordenadas de la más reciente a la más vieja
            command.CommandText = @"
                SELECT Id, ConsumibleId, EquipoId, AdministrativoId, ResponsableSistemasId, FechaEntrega, Cantidad 
                FROM EntregasConsumibles 
                ORDER BY FechaEntrega DESC;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                entregas.Add(new EntregaConsumible
                {
                    Id = reader.GetInt32(0),
                    ConsumibleId = reader.GetInt32(1),
                    EquipoId = reader.GetInt32(2),
                    AdministrativoId = reader.GetInt32(3),
                    ResponsableSistemasId = reader.GetInt32(4),
                    FechaEntrega = DateTime.Parse(reader.GetString(5)),
                    Cantidad = reader.GetInt32(6)
                });
            }

            return entregas;
        }

        public void Agregar(EntregaConsumible entrega)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO EntregasConsumibles 
                (ConsumibleId, EquipoId, AdministrativoId, ResponsableSistemasId, FechaEntrega, Cantidad) 
                VALUES 
                (@consumibleId, @equipoId, @adminId, @responsableId, @fecha, @cantidad);";

            command.Parameters.AddWithValue("@consumibleId", entrega.ConsumibleId);
            command.Parameters.AddWithValue("@equipoId", entrega.EquipoId);
            command.Parameters.AddWithValue("@adminId", entrega.AdministrativoId);
            command.Parameters.AddWithValue("@responsableId", entrega.ResponsableSistemasId);
            // Guardamos la fecha en formato estándar ISO para que SQLite no se confunda
            command.Parameters.AddWithValue("@fecha", entrega.FechaEntrega.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@cantidad", entrega.Cantidad);

            command.ExecuteNonQuery();
        }

        public IEnumerable<EntregaConsumible> ObtenerPorEquipo(int equipoId)
        {
            var entregas = new List<EntregaConsumible>();

            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, ConsumibleId, EquipoId, AdministrativoId, ResponsableSistemasId, FechaEntrega, Cantidad 
                FROM EntregasConsumibles 
                WHERE EquipoId = @equipoId
                ORDER BY FechaEntrega DESC;";

            command.Parameters.AddWithValue("@equipoId", equipoId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                entregas.Add(new EntregaConsumible
                {
                    Id = reader.GetInt32(0),
                    ConsumibleId = reader.GetInt32(1),
                    EquipoId = reader.GetInt32(2),
                    AdministrativoId = reader.GetInt32(3),
                    ResponsableSistemasId = reader.GetInt32(4),
                    FechaEntrega = DateTime.Parse(reader.GetString(5)),
                    Cantidad = reader.GetInt32(6)
                });
            }

            return entregas;
        }
    }
}
