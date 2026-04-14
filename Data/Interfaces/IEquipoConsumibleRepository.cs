using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IEquipoConsumibleRepository
    {
        // Para saber qué tóners le quedan a una impresora específica
        IEnumerable<Consumible> ObtenerConsumiblesPorEquipo(int equipoId);

        // Para saber a qué impresoras les queda un tóner específico
        IEnumerable<Equipo> ObtenerEquiposPorConsumible(int consumibleId);

        void AsignarCompatibilidad(int equipoId, int consumibleId);
        void QuitarCompatibilidad(int equipoId, int consumibleId);

        bool ExisteRelacion(int equipoId, int consumibleId);
    }
}
