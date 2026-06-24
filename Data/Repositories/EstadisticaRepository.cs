using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Repositories
{
    public class EstadisticaRepository
    {
        public DashboardEstadisticasDto ObtenerDatosDashboard()
        {
            var dashboard = new DashboardEstadisticasDto();
            using var connection = Database.GetOpenConnection();

            // 1. Totales Generales
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(Id) FROM Equipos;";
                dashboard.TotalEquiposRegistrados = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = "SELECT COUNT(Id) FROM Resguardos;";
                dashboard.TotalEquiposEnResguardo = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // 2. Desglose exacto por Hardware (Cuántas Laptops, Reguladores, Teléfonos, etc.)
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT te.Nombre AS Categoria, COUNT(e.Id) AS Cantidad
                    FROM Equipos e
                    INNER JOIN TiposEquipos te ON te.Id = e.TipoEquipoId
                    GROUP BY te.Nombre
                    ORDER BY Cantidad DESC;";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dashboard.EquiposPorTipoHardware.Add(new ItemEstadistica { Etiqueta = reader.GetString(0), Valor = reader.GetInt32(1) });
            }

            // 3. Desglose exacto por Laboratorio (Máquinas por cada Lab)
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT l.Nombre AS Categoria, COUNT(r.Id) AS Cantidad
                    FROM Resguardos r
                    INNER JOIN Laboratorios l ON l.Id = r.LaboratorioId
                    GROUP BY l.Nombre
                    ORDER BY Cantidad DESC;";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dashboard.EquiposPorMarca.Add(new ItemEstadistica { Etiqueta = reader.GetString(0), Valor = reader.GetInt32(1) });
            }

            // 4. Desglose por Tipo de Uso (Administrativo vs Docentes/Alumnos)
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT tu.Nombre AS Categoria, COUNT(r.Id) AS Cantidad
                    FROM Resguardos r
                    INNER JOIN TiposUso tu ON tu.Id = r.TipoUsoId
                    GROUP BY tu.Nombre
                    ORDER BY Cantidad DESC;";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    dashboard.EquiposPorTipoUso.Add(new ItemEstadistica { Etiqueta = reader.GetString(0), Valor = reader.GetInt32(1) });
            }

            return dashboard;
        }
    }
}
