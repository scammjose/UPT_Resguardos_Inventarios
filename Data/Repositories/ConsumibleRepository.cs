using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class ConsumibleRepository : IConsumibleRepository
    {
        public IEnumerable<Consumible> ObtenerTodos()
        {
            var consumibles = new List<Consumible>();

            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Modelo, Tipo, Color, StockActual, StockMinimo FROM Consumibles ORDER BY Modelo;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                consumibles.Add(new Consumible
                {
                    Id = reader.GetInt32(0),
                    Modelo = reader.GetString(1),
                    Tipo = reader.GetString(2),
                    Color = reader.GetString(3),
                    StockActual = reader.GetInt32(4),
                    StockMinimo = reader.GetInt32(5)
                });
            }

            return consumibles;
        }

        public Consumible? ObtenerPorId(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Modelo, Tipo, Color, StockActual, StockMinimo FROM Consumibles WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Consumible
                {
                    Id = reader.GetInt32(0),
                    Modelo = reader.GetString(1),
                    Tipo = reader.GetString(2),
                    Color = reader.GetString(3),
                    StockActual = reader.GetInt32(4),
                    StockMinimo = reader.GetInt32(5)
                };
            }

            return null;
        }

        public void Agregar(Consumible consumible)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Consumibles (Modelo, Tipo, Color, StockActual, StockMinimo) 
                VALUES (@modelo, @tipo, @color, @stockActual, @stockMinimo);";

            command.Parameters.AddWithValue("@modelo", consumible.Modelo);
            command.Parameters.AddWithValue("@tipo", consumible.Tipo);
            command.Parameters.AddWithValue("@color", consumible.Color);
            command.Parameters.AddWithValue("@stockActual", consumible.StockActual);
            command.Parameters.AddWithValue("@stockMinimo", consumible.StockMinimo);

            command.ExecuteNonQuery();
        }

        public void Actualizar(Consumible consumible)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE Consumibles 
                SET Modelo = @modelo, 
                    Tipo = @tipo,
                    Color = @color,
                    StockActual = @stockActual, 
                    StockMinimo = @stockMinimo 
                WHERE Id = @id;";

            command.Parameters.AddWithValue("@id", consumible.Id);
            command.Parameters.AddWithValue("@modelo", consumible.Modelo);
            command.Parameters.AddWithValue("@tipo", consumible.Tipo);
            command.Parameters.AddWithValue("@color", consumible.Color);
            command.Parameters.AddWithValue("@stockActual", consumible.StockActual);
            command.Parameters.AddWithValue("@stockMinimo", consumible.StockMinimo);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();

            // Nota: Podríamos agregar una validación después para no dejar borrar 
            // un tóner si ya tiene un historial de entregas amarrado a él.
            command.CommandText = "DELETE FROM Consumibles WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public void ActualizarStock(int id, int cantidadCambio)
        {
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();

            // cantidadCambio puede ser positivo (cuando compras más) o negativo (cuando instalas uno)
            command.CommandText = @"
                UPDATE Consumibles 
                SET StockActual = StockActual + @cambio 
                WHERE Id = @id;";

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@cambio", cantidadCambio);

            command.ExecuteNonQuery();
        }

        public IEnumerable<ReporteConsumibleDto> ObtenerReporteGeneral()
        {
            var lista = new List<ReporteConsumibleDto>();
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
            SELECT 
                e.Marca, e.Modelo, e.NumeroSerie,
                ar.Nombre AS Area, 
                ad.NombreCompleto AS Responsable,
                c.Modelo AS ModeloToner, c.Color, c.StockActual, c.StockMinimo
            FROM Equipos e
            -- Unimos con Resguardos para saber quién la tiene
            LEFT JOIN Resguardos r ON e.Id = r.EquipoId
            -- Unimos con Administrativos para el nombre
            LEFT JOIN Administrativos ad ON r.AdministrativoId = ad.Id
            -- Unimos con Áreas
            LEFT JOIN Areas ar ON ad.AreaId = ar.Id
            -- Unimos con la compatibilidad de tóners
            INNER JOIN EquiposConsumibles ec ON e.Id = ec.EquipoId
            INNER JOIN Consumibles c ON c.Id = ec.ConsumibleId
            ORDER BY ar.Nombre, ad.NombreCompleto, e.Modelo;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new ReporteConsumibleDto
                {
                    MarcaEquipo = reader.GetString(0),
                    ModeloEquipo = reader.GetString(1),
                    SerieEquipo = reader.GetString(2),
                    AreaNombre = reader.IsDBNull(3) ? "SIN ÁREA" : reader.GetString(3),
                    ResponsableNombre = reader.IsDBNull(4) ? "SIN ASIGNAR" : reader.GetString(4),
                    ModeloConsumible = reader.GetString(5),
                    Color = reader.GetString(6),
                    StockActual = reader.GetInt32(7),
                    StockMinimo = reader.GetInt32(8)
                });
            }
            return lista;
        }

        public IEnumerable<RequisicionCompraDto> ObtenerReporteParaCompras()
        {
            var lista = new List<RequisicionCompraDto>();
            using var connection = Database.GetOpenConnection();
            using var command = connection.CreateCommand();

            // Magia SQL: Agrupamos por consumible y concatenamos las áreas que lo usan
            command.CommandText = @"
                SELECT 
                    c.Modelo, c.Tipo, c.Color, c.StockActual, c.StockMinimo,
                    (c.StockMinimo - c.StockActual) AS Faltante,
                    GROUP_CONCAT(e.Marca || ' ' || e.Modelo || ' (' || IFNULL(ar.Nombre, 'Sin Área') || ')', ' • ') AS EquiposDestino
                FROM Consumibles c
                LEFT JOIN EquiposConsumibles ec ON c.Id = ec.ConsumibleId
                LEFT JOIN Equipos e ON ec.EquipoId = e.Id
                LEFT JOIN Resguardos r ON e.Id = r.EquipoId
                LEFT JOIN Administrativos ad ON r.AdministrativoId = ad.Id
                LEFT JOIN Areas ar ON ad.AreaId = ar.Id
                GROUP BY c.Id, c.Modelo, c.Tipo, c.Color, c.StockActual, c.StockMinimo
                ORDER BY c.Id ASC;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int faltanteCalculado = reader.GetInt32(5);

                lista.Add(new RequisicionCompraDto
                {
                    ModeloConsumible = reader.GetString(0),
                    Tipo = reader.GetString(1),
                    Color = reader.GetString(2),
                    StockActual = reader.GetInt32(3),
                    StockMinimo = reader.GetInt32(4),
                    Faltante = faltanteCalculado > 0 ? faltanteCalculado : 0,
                    Equipos = reader.IsDBNull(6) ? "Ningún equipo asignado" : reader.GetString(6)
                });
            }
            return lista;
        }
    }
}
