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
    internal class MantenimientoLaboratorioService
    {
        private readonly IMantenimientoLaboratorioRepository _repository;

        public MantenimientoLaboratorioService()
        {
            _repository = new MantenimientoLaboratorioRepository();
        }

        public IEnumerable<MantenimientoLaboratorio> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        public IEnumerable<MantenimientoLaboratorio> ObtenerPorLaboratorio(int laboratorioId)
        {
            if (laboratorioId <= 0)
                throw new ArgumentException("ID de laboratorio inválido.");

            return _repository.GetByLaboratorio(laboratorioId);
        }

        public MantenimientoLaboratorio? ObtenerPorId(int id)
        {
            return _repository.GetById(id);
        }

        public void GuardarMantenimiento(MantenimientoLaboratorio mantenimiento)
        {
            Validar(mantenimiento);

            if (mantenimiento.Observaciones != null)
                mantenimiento.Observaciones = mantenimiento.Observaciones.Trim();

            if (mantenimiento.Id == 0)
            {
                _repository.Add(mantenimiento);
            }
            else
            {
                _repository.Update(mantenimiento);
            }
        }

        public void EliminarMantenimiento(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de mantenimiento inválido.");

            _repository.Delete(id);
        }

        private void Validar(MantenimientoLaboratorio m)
        {
            if (m.LaboratorioId <= 0)
                throw new ArgumentException("Debe seleccionar un laboratorio válido.");

            if (string.IsNullOrWhiteSpace(m.FechaEjecucion))
                throw new ArgumentException("La fecha de ejecución es obligatoria.");

            if (m.TipoMantenimientoId <= 0)
                throw new ArgumentException("Debe seleccionar un tipo de mantenimiento válido.");
        }
    }
}
