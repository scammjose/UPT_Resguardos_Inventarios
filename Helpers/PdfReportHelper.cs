using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Domain.Reports;
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

        public static string GenerarHtmlCompras(IEnumerable<dynamic> datos) // (Si usaste el DTO, cámbialo a IEnumerable<RequisicionCompraDto>)
        {
            var sb = new StringBuilder();

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
                        <th style='width: 100px;'>A Comprar</th>
                        <th>Equipos Destino (Justificación)</th>
                    </tr>
                </thead>
                <tbody>");

            foreach (var item in datos)
            {
                // NUEVO: Movimos la alerta al <tr> para pintar todo el renglón si hay faltante
                string alertaRow = item.Faltante > 0 ? "class='danger-bg'" : "";

                sb.Append($"<tr {alertaRow}>");
                sb.Append($"<td style='font-weight:bold;'>{item.ModeloConsumible}</td>");
                sb.Append($"<td>{item.Color}</td>");
                sb.Append($"<td>{item.StockActual}</td>");
                sb.Append($"<td>{item.StockMinimo}</td>");

                // NUEVO: Dejamos la celda completamente vacía para rellenar a lápiz
                sb.Append($"<td></td>");

                sb.Append($"<td class='text-left'>{item.Equipos}</td>");
                sb.Append("</tr>");
            }

            sb.Append("</tbody></table></body></html>");
            return sb.ToString();
        }

        public static string GenerarHtmlResguardoColectivo(List<ResguardoReportModel> equiposLote, string folioLote)
        {
            if (equiposLote == null || !equiposLote.Any()) return "";

            var sb = new StringBuilder();

            // Tomamos los datos del administrativo y características comunes de la primera máquina
            var responsable = equiposLote.First();
            int totalEquipos = equiposLote.Count;

            // Obtenemos el tipo de uso (Ej. "USO ESTUDIANTIL / KIOSCO")
            // Nota: Si esto sale en blanco, revisa la nota que te dejé debajo del código
            string tipoUso = string.IsNullOrEmpty(responsable.TipoUsoNombre) ? "USO GENERAL" : responsable.TipoUsoNombre;

            sb.Append(@"
            <!DOCTYPE html><html lang='es'><head><meta charset='UTF-8'>
            <style>
                body { font-family: 'Segoe UI', Arial, sans-serif; color: #39393a; margin: 30px; font-size: 13px; line-height: 1.5; }
                .header { text-align: center; margin-bottom: 20px; border-bottom: 3px solid #a0825a; padding-bottom: 10px; }
                .header h1 { color: #a02142; margin: 0; font-size: 22px; text-transform: uppercase; font-weight: 800; }
                .header h2 { color: #39393a; margin: 5px 0; font-size: 16px; text-transform: uppercase; }
                .folio-box { text-align: right; font-weight: bold; color: #a02142; margin-bottom: 20px; font-size: 14px; }
                
                .info-section { margin-bottom: 20px; text-align: justify; }
                .highlight { font-weight: bold; color: #000; }

                /* Tablas */
                table { width: 100%; border-collapse: collapse; margin-top: 5px; margin-bottom: 25px; font-size: 11px; }
                th, td { border: 1px solid #dcc6a2; padding: 6px; text-align: center; }
                th { background-color: #a02142; color: #ffffff; text-transform: uppercase; }
                
                .table-title { font-weight: bold; color: #a02142; font-size: 12px; margin-bottom: 0px; text-transform: uppercase;}

                .firmas-container { width: 100%; margin-top: 50px; text-align: center; page-break-inside: avoid; }
                .firma-box { display: inline-block; width: 45%; vertical-align: top; }
                .linea-firma { border-top: 1px solid #39393a; margin: 40px 20px 5px 20px; }
                .firma-nombre { font-weight: bold; font-size: 12px; text-transform: uppercase; }
                .firma-puesto { font-size: 11px; color: #666; }
            </style></head><body>
            
            <div class='header'>
                <h1>Universidad Politécnica de Tecámac</h1>
                <h2>RESPONSIVA DE EQUIPO DE CÓMPUTO - " + tipoUso + @"</h2>
            </div>
            
            <div class='folio-box'>FOLIO: " + folioLote + @"<br><span style='color:#39393a; font-size:12px; font-weight:normal;'>Fecha de emisión: " + DateTime.Now.ToString("dd/MM/yyyy") + @"</span></div>

            <div class='info-section'>
                Por medio del presente documento, se hace constar que el/la servidor(a) público(a) 
                <span class='highlight'>" + responsable.AdministrativoNombre + @"</span>, 
                adscrito(a) al área de <span class='highlight'>" + responsable.AreaNombre + @"</span>, 
                recibe bajo su entera responsabilidad un total de <span class='highlight'>" + totalEquipos + @"</span> equipo(s) 
                de cómputo/tecnológico para fines de actividades institucionales, descritos a continuación:
            </div>

            <div class='table-title'>Especificaciones Generales del Lote</div>
            <table>
                <thead>
                    <tr>
                        <th style='width: 20%;'>Tipo de Equipo</th>
                        <th style='width: 25%;'>Marca y Modelo</th>
                        <th style='width: 20%;'>Procesador</th>
                        <th style='width: 15%;'>Memoria RAM</th>
                        <th style='width: 20%;'>Almacenamiento</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style='font-weight:bold;'>" + responsable.TipoEquipoNombre + @"</td>
                        <td>" + responsable.EquipoMarca + " " + responsable.EquipoModelo + @"</td>
                        <td>" + (!string.IsNullOrWhiteSpace(responsable.Procesador) ? responsable.Procesador : "N/A") + @"</td>
                        <td>" + (!string.IsNullOrWhiteSpace(responsable.MemoriaRam) ? responsable.MemoriaRam : "N/A") + @"</td>
                        <td>" + (!string.IsNullOrWhiteSpace(responsable.DiscoDuro) ? responsable.DiscoDuro : "N/A") + @"</td>
                    </tr>
                </tbody>
            </table>

            <div class='table-title'>Detalle de Equipos Asignados</div>
            <table>
                <thead>
                    <tr>
                        <th style='width: 10%;'>#</th>
                        <th style='width: 35%;'>Código de Inventario UPT</th>
                        <th style='width: 30%;'>Número de Serie</th>
                        <th style='width: 25%;'>Dirección IP</th>
                    </tr>
                </thead>
                <tbody>");

            // Recorremos las máquinas del lote para la segunda tabla
            int contador = 1;
            foreach (var equipo in equiposLote)
            {
                // Si no tiene IP registrada, mostramos un pequeño texto por defecto
                string ip = !string.IsNullOrWhiteSpace(equipo.EquipoDireccionIp) ? equipo.EquipoDireccionIp : "DHCP / N/A";

                sb.Append("<tr>");
                sb.Append($"<td>{contador}</td>");
                sb.Append($"<td style='font-weight:bold;'>{equipo.CodigoInventario}</td>");
                sb.Append($"<td>{equipo.EquipoNumeroSerie}</td>");
                sb.Append($"<td>{ip}</td>");
                sb.Append("</tr>");
                contador++;
            }

            sb.Append(@"
                </tbody>
            </table>
            
            <div class='info-section' style='font-size: 11px; color: #555;'>
                * El usuario se compromete a dar un uso adecuado y exclusivo para las funciones de la Universidad. 
                Cualquier daño por negligencia, robo o extravío deberá ser reportado inmediatamente al área de Sistemas.
            </div>

            <div class='firmas-container'>
                <div class='firma-box'>
                    <div class='linea-firma'></div>
                    <div class='firma-nombre'>ENTREGA: Lic. Amador Delgadillo Lira</div>
                    <div class='firma-puesto'>Responsable de Sistemas</div>
                </div>
                <div class='firma-box'>
                    <div class='linea-firma'></div>
                    <div class='firma-nombre'>RECIBE DE CONFORMIDAD: " + responsable.AdministrativoNombre + @"</div>
                    <div class='firma-puesto'>" + responsable.AreaNombre + @"</div>
                </div>
            </div>

            </body></html>");

            return sb.ToString();
        }
    }
}
