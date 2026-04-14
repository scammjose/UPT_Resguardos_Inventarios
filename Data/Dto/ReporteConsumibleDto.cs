using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Dto
{
    public class ReporteConsumibleDto
    {
        public string MarcaEquipo { get; set; } = string.Empty;
        public string ModeloEquipo { get; set; } = string.Empty;
        public string SerieEquipo { get; set; } = string.Empty;

        // --- NUEVOS CAMPOS ---
        public string AreaNombre { get; set; } = string.Empty;
        public string ResponsableNombre { get; set; } = string.Empty;
        // ---------------------

        public string ModeloConsumible { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }

        public bool RequiereCompra => StockActual <= StockMinimo;
    }
}
