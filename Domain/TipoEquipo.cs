using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class TipoEquipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty; // Laptop, Impresora, etc.
    }
}
