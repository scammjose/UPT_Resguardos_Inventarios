using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class Area
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        // 🔹 Nuevo: código corto para inventario (REC, SIS, BIB...)
        public string NomenclaturaInventario { get; set; } = string.Empty;
    }
}
