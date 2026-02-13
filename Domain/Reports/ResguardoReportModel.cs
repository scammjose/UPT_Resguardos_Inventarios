using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain.Reports
{
    public class ResguardoReportModel
    {
        // Resguardo
        public string CodigoInventario { get; set; } = string.Empty;
        public string FechaResguardo { get; set; } = string.Empty;
        public string Notas { get; set; } = string.Empty;

        // Área y responsables
        public string AreaNombre { get; set; } = string.Empty;

        public string AdministrativoNombre { get; set; } = string.Empty;
        public string AdministrativoPuesto { get; set; } = string.Empty;

        public string ResponsableSistemasNombre { get; set; } = string.Empty;
        public string ResponsableSistemasPuesto { get; set; } = string.Empty;

        // Tipo de equipo
        public string TipoEquipoNombre { get; set; } = string.Empty;

        // Equipo general
        public string EquipoMarca { get; set; } = string.Empty;
        public string EquipoModelo { get; set; } = string.Empty;
        public string EquipoNumeroSerie { get; set; } = string.Empty;
        public string EquipoDireccionIp { get; set; } = string.Empty;

        // PC / Laptop / All-in-one
        public string MemoriaRam { get; set; } = string.Empty;
        public string Procesador { get; set; } = string.Empty;
        public string DiscoDuro { get; set; } = string.Empty;
        public bool TieneLectorCd { get; set; }
        public bool EsPcEscritorio { get; set; }
        public bool EsAllInOne { get; set; }

        // Periféricos
        public string MarcaMonitor { get; set; } = string.Empty;
        public string ModeloMonitor { get; set; } = string.Empty;
        public string SerieMonitor { get; set; } = string.Empty;

        public string MarcaTeclado { get; set; } = string.Empty;
        public string ModeloTeclado { get; set; } = string.Empty;
        public string SerieTeclado { get; set; } = string.Empty;

        public string MarcaMouse { get; set; } = string.Empty;
        public string ModeloMouse { get; set; } = string.Empty;
        public string SerieMouse { get; set; } = string.Empty;

        public string MarcaWebcam { get; set; } = string.Empty;
        public string ModeloWebcam { get; set; } = string.Empty;
        public string SerieWebcam { get; set; } = string.Empty;

        // Impresora / Escáner
        public string TipoImpresion { get; set; } = string.Empty;

        // Telefonía IP
        public string MacAddress { get; set; } = string.Empty;
        public string NumeroExtension { get; set; } = string.Empty;
        public string PrivilegiosLlamadas { get; set; } = string.Empty;

        // Útil para mostrar en un solo campo si quieres
        public string EquipoDescripcion
            => $"{EquipoMarca} {EquipoModelo} - {EquipoNumeroSerie}".Trim();
    }
}
