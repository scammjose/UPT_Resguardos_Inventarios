using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class Laboratorio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int EdificioId { get; set; }
        public int AreaId { get; set; }
        public int ResponsableSistemasId { get; set; }
        public int CantidadEquipos { get; set; }

        // --- Propiedades extendidas para la interfaz gráfica (Se llenan con JOIN) ---
        public string? EdificioNombre { get; set; }
        public string? AreaNombre { get; set; }
        public string? ResponsableSistemasNombre { get; set; }
    }
}
