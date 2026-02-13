using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AppEscritorioUPT.Data;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Domain.Reports;
using AppEscritorioUPT.Helpers;
using AppEscritorioUPT.Services;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Data.Repositories;
using System.Reflection;

namespace AppEscritorioUPT.Services
{
    public class ResguardoReportService
    {
        private readonly ResguardoService _resguardoService;
        private readonly ResguardoRepository _resguardoRepo;

        public ResguardoReportService()
        {
            _resguardoService = new ResguardoService();
            _resguardoRepo = new ResguardoRepository();
        }

        /// <summary>
        /// Genera el PDF de un resguardo y devuelve la ruta del archivo.
        /// </summary>
        public string GenerarPdfResguardo(int resguardoId)
        {
            // 1. Construir el modelo de reporte
            //var modelo = ConstruirModelo(resguardoId);
            var modelo = _resguardoRepo.GetByIdForReport(resguardoId);
            if (modelo == null)
                throw new Exception("No se encontró el resguardo para reporte.");

            // 2. Cargar plantilla HTML
            var html = CargarPlantillaHtml();

            // 3. Reemplazar placeholders
            html = ReemplazarPlaceholders(html, modelo);

            // 3.1 Construir bloques condicionales según tipo de equipo
            var (bPc, bImp, bTel) = ConstruirBloques(modelo);

            html = html.Replace("{{BLOQUE_PC}}", bPc)
                       .Replace("{{BLOQUE_IMPRESORA}}", bImp)
                       .Replace("{{BLOQUE_TELEFONIA}}", bTel);

            // 4. Guardar HTML temporal en la misma carpeta de Templates/Html
            var templatesRoot = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Reports", "Templates");
            var htmlOutputDir = Path.Combine(templatesRoot, "Html");

            if (!Directory.Exists(htmlOutputDir))
                Directory.CreateDirectory(htmlOutputDir);

            var htmlFileName = $"resguardo_{modelo.CodigoInventario}.html";
            var htmlPath = Path.Combine(htmlOutputDir, htmlFileName);
            File.WriteAllText(htmlPath, html);

            // 5. Definir ruta destino del PDF
            var pdfOutputDir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Reports", "Output");

            if (!Directory.Exists(pdfOutputDir))
                Directory.CreateDirectory(pdfOutputDir);

            var pdfFileName = $"Resguardo_{modelo.CodigoInventario}.pdf";
            var pdfPath = Path.Combine(pdfOutputDir, pdfFileName);

            // 6. Convertir HTML -> PDF
            PdfHelper.HtmlToPdf(htmlPath, pdfPath);

            // 7. Devolver ruta del PDF
            return pdfPath;
        }

        /// <summary>
        /// Construye el modelo del reporte a partir del ID de resguardo.
        /// Aquí usamos tu servicio existente para obtener los datos.
        /// </summary>
        private ResguardoReportModel ConstruirModelo(int resguardoId)
        {
            // OJO: aquí asumo que tienes un método ObtenerPorIdConDetalles
            // Si no existe, lo armamos con tu ResguardoRepository.
            var resguardo = _resguardoService.ObtenerPorId(resguardoId);

            if (resguardo == null)
                throw new Exception($"No se encontró el resguardo con Id {resguardoId}.");

            var modelo = new ResguardoReportModel
            {
                CodigoInventario = resguardo.CodigoInventario,
                FechaResguardo = resguardo.FechaResguardo ?? string.Empty,
                AreaNombre = resguardo.AreaNombre ?? string.Empty,
                TipoEquipoNombre = string.Empty,

                AdministrativoNombre = resguardo.AdministrativoNombre ?? string.Empty,
                AdministrativoPuesto = string.Empty, // si no lo tienes aún, lo dejamos "" o lo agregamos al query

                ResponsableSistemasNombre = resguardo.ResponsableSistemasNombre ?? string.Empty,
                ResponsableSistemasPuesto = string.Empty, // igual comentario

                EquipoMarca = string.Empty,
                EquipoModelo = string.Empty,
                EquipoNumeroSerie = string.Empty,
                EquipoDireccionIp = string.Empty,

                Notas = resguardo.Notas ?? string.Empty
            };

            return modelo;
        }

        /// <summary>
        /// Lee el archivo resguardo.html desde Reports/Templates/Html
        /// </summary>
        private string CargarPlantillaHtml()
        {
            var htmlPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Reports", "Templates", "Html", "resguardo.html");

            if (!File.Exists(htmlPath))
                throw new FileNotFoundException($"No se encontró la plantilla HTML en {htmlPath}");

            return File.ReadAllText(htmlPath);
        }

        /// <summary>
        /// Reemplaza los {{placeholders}} en el HTML por los valores del modelo.
        /// </summary>
        private string ReemplazarPlaceholders(string html, ResguardoReportModel m)
        {
            return html
                .Replace("{{CodigoInventario}}", m.CodigoInventario)
                .Replace("{{FechaResguardo}}", m.FechaResguardo)
                .Replace("{{AreaNombre}}", m.AreaNombre)
                .Replace("{{TipoEquipoNombre}}", m.TipoEquipoNombre)

                .Replace("{{AdministrativoNombre}}", m.AdministrativoNombre)
                .Replace("{{AdministrativoPuesto}}", m.AdministrativoPuesto)

                .Replace("{{ResponsableSistemasNombre}}", m.ResponsableSistemasNombre)
                .Replace("{{ResponsableSistemasPuesto}}", m.ResponsableSistemasPuesto)

                .Replace("{{EquipoDescripcion}}", m.EquipoDescripcion)
                .Replace("{{EquipoMarca}}", m.EquipoMarca)
                .Replace("{{EquipoModelo}}", m.EquipoModelo)
                .Replace("{{EquipoNumeroSerie}}", m.EquipoNumeroSerie)
                .Replace("{{EquipoDireccionIp}}", m.EquipoDireccionIp)

                .Replace("{{Notas}}", m.Notas);
        }

        // Método para quitar acentos y dejar el texto limpio
        private string NormalizarTipo(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";

            // Convertir a mayúsculas y quitar espacios extra
            texto = texto.Trim().ToUpperInvariant();

            // Reemplazos comunes de acentos
            return texto.Replace("Á", "A")
                        .Replace("É", "E")
                        .Replace("Í", "I")
                        .Replace("Ó", "O")
                        .Replace("Ú", "U");
        }

        private (string pc, string imp, string tel) ConstruirBloques(ResguardoReportModel m)
        {
            // Normalizamos: "ESCÁNER" pasará a ser "ESCANER"
            string tipo = NormalizarTipo(m.TipoEquipoNombre);

            string bloquePc = "";
            string bloqueImp = "";
            string bloqueTel = ""; // por ahora no aplica
                                   // (si luego agregas Telefonía IP, aquí lo llenas)

            switch (tipo)
            {
                case "PC DE ESCRITORIO":
                case "LAPTOP":
                    {
                        // Periféricos solo si es PC de escritorio (y no All in One)
                        string perif = "";
                        if (m.EsPcEscritorio && !m.EsAllInOne)
                        {
                            perif = $@"
                                <div class='section-title'>Periféricos</div>
                                <table class='tbl'>
                                  <thead>
                                    <tr><th>Componente</th><th>Marca</th><th>Modelo</th><th>Serie</th></tr>
                                  </thead>
                                  <tbody>
                                    <tr><td>Monitor</td><td>{m.MarcaMonitor}</td><td>{m.ModeloMonitor}</td><td>{m.SerieMonitor}</td></tr>
                                    <tr><td>Teclado</td><td>{m.MarcaTeclado}</td><td>{m.ModeloTeclado}</td><td>{m.SerieTeclado}</td></tr>
                                    <tr><td>Mouse</td><td>{m.MarcaMouse}</td><td>{m.ModeloMouse}</td><td>{m.SerieMouse}</td></tr>
                                    <tr><td>Webcam</td><td>{m.MarcaWebcam}</td><td>{m.ModeloWebcam}</td><td>{m.SerieWebcam}</td></tr>
                                  </tbody>
                                </table>";
                        }

                        bloquePc = $@"
                            <div class='card'>
                              <div class='card-header'>Especificaciones de Cómputo</div>
                              <table class='tbl'>
                                <tbody>
                                  <tr><th>RAM</th><td>{m.MemoriaRam}</td><th>Procesador</th><td>{m.Procesador}</td></tr>
                                  <tr><th>Disco</th><td>{m.DiscoDuro}</td><th>Lector CD</th><td>{(m.TieneLectorCd ? "Sí" : "No")}</td></tr
                                </tbody>
                              </table>
                              {perif}
                            </div>";
                        break;
                    }

                case "IMPRESORA":
                case "ESCANER":
                    {
                        bloqueImp = $@"
                            <div class='card'>
                              <div class='card-header'>Especificaciones de Impresión / Escaneo</div>
                              <table class='tbl'>
                                <tbody>
                                  <tr><th>Tipo</th><td>{m.TipoImpresion}</td></tr>
                                </tbody>
                              </table>
                            </div>";
                        break;
                    }

                case "TELEFONO IP":
                case "TELEFONO":
                    {
                        bloqueTel = $@"
                    <div class='card'>
                      <div class='card-header'>Especificaciones de Telefonía</div>
                      <table class='tbl'>
                        <tbody>
                          <tr><th>MAC Address</th><td>{m.MacAddress}</td></tr>
                          <tr><th>Extensión</th><td>{m.NumeroExtension}</td></tr>
                          <tr><th>Privilegios</th><td>{m.PrivilegiosLlamadas}</td></tr>
                        </tbody>
                      </table>
                    </div>";
                        break;
                    }

                case "REGULADOR":
                    {
                        // Por ahora no tienes extras para regulador, lo dejamos vacío.
                        // (Cuando agregues campos como CapacidadVA, Marca, etc., aquí lo llenas)
                        break;
                    }

                default:
                    // Si llega un tipo no esperado, no metemos bloques extra.
                    break;
            }

            return (bloquePc, bloqueImp, bloqueTel);
        }
    }
}
