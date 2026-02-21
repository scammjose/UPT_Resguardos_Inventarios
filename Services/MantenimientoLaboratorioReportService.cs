using AppEscritorioUPT.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class MantenimientoLaboratorioReportService
    {
        private readonly MantenimientoLaboratorioService _mantenimientoService;
        private readonly LaboratorioService _laboratorioService;

        // Variables de ruta al igual que en Aulas
        private readonly string _templatesPath;
        private readonly string _htmlTempPath;
        private readonly string _outputPath;

        public MantenimientoLaboratorioReportService()
        {
            _mantenimientoService = new MantenimientoLaboratorioService();
            _laboratorioService = new LaboratorioService();

            // Configuramos las mismas rutas que tu módulo de Aulas
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            _templatesPath = Path.Combine(baseDir, "Reports", "Templates");
            _htmlTempPath = Path.Combine(_templatesPath, "Html");
            _outputPath = Path.Combine(baseDir, "Reports", "Output");

            if (!Directory.Exists(_outputPath)) Directory.CreateDirectory(_outputPath);
            if (!Directory.Exists(_htmlTempPath)) Directory.CreateDirectory(_htmlTempPath);
        }

        public string GenerarPdfMantenimientoLaboratorio(int mantenimientoId)
        {
            // 1. Obtener los datos de la BD
            var mantenimiento = _mantenimientoService.ObtenerPorId(mantenimientoId);
            if (mantenimiento == null) throw new Exception("No se encontró el registro de mantenimiento.");

            var laboratorio = _laboratorioService.ObtenerPorId(mantenimiento.LaboratorioId);
            if (laboratorio == null) throw new Exception("No se encontró la información del laboratorio.");

            int cantidadEquipos = laboratorio.CantidadEquipos > 0 ? laboratorio.CantidadEquipos : 10;

            // 2. Leer la plantilla HTML desde la ruta correcta
            string htmlPath = Path.Combine(_htmlTempPath, "MantenimientoLaboratorio.html");
            if (!File.Exists(htmlPath))
                throw new FileNotFoundException($"No se encontró la plantilla en:\n{htmlPath}");

            string htmlTemplate = File.ReadAllText(htmlPath, Encoding.UTF8);

            // 3. Rutas relativas para CSS e Imágenes (Igual que en Aulas)
            string cssRelativo = "../Static/Css/MantenimientoLaboratorio.css";
            string logoUptRelativo = "../Static/Images/logo_upt.png";
            string logoSiteRelativo = "../Static/Images/logo_colmillos.png";

            // 4. Generar la matriz dinámica
            string celdasNumeros = ConstruirCabeceraEquipos(cantidadEquipos);

            string[] tareasSeguridad = {
                "Agrupaci&oacute;n de cableado",
                "Limpieza interior del gabinete",
                "Limpieza exterior del gabinete",
                "Limpieza de pantalla",
                "Limpieza del teclado",
                "Limpieza del mouse"
            };
            string filasSeguridad = ConstruirFilasTareas(tareasSeguridad, cantidadEquipos);

            string[] tareasConfiguracion = {
                "Restauraci&oacute;n del sistema",
                "Instalaci&oacute;n de programas",
                "Cuenta de alumnos",
                "Cuenta de sistemas",
                "Contrase&ntilde;a",
                "Papel tap&iacute;z",
                "Conexi&oacute;n a internet",
                "Deshabilitar actualizaciones",
                "Activar Deep Freeze"
            };
            string filasConfiguracion = ConstruirFilasTareas(tareasConfiguracion, cantidadEquipos);

            // 5. Reemplazos
            string htmlFinal = htmlTemplate
                .Replace("@RUTA_CSS", cssRelativo)
                .Replace("@LOGO_UPT", logoUptRelativo)
                .Replace("@LOGO_SITE", logoSiteRelativo)
                .Replace("@TIPO_MANTENIMIENTO", mantenimiento.TipoMantenimientoNombre?.ToUpper())
                .Replace("@RESPONSABLE_NOMBRE", mantenimiento.ResponsableSistemasNombre?.ToUpper())
                .Replace("@FECHA", mantenimiento.FechaEjecucion)
                .Replace("@LABORATORIO_NOMBRE", laboratorio.Nombre.ToUpper())
                .Replace("@OBSERVACIONES", mantenimiento.Observaciones)
                .Replace("@CANTIDAD_EQUIPOS", cantidadEquipos.ToString())
                .Replace("@COLSPAN_TOTAL", (cantidadEquipos + 1).ToString())
                .Replace("@CELDAS_NUMEROS_EQUIPOS", celdasNumeros)
                .Replace("@FILAS_SEGURIDAD", filasSeguridad)
                .Replace("@FILAS_CONFIGURACION", filasConfiguracion);

            // 6. Generar Archivos Temporales y Finales
            string nombreArchivoHtml = $"Temp_LabMatrix_{Guid.NewGuid()}.html";
            string rutaHtmlTemp = Path.Combine(_htmlTempPath, nombreArchivoHtml);
            File.WriteAllText(rutaHtmlTemp, htmlFinal, Encoding.UTF8);

            string nombreLabSafe = laboratorio.Nombre.Replace(" ", "_");
            string nombrePdf = $"Checklist_Lab_{nombreLabSafe}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string rutaPdfFinal = Path.Combine(_outputPath, nombrePdf);

            try
            {
                PdfHelper.HtmlToPdf(rutaHtmlTemp, rutaPdfFinal, landscape: true);
            }
            finally
            {
                if (File.Exists(rutaHtmlTemp)) File.Delete(rutaHtmlTemp);
            }

            return rutaPdfFinal;
        }

        // --- MÉTODOS PARA LA MATRIZ DINÁMICA ---

        private string ConstruirCabeceraEquipos(int cantidadEquipos)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= cantidadEquipos; i++)
            {
                // Usamos la nueva clase .num-cell para la cabecera
                sb.Append($"<th class='num-cell'>{i}</th>");
            }
            return sb.ToString();
        }

        private string ConstruirFilasTareas(string[] tareas, int cantidadEquipos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var tarea in tareas)
            {
                sb.Append("<tr>");
                sb.Append($"<td class='task-name'>{tarea}</td>");

                for (int i = 0; i < cantidadEquipos; i++)
                {
                    sb.Append("<td class='empty-cell'></td>");
                }

                sb.Append("</tr>");
            }
            return sb.ToString();
        }

        public string GenerarPdfMasivo(List<int> mantenimientosIds)
        {
            if (mantenimientosIds == null || mantenimientosIds.Count == 0)
                throw new Exception("No hay registros para generar.");

            // 1. Configuración inicial
            string htmlPath = Path.Combine(_htmlTempPath, "MantenimientoLaboratorio.html");
            if (!File.Exists(htmlPath)) throw new FileNotFoundException("No se encontró la plantilla HTML.");

            string htmlTemplate = File.ReadAllText(htmlPath, Encoding.UTF8);
            string cssRelativo = "../Static/Css/MantenimientoLaboratorio.css";
            string logoUptRelativo = "../Static/Images/logo_upt.png";
            string logoSiteRelativo = "../Static/Images/logo_colmillos.png";

            // 2. Extraer solo el contenido dentro del <body> de tu plantilla
            int bodyStart = htmlTemplate.IndexOf("<body>") + 6;
            int bodyEnd = htmlTemplate.IndexOf("</body>");
            string bodyTemplate = htmlTemplate.Substring(bodyStart, bodyEnd - bodyStart);

            // 3. Preparar el HTML "Contenedor"
            StringBuilder htmlCombinado = new StringBuilder();
            htmlCombinado.AppendLine("<!DOCTYPE html><html lang=\"es\"><head><meta charset=\"UTF-8\">");
            htmlCombinado.AppendLine($"<link rel=\"stylesheet\" href=\"{cssRelativo}\">");

            // LA MAGIA: Esta clase obliga al PDF a saltar de hoja
            htmlCombinado.AppendLine("<style>.salto-pagina { page-break-after: always; }</style>");
            htmlCombinado.AppendLine("</head><body>");

            // 4. Generar cada checklist
            for (int i = 0; i < mantenimientosIds.Count; i++)
            {
                var mantenimiento = _mantenimientoService.ObtenerPorId(mantenimientosIds[i]);
                var laboratorio = _laboratorioService.ObtenerPorId(mantenimiento!.LaboratorioId);
                int cantidadEquipos = laboratorio!.CantidadEquipos > 0 ? laboratorio.CantidadEquipos : 10;

                string form = bodyTemplate; // Tomamos una copia limpia de la plantilla

                string celdasNumeros = ConstruirCabeceraEquipos(cantidadEquipos);

                string[] tareasSeguridad = {
                    "Agrupaci&oacute;n de cableado", "Limpieza interior del gabinete", "Limpieza exterior del gabinete",
                    "Limpieza de pantalla", "Limpieza del teclado", "Limpieza del mouse"
                };
                string filasSeguridad = ConstruirFilasTareas(tareasSeguridad, cantidadEquipos);

                string[] tareasConfiguracion = {
                    "Restauraci&oacute;n del sistema", "Instalaci&oacute;n de programas", "Cuenta de alumnos",
                    "Cuenta de sistemas", "Contrase&ntilde;a", "Papel tap&iacute;z", "Conexi&oacute;n a internet",
                    "Deshabilitar actualizaciones", "Activar Deep Freeze"
                };
                string filasConfiguracion = ConstruirFilasTareas(tareasConfiguracion, cantidadEquipos);

                // Reemplazamos los datos en la copia
                form = form.Replace("@LOGO_UPT", logoUptRelativo)
                           .Replace("@LOGO_SITE", logoSiteRelativo)
                           .Replace("@TIPO_MANTENIMIENTO", mantenimiento.TipoMantenimientoNombre?.ToUpper())
                           .Replace("@RESPONSABLE_NOMBRE", mantenimiento.ResponsableSistemasNombre?.ToUpper())
                           .Replace("@FECHA", mantenimiento.FechaEjecucion)
                           .Replace("@LABORATORIO_NOMBRE", laboratorio.Nombre.ToUpper())
                           .Replace("@OBSERVACIONES", mantenimiento.Observaciones)
                           .Replace("@CANTIDAD_EQUIPOS", cantidadEquipos.ToString())
                           .Replace("@COLSPAN_TOTAL", (cantidadEquipos + 1).ToString())
                           .Replace("@CELDAS_NUMEROS_EQUIPOS", celdasNumeros)
                           .Replace("@FILAS_SEGURIDAD", filasSeguridad)
                           .Replace("@FILAS_CONFIGURACION", filasConfiguracion);

                // Si NO es el último registro, le agregamos el div con el salto de página
                if (i < mantenimientosIds.Count - 1)
                {
                    htmlCombinado.AppendLine($"<div class=\"salto-pagina\">{form}</div>");
                }
                else
                {
                    // Al último registro no le ponemos salto para no dejar una hoja en blanco al final
                    htmlCombinado.AppendLine($"<div>{form}</div>");
                }
            }

            htmlCombinado.AppendLine("</body></html>");

            // 5. Guardar temporal y Convertir a PDF
            string nombreArchivoHtml = $"Temp_Masivo_{Guid.NewGuid()}.html";
            string rutaHtmlTemp = Path.Combine(_htmlTempPath, nombreArchivoHtml);
            File.WriteAllText(rutaHtmlTemp, htmlCombinado.ToString(), Encoding.UTF8);

            string nombrePdf = $"Checklist_Masivo_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string rutaPdfFinal = Path.Combine(_outputPath, nombrePdf);

            try
            {
                PdfHelper.HtmlToPdf(rutaHtmlTemp, rutaPdfFinal, landscape: true);
            }
            finally
            {
                if (File.Exists(rutaHtmlTemp)) File.Delete(rutaHtmlTemp);
            }

            return rutaPdfFinal;
        }
    }
}
