using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class MantenimientoAula
    {
        public int Id { get; set; }
        public int EdificioId { get; set; }
        public string FechaEjecucion { get; set; } = string.Empty; // Formato yyyy-MM-dd
        public string TipoMantenimiento { get; set; } = string.Empty; // 'Predictivo' o 'Correctivo'
        public string Observaciones { get; set; } = string.Empty;

        // Propiedad extra para la UI (obtenida por JOIN)
        public string? EdificioNombre { get; set; }
    }
}
