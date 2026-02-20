using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    internal class MantenimientoAulaReportService
    {
        private readonly string _templatesPath;
        private readonly string _htmlTempPath;
        private readonly string _outputPath;

        public MantenimientoAulaReportService()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            _templatesPath = Path.Combine(baseDir, "Reports", "Templates");
            _htmlTempPath = Path.Combine(_templatesPath, "Html");
            _outputPath = Path.Combine(baseDir, "Reports", "Output");

            if (!Directory.Exists(_outputPath)) Directory.CreateDirectory(_outputPath);
            if (!Directory.Exists(_htmlTempPath)) Directory.CreateDirectory(_htmlTempPath);
        }

        public string GenerarPdfMantenimientoAula(int mantenimientoId)
        {
            var mantRepo = new MantenimientoAulaRepository();
            var mantenimiento = mantRepo.GetById(mantenimientoId);
            if (mantenimiento == null) throw new Exception("No se encontró el mantenimiento.");

            var edifRepo = new EdificioRepository();
            var edificio = edifRepo.GetById(mantenimiento.EdificioId);
            if (edificio == null) throw new Exception("No se encontró el edificio asociado.");

            string htmlPath = Path.Combine(_templatesPath, "Html", "mantenimientoAula.html");
            string htmlTemplate = File.ReadAllText(htmlPath);

            // Reemplaza logo_colmillos.png por tu logo del SITE si lo tienes en esa carpeta
            string cssRelativo = "../Static/Css/mantenimientoAula.css";
            string logoUptRelativo = "../Static/Images/logo_upt.png";
            string logoSiteRelativo = "../Static/Images/logo_colmillos.png"; // <-- Cambia el nombre si subes el logo de SITE

            int aulas = edificio.CantidadAulas > 0 ? edificio.CantidadAulas : 1;

            // 1. Generamos los números (1, 2, 3... N)
            string celdasNumeros = ConstruirCabeceraAulas(aulas);

            // 2. Generamos las filas con sus respectivos cuadritos vacíos
            string filasMatriz = ConstruirFilasMatriz(aulas);

            // 3. Reemplazos
            string htmlFinal = htmlTemplate
                .Replace("@LOGO_UPT", logoUptRelativo)
                .Replace("@RUTA_CSS", cssRelativo)
                .Replace("@LOGO_SITE", logoSiteRelativo)
                .Replace("@TIPO_MANTENIMIENTO", mantenimiento.TipoMantenimiento.ToUpper())
                .Replace("@RESPONSABLE_NOMBRE", edificio.ResponsableNombre.ToUpper())
                .Replace("@FECHA", mantenimiento.FechaEjecucion)
                .Replace("@EDIFICIO_NOMBRE", edificio.Nombre.ToUpper())
                .Replace("@CANTIDAD_AULAS", aulas.ToString())
                .Replace("@CELDAS_NUMEROS_AULAS", celdasNumeros)
                .Replace("@COLSPAN_TOTAL", (aulas + 1).ToString()) // +1 por la columna del nombre de la actividad
                .Replace("@FILAS_TAREAS", filasMatriz)
                .Replace("@OBSERVACIONES", mantenimiento.Observaciones);

            // 4. Generar Archivos
            string nombreArchivoHtml = $"Temp_Matrix_{Guid.NewGuid()}.html";
            string rutaHtmlTemp = Path.Combine(_htmlTempPath, nombreArchivoHtml);
            File.WriteAllText(rutaHtmlTemp, htmlFinal);

            string nombreEdifSafe = edificio.Nombre.Replace(" ", "_");
            string nombrePdf = $"Checklist_{nombreEdifSafe}_{mantenimiento.FechaEjecucion}.pdf";
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

        // --- MAGIA DE LA MATRIZ ---

        private string ConstruirCabeceraAulas(int cantidadAulas)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= cantidadAulas; i++)
            {
                // Genera <td>1</td> <td>2</td> ...
                sb.Append($"<td>{i}</td>");
            }
            return sb.ToString();
        }

        private string ConstruirFilasMatriz(int cantidadAulas)
        {
            StringBuilder sb = new StringBuilder();

            var actividades = new List<string> {
                "Limpieza de proyector",
                "Limpieza de bocina",
                "Ajustar posición del proyector",
                "Ajustar posición de la bocina",
                "Revisión del nodo de internet",
                "Limpieza de cámara de videoconferencia"
            };

            foreach (var actividad in actividades)
            {
                sb.Append("<tr>");
                // Columna 1: Nombre de la actividad
                sb.Append($"<td class='task-name'>{actividad}</td>");

                // Columnas 2 al N: Cuadritos vacíos para palomear
                for (int i = 1; i <= cantidadAulas; i++)
                {
                    sb.Append("<td class='empty-cell'></td>");
                }
                sb.Append("</tr>");
            }

            return sb.ToString();
        }
    }
}
