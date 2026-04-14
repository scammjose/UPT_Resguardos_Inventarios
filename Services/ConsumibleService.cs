using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class ConsumibleService
    {
        private readonly IConsumibleRepository _consumibleRepo;

        // Inyectamos el repositorio (o lo instanciamos directo si no usas inyección de dependencias)
        public ConsumibleService()
        {
            _consumibleRepo = new ConsumibleRepository();
        }

        public IEnumerable<Consumible> ObtenerTodos()
        {
            return _consumibleRepo.ObtenerTodos();
        }

        public Consumible? ObtenerPorId(int id)
        {
            return _consumibleRepo.ObtenerPorId(id);
        }

        public void Agregar(Consumible consumible)
        {
            ValidarDatos(consumible);

            if (consumible.StockActual < 0)
                throw new ArgumentException("El stock inicial no puede ser negativo.");

            if (consumible.StockMinimo < 0)
                throw new ArgumentException("El stock mínimo no puede ser negativo.");

            _consumibleRepo.Agregar(consumible);
        }

        public void Actualizar(Consumible consumible)
        {
            if (consumible.Id <= 0)
                throw new ArgumentException("ID de consumible inválido.");

            ValidarDatos(consumible);
            _consumibleRepo.Actualizar(consumible);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de consumible inválido.");

            // Opcional a futuro: Aquí podríamos verificar si el tóner ya tiene "Entregas" 
            // registradas antes de dejarlo borrar, para proteger el historial.
            _consumibleRepo.Eliminar(id);
        }

        // ===== MÉTODOS ESPECIALES DE INVENTARIO =====

        /// <summary>
        /// Se usa cuando se compran nuevos consumibles y entran al almacén.
        /// </summary>
        public void RegistrarEntradaAlmacen(int consumibleId, int cantidadComprada)
        {
            if (cantidadComprada <= 0)
                throw new ArgumentException("La cantidad a ingresar debe ser mayor a cero.");

            _consumibleRepo.ActualizarStock(consumibleId, cantidadComprada);
        }

        /// <summary>
        /// Se usa cuando se instala un consumible en una impresora.
        /// Valida que haya suficiente stock antes de restarlo.
        /// </summary>
        public void DescontarStockPorEntrega(int consumibleId, int cantidadEntregada)
        {
            if (cantidadEntregada <= 0)
                throw new ArgumentException("La cantidad a entregar debe ser mayor a cero.");

            var consumible = _consumibleRepo.ObtenerPorId(consumibleId);
            if (consumible == null)
                throw new ArgumentException("El consumible especificado no existe.");

            if (consumible.StockActual < cantidadEntregada)
                throw new InvalidOperationException($"No hay suficiente stock. Solicitados: {cantidadEntregada}, Disponibles: {consumible.StockActual}");

            // Mandamos la cantidad en negativo para que el repositorio la reste
            _consumibleRepo.ActualizarStock(consumibleId, -cantidadEntregada);
        }

        // ===== MÉTODO DE VALIDACIÓN INTERNA =====
        private void ValidarDatos(Consumible consumible)
        {
            // Limpiamos espacios en blanco
            consumible.Modelo = consumible.Modelo?.Trim() ?? string.Empty;
            consumible.Tipo = consumible.Tipo?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(consumible.Modelo))
                throw new ArgumentException("El Modelo del consumible es obligatorio (Ej. Tóner HP 85A).");

            if (string.IsNullOrWhiteSpace(consumible.Tipo))
                throw new ArgumentException("Debe especificar el Tipo de consumible (Ej. Tóner, Tinta, Tambor).");
        }

        public IEnumerable<ReporteConsumibleDto> ObtenerReporteGeneral()
        {
            return _consumibleRepo.ObtenerReporteGeneral();
        }

        public string GenerarYGuardarReportePdf()
        {
            // 1. Obtenemos los datos
            var datos = _consumibleRepo.ObtenerReporteGeneral().ToList();

            if (datos.Count == 0)
            {
                // Lanzamos una excepción de negocio controlada
                throw new InvalidOperationException("No hay datos en el inventario para generar el reporte.");
            }

            // 2. Generamos el HTML
            string html = PdfReportHelper.GenerarHtmlInventario(datos);
            string rutaHtml = Path.Combine(Path.GetTempPath(), "TempReporteInventario.html");
            File.WriteAllText(rutaHtml, html);

            // 3. Obtenemos rutas seguras
            string carpetaDestino = DocumentPathHelper.ObtenerRutaReportesConsumibles();
            string nombreArchivo = $"Reporte_Consumibles_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
            string rutaPdf = Path.Combine(carpetaDestino, nombreArchivo);

            // 4. Convertimos a PDF
            PdfHelper.HtmlToPdf(rutaHtml, rutaPdf, true); // true = Landscape

            // 5. Limpiamos la basura (borramos el HTML temporal para no dejar rastro)
            if (File.Exists(rutaHtml)) File.Delete(rutaHtml);

            // Devolvemos la ruta donde quedó el PDF final
            return rutaPdf;
        }

        public string GenerarYGuardarReporteComprasPdf()
        {
            // 1. Obtenemos los datos (¡Ahora usamos el de compras!)
            var datos = _consumibleRepo.ObtenerReporteParaCompras().ToList();

            if (datos.Count == 0)
                throw new InvalidOperationException("No hay datos en el inventario para generar el reporte de compras.");

            // 2. Generamos el HTML (¡Usamos la plantilla de compras!)
            string html = PdfReportHelper.GenerarHtmlCompras(datos);
            string rutaHtml = Path.Combine(Path.GetTempPath(), "TempReporteCompras.html");
            File.WriteAllText(rutaHtml, html);

            // 3. Obtenemos rutas seguras
            string carpetaDestino = DocumentPathHelper.ObtenerRutaReportesConsumibles();
            // Le ponemos un nombre diferente para no sobreescribir el de auditoría
            string nombreArchivo = $"Requisicion_Compras_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
            string rutaPdf = Path.Combine(carpetaDestino, nombreArchivo);

            // 4. Convertimos a PDF (Formato Horizontal)
            PdfHelper.HtmlToPdf(rutaHtml, rutaPdf, true);

            // 5. Limpiamos la basura
            if (File.Exists(rutaHtml)) File.Delete(rutaHtml);

            return rutaPdf;
        }
    }
}
