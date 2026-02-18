using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public int AdministrativoId { get; set; }
        public int ResponsableSistemasId { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // "Programado" o "Correctivo"
        public string Observaciones { get; set; } = string.Empty;
        public bool CreadoAutomaticamente { get; set; } = true;
    }
}
