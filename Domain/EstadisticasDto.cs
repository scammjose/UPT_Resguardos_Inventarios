using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class ItemEstadistica
    {
        public string Etiqueta { get; set; } = "";
        public int Valor { get; set; }
    }

    public class DashboardEstadisticasDto
    {
        public int TotalEquiposRegistrados { get; set; }
        public int TotalEquiposEnResguardo { get; set; }

        // Para las gráficas
        public List<ItemEstadistica> EquiposPorTipoUso { get; set; } = new List<ItemEstadistica>();
        public List<ItemEstadistica> EquiposPorTipoHardware { get; set; } = new List<ItemEstadistica>();
        public List<ItemEstadistica> EquiposPorMarca { get; set; } = new List<ItemEstadistica>();
    }
}
