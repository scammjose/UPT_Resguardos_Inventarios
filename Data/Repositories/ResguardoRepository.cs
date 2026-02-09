using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Domain;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class ResguardoRepository : IResguardoRepository
    {
        public IEnumerable<Resguardo> GetAll()
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id,
                       EquipoId,
                       AdministrativoId,
                       ResponsableSistemasId,
                       CodigoInventario,
                       FechaResguardo,
                       Notas
                FROM Resguardos
                ORDER BY CodigoInventario;
            ";

            using var reader = cmd.ExecuteReader();
            var lista = new List<Resguardo>();

            while (reader.Read())
            {
                var r = new Resguardo
                {
                    Id = reader.GetInt32(0),
                    EquipoId = reader.GetInt32(1),
                    AdministrativoId = reader.GetInt32(2),
                    ResponsableSistemasId = reader.GetInt32(3),
                    CodigoInventario = reader.GetString(4),
                    FechaResguardo = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Notas = reader.IsDBNull(6) ? null : reader.GetString(6)
                };
                lista.Add(r);
            }

            return lista;
        }

        public Resguardo? GetById(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id,
                       EquipoId,
                       AdministrativoId,
                       ResponsableSistemasId,
                       CodigoInventario,
                       FechaResguardo,
                       Notas
                FROM Resguardos
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@id", id));

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Resguardo
                {
                    Id = reader.GetInt32(0),
                    EquipoId = reader.GetInt32(1),
                    AdministrativoId = reader.GetInt32(2),
                    ResponsableSistemasId = reader.GetInt32(3),
                    CodigoInventario = reader.GetString(4),
                    FechaResguardo = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Notas = reader.IsDBNull(6) ? null : reader.GetString(6)
                };
            }

            return null;
        }

        public int Add(Resguardo r)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Resguardos (
                    EquipoId,
                    AdministrativoId,
                    ResponsableSistemasId,
                    CodigoInventario,
                    FechaResguardo,
                    Notas
                )
                VALUES (
                    @equipoId,
                    @adminId,
                    @respSisId,
                    @codigo,
                    @fecha,
                    @notas
                );
                SELECT last_insert_rowid();
            ";

            cmd.Parameters.Add(new SqliteParameter("@equipoId", r.EquipoId));
            cmd.Parameters.Add(new SqliteParameter("@adminId", r.AdministrativoId));
            cmd.Parameters.Add(new SqliteParameter("@respSisId", r.ResponsableSistemasId));
            cmd.Parameters.Add(new SqliteParameter("@codigo", r.CodigoInventario));
            cmd.Parameters.Add(new SqliteParameter("@fecha",
                (object?)r.FechaResguardo ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@notas",
                (object?)r.Notas ?? DBNull.Value));

            var result = cmd.ExecuteScalar();
            var newId = Convert.ToInt32(result);
            r.Id = newId;
            return newId;
        }

        public void Update(Resguardo r)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE Resguardos
                SET EquipoId = @equipoId,
                    AdministrativoId = @adminId,
                    ResponsableSistemasId = @respSisId,
                    CodigoInventario = @codigo,
                    FechaResguardo = @fecha,
                    Notas = @notas
                WHERE Id = @id;
            ";

            cmd.Parameters.Add(new SqliteParameter("@equipoId", r.EquipoId));
            cmd.Parameters.Add(new SqliteParameter("@adminId", r.AdministrativoId));
            cmd.Parameters.Add(new SqliteParameter("@respSisId", r.ResponsableSistemasId));
            cmd.Parameters.Add(new SqliteParameter("@codigo", r.CodigoInventario));
            cmd.Parameters.Add(new SqliteParameter("@fecha",
                (object?)r.FechaResguardo ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@notas",
                (object?)r.Notas ?? DBNull.Value));
            cmd.Parameters.Add(new SqliteParameter("@id", r.Id));

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Resguardos WHERE Id = @id;";
            cmd.Parameters.Add(new SqliteParameter("@id", id));
            cmd.ExecuteNonQuery();
        }

        public string? ObtenerUltimoCodigoPorAreaYAnio(string nomenclaturaArea, int anio)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT CodigoInventario
                FROM Resguardos
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
