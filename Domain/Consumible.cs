using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class Consumible
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty; // Ej. "Tóner HP 85A", "Botella Tinta 664"
        public string Tipo { get; set; } = string.Empty;   // "Tóner", "Cartucho", "Tinta", "Tambor"
        public string Color { get; set; } = string.Empty;
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
    }
}
