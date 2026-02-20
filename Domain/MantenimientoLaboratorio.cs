using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class MantenimientoLaboratorio
    {
        public int Id { get; set; }
        public int LaboratorioId { get; set; }
        public string FechaEjecucion { get; set; } = string.Empty; // Formato yyyy-MM-dd
        public int TipoMantenimientoId { get; set; }
        public string Observaciones { get; set; } = string.Empty;

        // --- Propiedades extendidas para la interfaz gráfica y el PDF (Se llenan con JOIN) ---
        public string? LaboratorioNombre { get; set; }
        public string? TipoMantenimientoNombre { get; set; }
        public string? ResponsableSistemasNombre { get; set; } // Vendrá heredado del Laboratorio
    }
}
