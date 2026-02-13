using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class ResponsableSistemas
    {
        public int Id { get; set; }

        // Relación real
        public int AdministrativoId { get; set; }

        // Para mostrar en UI
        public string? AdministrativoNombre { get; set; }
        public string? AreaNombre { get; set; }
    }
}
