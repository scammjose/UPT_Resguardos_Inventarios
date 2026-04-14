using AppEscritorioUPT.Data.Dto;
using System.Text;

namespace AppEscritorioUPT.Helpers
{
    public static class PdfReportHelper
    {
        public static string GenerarHtmlInventario(List<ReporteConsumibleDto> datos)
        {
            var sb = new StringBuilder();

            // 1. EL DISEÑO (CSS INSTITUCIONAL UPT) Y ENCABEZADO
            sb.Append(@"
            <!DOCTYPE html>
            <html lang='es'>
            <head>
                <meta charset='UTF-8'>
                <style>
                    /* Gris institucional para el texto general */
                    body { font-family: 'Segoe UI', Arial, sans-serif; color: #39393a; margin: 20px; }
                    
                    /* Dorado institucional para la línea divisoria del encabezado */
                    .header { text-align: center; margin-bottom: 30px; border-bottom: 3px solid #a0825a; padding-bottom: 10px; }
                    
                    /* Guinda institucional para el título principal */
                    .header h1 { color: #a02142; margin: 0; font-size: 24px; text-transform: uppercase; font-weight: 800; }
                    
                    /* Gris institucional para los subtítulos */
                    .header p { color: #39393a; margin: 5px 0 0 0; font-size: 14px; font-weight: 600; }
                    
                    table { width: 100%; border-collapse: collapse; font-size: 12px; margin-top: 15px; }
                    
                    /* Crema institucional para los bordes de la tabla */
                    th, td { border: 1px solid #dcc6a2; padding: 8px; text-align: center; }
                    
                    /* Guinda para el fondo de las cabeceras con texto blanco */
                    th { background-color: #a02142; color: #ffffff; font-weight: bold; text-transform: uppercase; letter-spacing: 0.5px; }
                    
                    /* Usamos el Guinda como color de alerta (ya que es un tono de rojo oscuro) */
                    .danger { color: #a02142; font-weight: bold; font-size: 13px; }
                    
                    /* Un fondo súper tenue (tint de guinda) para destacar visualmente el stock bajo */
                    .danger-bg { background-color: #fdf2f4; }
                    
                    /* Fondo ligeramente diferente para las celdas fusionadas de la máquina */
                    .machine-cell { vertical-align: middle; background-color: #faf9f6; font-weight: bold; border-right: 2px solid #a0825a; }
                </style>
            </head>
            <body>
                <div class='header'>
                    <h1>Universidad Politécnica de Tecámac</h1>
                    <p>REPORTE GLOBAL DE INVENTARIO Y COMPATIBILIDAD DE CONSUMIBLES</p>
                    <p style='font-weight: normal;'>Fecha de emisión: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + @"</p>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th>Área</th>
                            <th>Responsable</th>
                            <th>Impresora</th>
                            <th>S/N</th>
                            <th>Tóner / Tinta</th>
                            <th>Color</th>
                            <th>Stock</th>
                        </tr>
                    </thead>
                    <tbody>");

            // 2. AGRUPAMOS LOS DATOS (El efecto Excel)
            var datosAgrupados = datos.GroupBy(d => new
            {
                d.AreaNombre,
                d.ResponsableNombre,
                d.MarcaEquipo,
                d.ModeloEquipo,
                d.SerieEquipo
            });

            // 3. GENERAMOS LAS FILAS CON ROWSPAN
            foreach (var grupo in datosAgrupados)
            {
                int rowSpan = grupo.Count();
                bool primeraFila = true;

                foreach (var item in grupo)
                {
                    string clasePeligro = item.RequiereCompra ? "class='danger-bg danger'" : "";

                    sb.Append("<tr>");

                    // Solo imprimimos los datos de la máquina en la PRIMERA fila del grupo
                    if (primeraFila)
                    {
                        sb.Append($"<td class='machine-cell' rowspan='{rowSpan}'>{grupo.Key.AreaNombre}</td>");
                        sb.Append($"<td class='machine-cell' rowspan='{rowSpan}'>{grupo.Key.ResponsableNombre}</td>");
                        sb.Append($"<td class='machine-cell' rowspan='{rowSpan}'>{grupo.Key.MarcaEquipo} {grupo.Key.ModeloEquipo}</td>");
                        sb.Append($"<td class='machine-cell' rowspan='{rowSpan}'>{grupo.Key.SerieEquipo}</td>");
                        primeraFila = false;
                    }

                    // Imprimimos los consumibles en TODAS las filas
                    sb.Append($"<td>{item.ModeloConsumible}</td>");
                    sb.Append($"<td>{item.Color}</td>");
                    sb.Append($"<td {clasePeligro}>{item.StockActual}</td>");

                    sb.Append("</tr>");
                }
            }

            // 4. CERRAMOS EL HTML
            sb.Append(@"
                    </tbody>
                </table>
            </body>
            </html>");

            return sb.ToString();
        }

        public static string GenerarHtmlCompras(IEnumerable<dynamic> datos)
        {
            var sb = new StringBuilder();

            // Mismo CSS institucional que te pasé antes (Guinda, Gris, Dorado)
            sb.Append(@"
            <!DOCTYPE html><html lang='es'><head><meta charset='UTF-8'>
            <style>
                body { font-family: 'Segoe UI', Arial, sans-serif; color: #39393a; margin: 20px; }
                .header { text-align: center; margin-bottom: 30px; border-bottom: 3px solid #a0825a; padding-bottom: 10px; }
                .header h1 { color: #a02142; margin: 0; font-size: 24px; text-transform: uppercase; font-weight: 800; }
                .header p { color: #39393a; margin: 5px 0 0 0; font-size: 14px; font-weight: 600; }
                table { width: 100%; border-collapse: collapse; font-size: 12px; margin-top: 15px; }
                th, td { border: 1px solid #dcc6a2; padding: 8px; text-align: center; }
                th { background-color: #a02142; color: #ffffff; text-transform: uppercase; }
                .danger { color: #a02142; font-weight: bold; }
                .danger-bg { background-color: #fdf2f4; }
                .text-left { text-align: left; font-size: 11px; }
            </style></head><body>
            <div class='header'>
                <h1>Universidad Politécnica de Tecámac</h1>
                <p>REPORTE DE REQUISICIÓN DE COMPRAS (CONSUMIBLES)</p>
                <p style='font-weight: normal;'>Fecha: " + DateTime.Now.ToString("dd/MM/yyyy") + @"</p>
            </div>
            <table>
                <thead>
                    <tr>
                        <th>Tóner / Tinta</th>
                        <th>Color</th>
                        <th>Stock Actual</th>
                        <th>Mínimo</th>
                        <th>A Comprar</th>
                        <th>Equipos Destino (Justificación)</th>
                    </tr>
                </thead>
                <tbody>");

            foreach (var item in datos)
            {
                // Solo pintamos de alerta si realmente necesitamos comprar
                string alerta = item.Faltante > 0 ? "class='danger-bg danger'" : "";

                sb.Append("<tr>");
                sb.Append($"<td style='font-weight:bold;'>{item.ModeloConsumible}</td>");
                sb.Append($"<td>{item.Color}</td>");
                sb.Append($"<td>{item.StockActual}</td>");
                sb.Append($"<td>{item.StockMinimo}</td>");
                sb.Append($"<td {alerta}>{item.Faltante}</td>");
                sb.Append($"<td class='text-left'>{item.Equipos}</td>");
                sb.Append("</tr>");
            }

            sb.Append("</tbody></table></body></html>");
            return sb.ToString();
        }
    }
}
