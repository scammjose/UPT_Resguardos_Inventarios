using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IConsumibleRepository
    {
        IEnumerable<Consumible> ObtenerTodos();
        Consumible? ObtenerPorId(int id);
        void Agregar(Consumible consumible);
        void Actualizar(Consumible consumible);
        void Eliminar(int id);

        // ¡Método estrella para el control de inventario!
        void ActualizarStock(int id, int cantidadCambio);
        IEnumerable<ReporteConsumibleDto> ObtenerReporteGeneral();
        IEnumerable<RequisicionCompraDto> ObtenerReporteParaCompras();
    }
}
