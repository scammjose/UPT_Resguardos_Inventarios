using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class TipoUsoService
    {
        private readonly TipoUsoRepository _repository;

        public TipoUsoService()
        {
            _repository = new TipoUsoRepository();
        }

        public IEnumerable<TipoUso> ObtenerTiposUso() => _repository.GetAll();

        public void Guardar(TipoUso tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo.Nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            tipo.Nombre = tipo.Nombre.Trim().ToUpper();

            if (tipo.Id == 0)
                _repository.Add(tipo);
            else
                _repository.Update(tipo);
        }

        public void Eliminar(int id)
        {
            if (id <= 0) throw new ArgumentException("Seleccione un registro válido.");

            // Regla de negocio: Evitar que borren el valor por defecto
            if (id == 1) throw new InvalidOperationException("No se puede eliminar la etiqueta 'USO ADMINISTRATIVO' porque es la predeterminada del sistema.");

            _repository.Delete(id);
        }
    }
}
