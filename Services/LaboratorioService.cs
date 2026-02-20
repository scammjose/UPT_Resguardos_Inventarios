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
    public class LaboratorioService
    {
        private readonly ILaboratorioRepository _repository;

        public LaboratorioService()
        {
            _repository = new LaboratorioRepository();
        }

        public IEnumerable<Laboratorio> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        public Laboratorio? ObtenerPorId(int id)
        {
            return _repository.GetById(id);
        }

        public void GuardarLaboratorio(Laboratorio laboratorio)
        {
            Validar(laboratorio);

            laboratorio.Nombre = laboratorio.Nombre.Trim();

            if (laboratorio.Id == 0)
            {
                _repository.Add(laboratorio);
            }
            else
            {
                _repository.Update(laboratorio);
            }
        }

        public void EliminarLaboratorio(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de laboratorio inválido.");

            _repository.Delete(id);
        }

        private void Validar(Laboratorio lab)
        {
            if (string.IsNullOrWhiteSpace(lab.Nombre))
                throw new ArgumentException("El nombre del laboratorio es obligatorio.");

            if (lab.EdificioId <= 0)
                throw new ArgumentException("Debe seleccionar un edificio válido.");

            if (lab.AreaId <= 0)
                throw new ArgumentException("Debe seleccionar un área válida.");

            if (lab.ResponsableSistemasId <= 0)
                throw new ArgumentException("Debe seleccionar un responsable de sistemas válido.");

            if (lab.CantidadEquipos < 0)
                throw new ArgumentException("La cantidad de equipos no puede ser negativa.");
        }
    }
}
