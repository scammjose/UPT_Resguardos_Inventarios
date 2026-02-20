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
    internal class MantenimientoAulaService
    {
        private readonly IMantenimientoAulaRepository _repository;

        public MantenimientoAulaService()
        {
            _repository = new MantenimientoAulaRepository();
        }

        public IEnumerable<MantenimientoAula> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        public IEnumerable<MantenimientoAula> ObtenerPorEdificio(int edificioId)
        {
            return _repository.GetByEdificio(edificioId);
        }

        public void GuardarMantenimiento(MantenimientoAula mantenimiento)
        {
            Validar(mantenimiento);

            if (mantenimiento.Id == 0)
                _repository.Add(mantenimiento);
            else
                _repository.Update(mantenimiento);
        }

        public void EliminarMantenimiento(int id)
        {
            if (id <= 0) throw new ArgumentException("ID de mantenimiento inválido.");
            _repository.Delete(id);
        }

        private void Validar(MantenimientoAula m)
        {
            if (m.EdificioId <= 0)
                throw new ArgumentException("Debe seleccionar un edificio válido.");

            if (string.IsNullOrWhiteSpace(m.FechaEjecucion))
                throw new ArgumentException("La fecha de ejecución es obligatoria.");

            if (string.IsNullOrWhiteSpace(m.TipoMantenimiento))
                throw new ArgumentException("Debe especificar el tipo de mantenimiento (Predictivo o Correctivo).");
        }
    }
}
