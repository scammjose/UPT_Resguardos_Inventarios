using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class Resguardo
    {
        public int Id { get; set; }

        public int EquipoId { get; set; }
        public int AdministrativoId { get; set; }
        public int ResponsableSistemasId { get; set; }

        public string CodigoInventario { get; set; } = string.Empty;
        public string? FechaResguardo { get; set; }   // luego podemos manejar DateTime
        public string? Notas { get; set; }

        // Props solo para mostrar en UI
        public string? EquipoDescripcion { get; set; }          // Marca/Modelo/Serie combinados
        public string? AdministrativoNombre { get; set; }
        public string? ResponsableSistemasNombre { get; set; }
        public string? AreaNombre { get; set; }
    }
}
