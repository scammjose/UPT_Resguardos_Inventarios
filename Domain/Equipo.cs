using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class Equipo
    {
        public int Id { get; set; }

        // Relacionales
        public int TipoEquipoId { get; set; }        // PC, Laptop, Impresora, Teléfono IP, etc.
        // Para mostrar en la UI
        public string? TipoNombre { get; set; }

        // Datos generales (aplican casi a cualquier equipo)
        public string? Marca { get; set; }           // Marca principal del equipo (CPU, impresora, teléfono, etc.)
        public string? Modelo { get; set; }
        public string? NumeroSerie { get; set; }
        public string? DireccionIp { get; set; }     // PC, impresora de red, escáner de red, teléfono IP

        // Especificaciones de cómputo (PC escritorio / laptop / all-in-one)
        public string? MemoriaRam { get; set; }      // Ej. "8 GB"
        public string? Procesador { get; set; }      // Ej. "AMD Ryzen 3"
        public string? DiscoDuro { get; set; }       // Ej. "1 TB"
        public bool? TieneLectorCd { get; set; }     // true / false / null si no aplica

        // Periféricos para PC de escritorio
        public string? MarcaMonitor { get; set; }
        public string? ModeloMonitor { get; set; }
        public string? SerieMonitor { get; set; }

        public string? MarcaTeclado { get; set; }
        public string? ModeloTeclado { get; set; }
        public string? SerieTeclado { get; set; }

        public string? MarcaMouse { get; set; }
        public string? ModeloMouse { get; set; }
        public string? SerieMouse { get; set; }

        public string? MarcaWebcam { get; set; }
        public string? ModeloWebcam { get; set; }
        public string? SerieWebcam { get; set; }

        // Impresoras / escáner
        public string? TipoImpresion { get; set; }   // "Láser", "Tinta", etc. (para impresoras / multifuncionales)

        // Teléfono IP
        public string? MacAddress { get; set; }
        public string? NumeroExtension { get; set; } // Extensión telefónica
        public string? PrivilegiosLlamadas { get; set; } // "Internas", "Internas/Externas"

        // Flags
        public bool EsPcEscritorio { get; set; }     // true = PC de escritorio completa (CPU + periféricos)
        public bool EsAllInOne { get; set; }         // true = All-in-one (monitor integrado)
    }
}
