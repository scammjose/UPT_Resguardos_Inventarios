using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class DetalleEquipoLote
    {
        public int Fila { get; set; }

        // Datos siempre obligatorios para red/CPU
        public string NumeroSerie { get; set; } = string.Empty;
        public string DireccionIp { get; set; } = string.Empty;

        // Para Telefonía IP
        public string MacAddress { get; set; } = string.Empty;
        public string NumeroExtension { get; set; } = string.Empty;
        public string PrivilegiosLlamadas { get; set; } = string.Empty;

        // Periféricos (Solo visibles si es PC de Escritorio)
        public string MonitorMarca { get; set; } = string.Empty;
        public string MonitorModelo { get; set; } = string.Empty;
        public string MonitorSerie { get; set; } = string.Empty;

        public string TecladoMarca { get; set; } = string.Empty;
        public string TecladoModelo { get; set; } = string.Empty;
        public string TecladoSerie { get; set; } = string.Empty;

        public string MouseMarca { get; set; } = string.Empty;
        public string MouseModelo { get; set; } = string.Empty;
        public string MouseSerie { get; set; } = string.Empty;

        // Para Impresoras
        public string TipoImpresion { get; set; } = string.Empty;
    }
}
