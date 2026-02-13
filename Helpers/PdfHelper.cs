using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace AppEscritorioUPT.Helpers
{
    public static class PdfHelper
    {
        public static void HtmlToPdf(string htmlPath, string pdfPath)
        {
            // Ruta al wkhtmltopdf.exe dentro de Tools
            var exePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Tools",
                "wkhtmltopdf",
                "wkhtmltopdf.exe");

            if (!File.Exists(exePath))
            {
                throw new FileNotFoundException(
                    $"No se encontró wkhtmltopdf en: {exePath}");
            }

            // Aseguramos carpeta destino
            var pdfDir = Path.GetDirectoryName(pdfPath);
            if (!string.IsNullOrWhiteSpace(pdfDir) && !Directory.Exists(pdfDir))
            {
                Directory.CreateDirectory(pdfDir);
            }

            // Parámetro --enable-local-file-access para que pueda leer CSS/imagenes locales
            var args = $"--enable-local-file-access \"{htmlPath}\" \"{pdfPath}\"";

            var psi = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(psi);
            process!.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception($"wkhtmltopdf terminó con código {process.ExitCode}.");
            }
        }
    }
}
