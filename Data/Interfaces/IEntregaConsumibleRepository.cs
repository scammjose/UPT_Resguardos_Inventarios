using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IEntregaConsumibleRepository
    {
        // Para ver el historial de todo lo que se ha entregado
        IEnumerable<EntregaConsumible> ObtenerTodas();

        // El método estrella: Guarda el registro de a quién se le dio
        void Agregar(EntregaConsumible entrega);

        // Opcional: Para saber cuántos tóners se ha gastado una impresora específica
        IEnumerable<EntregaConsumible> ObtenerPorEquipo(int equipoId);
    }
}
