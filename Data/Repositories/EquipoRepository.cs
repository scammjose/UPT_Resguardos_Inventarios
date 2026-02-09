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
    public class EquipoRepository : IEquipoRepository
    {
        public IEnumerable<Equipo> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id,
                       TipoEquipoId,
                       Marca,
                       Modelo,
                       NumeroSerie,
                       DireccionIp
                FROM Equipos
                ORDER BY Id;
            ";

            using var reader = cmd.ExecuteReader();
            var lista = new List<Equipo>();

            while (reader.Read())
            {
                var eq = new Equipo
                {
                    Id = reader.GetInt32(0),
                    TipoEquipoId = reader.GetInt32(1),
                    Marca = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Modelo = reader.IsDBNull(3) ? null : reader.GetString(3),
                    NumeroSerie = reader.IsDBNull(4) ? null : reader.GetString(4),
                    DireccionIp = reader.IsDBNull(5) ? null : reader.GetString(5)
                };

                lista.Add(eq);
            }

            return lista;
        }

        public Equipo? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id,
                       TipoEquipoId,
                       Marca,
                       Modelo,
                       NumeroSerie,
                       DireccionIp
                FROM Equipos
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@id", id));

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Equipo
                {
                    Id = reader.GetInt32(0),
                    TipoEquipoId = reader.GetInt32(1),
                    Marca = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Modelo = reader.IsDBNull(3) ? null : reader.GetString(3),
                    NumeroSerie = reader.IsDBNull(4) ? null : reader.GetString(4),
                    DireccionIp = reader.IsDBNull(5) ? null : reader.GetString(5)
                };
            }

            return null;
        }

        public int Add(Equipo equipo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Equipos (
                    TipoEquipoId,
                    Marca,
                    Modelo,
                    NumeroSerie,
                    DireccionIp
                )
                VALUES (
                    @tipoId,
                    @marca,
                    @modelo,
                    @serie,
                    @ip
                );
                SELECT last_insert_rowid();
            ";

            cmd.Parameters.Add(new SqliteParameter("@tipoId", equipo.TipoEquipoId));
            cmd.Parameters.Add(new SqliteParameter("@marca",
                (object?)equipo.Marca ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@modelo",
                (object?)equipo.Modelo ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@serie",
                (object?)equipo.NumeroSerie ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@ip",
                (object?)equipo.DireccionIp ?? DBNull.Value));

            var result = cmd.ExecuteScalar();
            var newId = Convert.ToInt32(result);
            equipo.Id = newId;
            return newId;
        }

        public void Update(Equipo equipo)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE Equipos
                SET TipoEquipoId     = @tipoId,
                    Marca            = @marca,
                    Modelo           = @modelo,
                    NumeroSerie      = @serie,
                    DireccionIp      = @ip
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@tipoId", equipo.TipoEquipoId));
            cmd.Parameters.Add(new SqliteParameter("@marca",
                (object?)equipo.Marca ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@modelo",
                (object?)equipo.Modelo ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@serie",
                (object?)equipo.NumeroSerie ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@ip",
                (object?)equipo.DireccionIp ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@id", equipo.Id));

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Equipos WHERE Id = @id;";
            cmd.Parameters.Add(new SqliteParameter("@id", id));
            cmd.ExecuteNonQuery();
        }

        public string? ObtenerUltimoCodigoPorAreaYAnio(string nomenclaturaArea, int anio)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            // Prefijo: UPT-REC-2026-
            cmd.CommandText = @"
                SELECT CodigoInventario
                FROM Equipos
                WHERE CodigoInventario LIKE @prefijo || '%'
                ORDER BY CodigoInventario DESC
                LIMIT 1;
            ";

            var prefijo = $"UPT-{nomenclaturaArea}-{anio}-";
            cmd.Parameters.Add(new SqliteParameter("@prefijo", prefijo));

            var result = cmd.ExecuteScalar();
            return result as string;
        }
    }
}
