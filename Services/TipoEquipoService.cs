using AppEscritorioUPT.Data;
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
    public class TipoEquipoService
    {

        private readonly ITipoEquipoRepository _repo;

        public TipoEquipoService() : this(new TipoEquipoRepository())
        {
        }

        public TipoEquipoService(ITipoEquipoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<TipoEquipo> ObtenerTipos()
        {
            return _repo.GetAll();
        }

        public TipoEquipo CrearTipo(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del tipo de equipo es obligatorio.", nameof(nombre));

            var tipo = new TipoEquipo
            {
                Nombre = nombre.Trim()
            };

            _repo.Add(tipo);
            return tipo;
        }

        public void ActualizarTipo(TipoEquipo tipo)
        {
            if (tipo.Id <= 0)
                throw new ArgumentException("El Id del tipo de equipo no es válido.", nameof(tipo));

            if (string.IsNullOrWhiteSpace(tipo.Nombre))
                throw new ArgumentException("El nombre del tipo de equipo es obligatorio.", nameof(tipo));

            tipo.Nombre = tipo.Nombre.Trim();

            _repo.Update(tipo);
        }

        public void EliminarTipo(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id del tipo de equipo no es válido.", nameof(id));

            _repo.Delete(id);
        }

    }
}
