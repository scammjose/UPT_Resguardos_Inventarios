using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Dto
{
    public class RequisicionCompraDto
    {
        public string ModeloConsumible { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int Faltante { get; set; }
        public string Equipos { get; set; } = string.Empty; // Aquí guardaremos la lista de áreas pegadas
    }
}
