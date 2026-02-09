using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class Administrativo
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Puesto { get; set; }
        public int AreaId { get; set; }

        // 🔹 Propiedad solo para mostrar en la UI (no existe en la BD)
        public string? AreaNombre { get; set; }
    }
}
