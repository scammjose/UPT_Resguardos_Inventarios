using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class MantenimientoReportService
    {
        private readonly string _templatesPath;
        private readonly string _htmlTempPath; // Nueva ruta para temporales
        private readonly string _outputPath;

        public MantenimientoReportService()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            _templatesPath = Path.Combine(baseDir, "Reports", "Templates");

            // GUARDAR TEMPORALES JUNTO A LA PLANTILLA ORIGINAL
            _htmlTempPath = Path.Combine(_templatesPath, "Html");

            _outputPath = Path.Combine(baseDir, "Reports", "Output");

            if (!Directory.Exists(_outputPath)) Directory.CreateDirectory(_outputPath);
            if (!Directory.Exists(_htmlTempPath)) Directory.CreateDirectory(_htmlTempPath);
        }

        public string GenerarPdfPorAdministrativo(int adminId, string fecha)
        {
            // 1. Obtener datos
            var repo = new MantenimientoRepository();
            var listaMantenimientos = repo.GetByAdministrativoYFecha(adminId, fecha);

            if (!listaMantenimientos.Any())
                throw new Exception("No hay registros para generar.");

            // 2. Cargar HTML Base
            string htmlPath = Path.Combine(_templatesPath, "Html", "mantenimiento.html");
            string htmlTemplate = File.ReadAllText(htmlPath);

            // 3. Definir rutas relativas (igual que en tu ResguardoService)
            // Como el HTML temporal se guardará en Templates/Html, subimos un nivel (..) para ir a Static
            string cssRelativo = "../Static/Css/mantenimiento.css";
            string logoUptRelativo = "../Static/Images/logo_upt.png";
            string logoColRelativo = "../Static/Images/logo_colmillos.png";

            StringBuilder sb = new StringBuilder();

            // Cabecera global
            sb.AppendLine("<!DOCTYPE html><html lang='es'><head><meta charset='UTF-8'>");
            sb.AppendLine($"<link rel='stylesheet' href='{cssRelativo}'>"); // <--- Ruta relativa
            sb.AppendLine("</head><body>");

            // 4. Iterar registros
            foreach (var dto in listaMantenimientos)
            {
                string filas = ConstruirFilasChecklist(dto.TipoEquipoNombre);

                // Reemplazos en el template
                string htmlPagina = htmlTemplate
                    .Replace("@RUTA_CSS", cssRelativo) // Reemplazo por relativa
                    .Replace("@LOGO_UPT", logoUptRelativo)
                    .Replace("@LOGO_COLMILLOS", logoColRelativo)
                    .Replace("@TIPO_MANTENIMIENTO", dto.Tipo.ToUpper())
                    .Replace("@TIPO_EQUIPO_NOMBRE", dto.TipoEquipoNombre.ToUpper())
                    .Replace("@RESPONSABLE_EQUIPO", dto.AdminNombre)
                    .Replace("@FECHA", dto.Fecha)
                    .Replace("@AREA", dto.AreaNombre)
                    .Replace("@MARCA_MODELO", dto.EquipoInfo)
                    .Replace("@CODIGO_INVENTARIO", dto.CodigoInventario)
                    .Replace("@SERIE", dto.Serie)
                    .Replace("@FILAS_DINAMICAS", filas)
                    .Replace("@OBSERVACIONES", dto.Observaciones)
                    .Replace("@TECNICO_NOMBRE", dto.TecnicoNombre);

                // Extraer solo el body para concatenar (usando tu método helper)
                htmlPagina = ExtraerSoloBody(htmlPagina);
                sb.AppendLine(htmlPagina);

                // Salto de página
                if (dto != listaMantenimientos.Last())
                {
                    sb.AppendLine("<div style='page-break-after: always;'></div>");
                }
            }

            sb.AppendLine("</body></html>");

            // 5. Guardar HTML Temporal en la carpeta Templates/Html (CLAVE DEL ÉXITO)
            string nombreArchivoHtml = $"Temp_Mant_{Guid.NewGuid()}.html";
            string rutaHtmlTemp = Path.Combine(_htmlTempPath, nombreArchivoHtml);

            File.WriteAllText(rutaHtmlTemp, sb.ToString());

            // 6. Generar PDF
            string nombrePdf = $"Checklist_{listaMantenimientos.First().AdminNombre}_{fecha}.pdf";
            string rutaPdfFinal = Path.Combine(_outputPath, nombrePdf);

            try
            {
                PdfHelper.HtmlToPdf(rutaHtmlTemp, rutaPdfFinal);
            }
            finally
            {
                // Opcional: Borrar el temporal
                if (File.Exists(rutaHtmlTemp)) File.Delete(rutaHtmlTemp);
            }

            return rutaPdfFinal;
        }

        // --- MÉTODOS AUXILIARES ---

        private string ConstruirFilasChecklist(string tipoEquipo)
        {
            StringBuilder sb = new StringBuilder();
            tipoEquipo = tipoEquipo.ToLower().Trim();

            bool esComputadora = tipoEquipo.Contains("pc") ||
                         tipoEquipo.Contains("computadora") ||
                         tipoEquipo.Contains("laptop") ||
                         tipoEquipo.Contains("all in one") ||
                         tipoEquipo.Contains("escritorio") ||
                         tipoEquipo.Contains("latitude");

            // --- CASO 1: COMPUTADORA (PC o Laptop) ---
            if (esComputadora)
            {
                // Sección 1: Seguridad y Limpieza
                sb.Append(GenerarEncabezadoSeccion("SEGURIDAD Y LIMPIEZA"));
                var itemsSeguridad = new List<string> {
                    "Agrupación de cableado", "Limpieza interior del gabinete", "Limpieza exterior del gabinete",
                    "Limpieza de pantalla", "Limpieza del teclado", "Limpieza del mouse"
                };
                foreach (var item in itemsSeguridad) sb.Append(GenerarFilaItem(item));

                // Sección 2: Configuración
                sb.Append(GenerarEncabezadoSeccion("CONFIGURACIÓN DEL EQUIPO"));
                var itemsConfig = new List<string> {
                    "Restauración del sistema", "Instalación de programas", "Cuenta de alumnos",
                    "Cuenta de sistemas", "Contraseña", "Papel tapiz",
                    "Conexión a internet", "Deshabilitar actualizaciones", "Activar Deep Freeze"
                };
                foreach (var item in itemsConfig) sb.Append(GenerarFilaItem(item));
            }
            // --- CASO 2: TELEFONÍA ---
            else if (tipoEquipo.Contains("telefon") || tipoEquipo.Contains("ip"))
            {
                sb.Append(GenerarEncabezadoSeccion("SEGURIDAD Y LIMPIEZA"));
                var itemsSeguridad = new List<string> {
                    "Agrupación de cableado", "Limpieza de teclado", "Limpieza de bocina", "Limpieza de pantalla"
                };
                foreach (var item in itemsSeguridad) sb.Append(GenerarFilaItem(item));

                sb.Append(GenerarEncabezadoSeccion("CONFIGURACIÓN DEL EQUIPO"));
                var itemsConfig = new List<string> { "No. De extensión", "Dirección IP v4", "Privilegios" };
                foreach (var item in itemsConfig) sb.Append(GenerarFilaItem(item));
            }
            // --- CASO 3: IMPRESORA / ESCÁNER ---
            else if (tipoEquipo.Contains("impresora") || tipoEquipo.Contains("escaner") || tipoEquipo.Contains("multifuncional"))
            {
                sb.Append(GenerarEncabezadoSeccion("REVISIÓN Y LIMPIEZA"));
                var itemsRev = new List<string> {
                    "Revisar nivel de tinta", "Revisar nivel de toner", "Limpieza de cabezales", "Limpieza de tambor"
                };
                foreach (var item in itemsRev) sb.Append(GenerarFilaItem(item));

                sb.Append(GenerarEncabezadoSeccion("CONFIGURACIÓN DEL EQUIPO"));
                var itemsConfig = new List<string> { "Compartir impresora por red", "Dirección IP v4", "Conexión a PC" };
                foreach (var item in itemsConfig) sb.Append(GenerarFilaItem(item));
            }
            // --- DEFAULT ---
            else
            {
                sb.Append(GenerarEncabezadoSeccion("REVISIÓN GENERAL"));
                sb.Append(GenerarFilaItem("Verificar estado físico"));
                sb.Append(GenerarFilaItem("Limpieza general"));
                sb.Append(GenerarFilaItem("Pruebas de funcionamiento"));
            }

            return sb.ToString();
        }

        private string GenerarEncabezadoSeccion(string titulo)
        {
            // Genera el título negro y la fila de encabezados de columnas
            return $@"
            <thead>
                <tr>
                    <th colspan='3' class='section-title'>{titulo}</th>
                </tr>
                <tr class='column-headers'>
                    <th style='width: 40%;'>ACTIVIDAD</th>
                    <th style='width: 20%; text-align: center;'>REALIZADO</th>
                    <th style='width: 40%;'>OBSERVACIONES</th>
                </tr>
            </thead>
            <tbody>";
        }

        private string GenerarFilaItem(string item)
        {
            // Genera 3 celdas: Nombre | Cuadro vacío | Espacio vacío
            return $@"
            <tr>
            <td class='item-cell'>{item}</td>
            <td class='check-cell'>
                <div class='checkbox-box'></div> </td> 
            <td class='obs-cell'></td> </tr>";
        }

        // Tu método helper reutilizado
        private static string ExtraerSoloBody(string html)
        {
            var start = html.IndexOf("<body", StringComparison.OrdinalIgnoreCase);
            if (start >= 0)
            {
                start = html.IndexOf(">", start, StringComparison.OrdinalIgnoreCase);
                if (start >= 0) start++;
            }
            var end = html.LastIndexOf("</body>", StringComparison.OrdinalIgnoreCase);
            if (start >= 0 && end > start)
                return html.Substring(start, end - start);
            return html;
        }

        public string GenerarPdfPorArea(int areaId, string fecha)
        {
            // 1. Obtener datos por ÁREA
            var repo = new MantenimientoRepository();
            var listaMantenimientos = repo.GetByAreaYFecha(areaId, fecha);

            if (!listaMantenimientos.Any())
                throw new Exception("No hay registros de mantenimiento para esta Área en la fecha seleccionada.");

            // 2. Preparar recursos (Igual que antes)
            string htmlPath = Path.Combine(_templatesPath, "Html", "mantenimiento.html");
            string htmlTemplate = File.ReadAllText(htmlPath);

            string cssRelativo = "../Static/Css/mantenimiento.css";
            string logoUptRelativo = "../Static/Images/logo_upt.png";
            string logoColRelativo = "../Static/Images/logo_colmillos.png";

            StringBuilder sb = new StringBuilder();

            // Cabecera global
            sb.AppendLine("<!DOCTYPE html><html lang='es'><head><meta charset='UTF-8'>");
            sb.AppendLine($"<link rel='stylesheet' href='{cssRelativo}'>");
            sb.AppendLine("</head><body>");

            // 3. Iterar registros
            foreach (var dto in listaMantenimientos)
            {
                string filas = ConstruirFilasChecklist(dto.TipoEquipoNombre);

                string htmlPagina = htmlTemplate
                    .Replace("@RUTA_CSS", cssRelativo)
                    .Replace("@LOGO_UPT", logoUptRelativo)
                    .Replace("@LOGO_COLMILLOS", logoColRelativo)
                    .Replace("@TIPO_MANTENIMIENTO", dto.Tipo.ToUpper())
                    .Replace("@TIPO_EQUIPO_NOMBRE", dto.TipoEquipoNombre.ToUpper())
                    .Replace("@RESPONSABLE_EQUIPO", dto.AdminNombre)
                    .Replace("@FECHA", dto.Fecha)
                    .Replace("@AREA", dto.AreaNombre)
                    .Replace("@MARCA_MODELO", dto.EquipoInfo)
                    .Replace("@CODIGO_INVENTARIO", dto.CodigoInventario)
                    .Replace("@SERIE", dto.Serie)
                    .Replace("@FILAS_DINAMICAS", filas)
                    .Replace("@OBSERVACIONES", dto.Observaciones)
                    .Replace("@TECNICO_NOMBRE", dto.TecnicoNombre);

                htmlPagina = ExtraerSoloBody(htmlPagina);
                sb.AppendLine(htmlPagina);

                if (dto != listaMantenimientos.Last())
                {
                    sb.AppendLine("<div style='page-break-after: always;'></div>");
                }
            }

            sb.AppendLine("</body></html>");

            // 4. Guardar HTML Temporal
            string nombreArchivoHtml = $"Temp_Area_{Guid.NewGuid()}.html";
            string rutaHtmlTemp = Path.Combine(_htmlTempPath, nombreArchivoHtml);
            File.WriteAllText(rutaHtmlTemp, sb.ToString());

            // 5. Generar PDF
            // El nombre del archivo ahora lleva el nombre del ÁREA
            string nombreAreaSafe = listaMantenimientos.First().AreaNombre.Replace(" ", "_");
            string nombrePdf = $"Checklist_AREA_{nombreAreaSafe}_{fecha}.pdf";
            string rutaPdfFinal = Path.Combine(_outputPath, nombrePdf);

            try
            {
                PdfHelper.HtmlToPdf(rutaHtmlTemp, rutaPdfFinal);
            }
            finally
            {
                if (File.Exists(rutaHtmlTemp)) File.Delete(rutaHtmlTemp);
            }

            return rutaPdfFinal;
        }

    }
}
