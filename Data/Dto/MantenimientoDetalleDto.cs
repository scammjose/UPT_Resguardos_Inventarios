using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Dto
{
    /// <summary>
    /// Este modelo sirve SOLO para mostrar datos en el DataGridView del historial.
    /// Trae los nombres (joins) en lugar de solo los IDs.
    /// </summary>
    public class MantenimientoDetalleDto
    {
        public int Id { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // Programado / Correctivo

        // Aquí guardamos la concatenación: "Laptop HP - Serie 123"
        public string EquipoInfo { get; set; } = string.Empty;

        // Aquí guardamos el nombre del dueño: "Juan Perez"
        public string AdminNombre { get; set; } = string.Empty;

        // Aquí guardamos el nombre del técnico: "Maria Sistemas"
        public string TecnicoNombre { get; set; } = string.Empty;

        public string Observaciones { get; set; } = string.Empty;

        public string TipoEquipoNombre { get; set; } = "";
        public string CodigoInventario { get; set; } = "";
        public string AreaNombre { get; set; } = "";
        public string Serie { get; set; } = "";
    }
}
