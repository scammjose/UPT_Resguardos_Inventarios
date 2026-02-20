using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class Edificio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public int CantidadAulas { get; set; }
        public int ResponsableSistemasId { get; set; }
        public string ResponsableNombre { get; set; } = string.Empty; // El join con Administrativos
    }
}
