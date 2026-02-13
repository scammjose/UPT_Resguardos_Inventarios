using AppEscritorioUPT.Data.Interfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppEscritorioUPT.Data.Repositories
{
    public class EstadisticasRepository : IEstadisticasRepository
    {
        // Método auxiliar para ejecutar conteos simples (Escalares)
        private int ExecuteScalarCount(string sql)
        {
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            var result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        // Método auxiliar para obtener datos agrupados (Diccionarios)
        private Dictionary<string, int> GetGroupedData(string sql)
        {
            var data = new Dictionary<string, int>();
            using var connection = Database.GetOpenConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string key = reader.IsDBNull(0) ? "Sin clasificar" : reader.GetString(0);
                int value = reader.GetInt32(1);
                data.Add(key, value);
            }
            return data;
        }

        public int GetTotalAdministrativos() => ExecuteScalarCount("SELECT COUNT(*) FROM Administrativos");

        public int GetTotalEquipos() => ExecuteScalarCount("SELECT COUNT(*) FROM Equipos");

        public int GetTotalResguardos() => ExecuteScalarCount("SELECT COUNT(*) FROM Resguardos");

        public Dictionary<string, int> GetAdministrativosPorArea()
        {
            return GetGroupedData(@"
                SELECT a.Nombre, COUNT(adm.Id) 
                FROM Areas a
                LEFT JOIN Administrativos adm ON a.Id = adm.AreaId
                GROUP BY a.Nombre;");
        }

        public Dictionary<string, int> GetEquiposPorTipo()
        {
            return GetGroupedData(@"
                SELECT t.Nombre, COUNT(e.Id) 
                FROM TiposEquipos t
                LEFT JOIN Equipos e ON t.Id = e.TipoEquipoId
                GROUP BY t.Nombre;");
        }

        public Dictionary<string, int> GetEquiposPorArea()
        {
            // Nota: Esta consulta asume que los equipos están relacionados con un área a través de un resguardo actual
            // o que la tabla Equipos tiene un AreaId directo (ajustar según tu DB)
            return GetGroupedData(@"
                SELECT a.Nombre, COUNT(e.Id) 
                FROM Areas a
                INNER JOIN Administrativos adm ON a.Id = adm.AreaId
                INNER JOIN Resguardos r ON adm.Id = r.AdministrativoId
                INNER JOIN Equipos e ON r.EquipoId = e.Id
                GROUP BY a.Nombre;");
        }

        public Dictionary<string, int> GetResguardosPorAnio()
        {
            return GetGroupedData(@"
                SELECT strftime('%Y', FechaResguardo) as Anio, COUNT(*) 
                FROM Resguardos 
                GROUP BY Anio 
                ORDER BY Anio DESC;");
        }

        public Dictionary<string, int> GetImpresorasPorTipoImpresion()
        {
            // Filtramos solo por el tipo de equipo 'Impresora'
            return GetGroupedData(@"
                SELECT TipoImpresion, COUNT(*) 
                FROM Equipos 
                WHERE TipoImpresion IS NOT NULL AND TipoImpresion <> ''
                GROUP BY TipoImpresion;");
        }
    }
}
