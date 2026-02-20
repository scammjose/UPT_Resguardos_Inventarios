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
    public class TipoMantenimientoService
    {
        private readonly ITipoMantenimientoRepository _repository;

        public TipoMantenimientoService()
        {
            _repository = new TipoMantenimientoRepository();
        }

        public IEnumerable<TipoMantenimiento> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        public TipoMantenimiento? ObtenerPorId(int id)
        {
            return _repository.GetById(id);
        }

        public void GuardarTipoMantenimiento(TipoMantenimiento tipo)
        {
            Validar(tipo);

            // Limpiamos espacios extra al principio o al final antes de guardar
            tipo.Nombre = tipo.Nombre.Trim();

            if (tipo.Id == 0)
            {
                _repository.Add(tipo);
            }
            else
            {
                _repository.Update(tipo);
            }
        }

        public void EliminarTipoMantenimiento(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de tipo de mantenimiento inválido.");

            // Si intentan borrar un Tipo que ya se usó en un checklist de Aulas, 
            // SQLite arrojará un error de Foreign Key (si configuraste la relación)
            // que atraparemos directamente en el Formulario para mostrar un mensaje amigable.
            _repository.Delete(id);
        }

        private void Validar(TipoMantenimiento tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo.Nombre))
                throw new ArgumentException("El nombre del tipo de mantenimiento es obligatorio.");

            // Usamos el método ExistsNombre para evitar duplicados como dos "Predictivo"
            if (_repository.ExistsNombre(tipo.Nombre.Trim(), tipo.Id))
                throw new ArgumentException($"Ya existe un tipo de mantenimiento con el nombre '{tipo.Nombre.Trim()}'.");
        }
    }
}
