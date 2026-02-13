using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IEstadisticasRepository
    {
        // Totales generales
        int GetTotalAdministrativos();
        int GetTotalEquipos();
        int GetTotalResguardos();

        // Agrupaciones para gráficos o tablas
        Dictionary<string, int> GetAdministrativosPorArea();
        Dictionary<string, int> GetEquiposPorTipo();
        Dictionary<string, int> GetEquiposPorArea();
        Dictionary<string, int> GetResguardosPorAnio();

        // Consultas específicas
        Dictionary<string, int> GetImpresorasPorTipoImpresion();
    }
}
