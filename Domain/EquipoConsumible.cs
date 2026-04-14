using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class EquipoConsumible
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }       // La Impresora física
        public int ConsumibleId { get; set; }   // El Tóner que le queda
    }
}
