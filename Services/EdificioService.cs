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
    public class EdificioService
    {
        private readonly IEdificioRepository _repository;

        public EdificioService()
        {
            // Instanciamos el repositorio que acabas de crear
            _repository = new EdificioRepository();
        }

        public IEnumerable<Edificio> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        public void GuardarEdificio(Edificio edificio)
        {
            ValidarEdificio(edificio);

            if (edificio.Id == 0)
            {
                _repository.Add(edificio);
            }
            else
            {
                _repository.Update(edificio);
            }
        }

        public void EliminarEdificio(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de edificio inválido.");

            // Aquí podríamos agregar lógica futura para verificar si el edificio 
            // ya tiene mantenimientos asignados antes de borrarlo.
            _repository.Delete(id);
        }

        private void ValidarEdificio(Edificio edificio)
        {
            if (string.IsNullOrWhiteSpace(edificio.Nombre))
                throw new ArgumentException("El nombre del edificio es obligatorio.");

            if (edificio.CantidadAulas <= 0)
                throw new ArgumentException("La cantidad de aulas debe ser mayor a cero.");

            if (edificio.ResponsableSistemasId <= 0)
                throw new ArgumentException("Debe seleccionar un Responsable de Sistemas válido.");
        }
    }
}
