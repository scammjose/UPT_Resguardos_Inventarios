using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class EquipoConsumibleService
    {
        private readonly IEquipoConsumibleRepository _repo;

        public EquipoConsumibleService()
        {
            _repo = new EquipoConsumibleRepository();
        }

        public IEnumerable<Consumible> ObtenerConsumiblesCompatibles(int equipoId)
        {
            if (equipoId <= 0) return new List<Consumible>();
            return _repo.ObtenerConsumiblesPorEquipo(equipoId);
        }

        public void AsignarTonerAImpresora(int equipoId, int consumibleId)
        {
            if (equipoId <= 0 || consumibleId <= 0)
                throw new ArgumentException("Debe seleccionar un equipo y un consumible válidos.");

            if (_repo.ExisteRelacion(equipoId, consumibleId))
                throw new InvalidOperationException("Esta relación de compatibilidad ya existe.");

            _repo.AsignarCompatibilidad(equipoId, consumibleId);
        }

        public void QuitarRelacion(int equipoId, int consumibleId)
        {
            _repo.QuitarCompatibilidad(equipoId, consumibleId);
        }
    }
}
