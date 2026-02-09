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
    public class EquipoService
    {
        private readonly IEquipoRepository _equipoRepo;

        public EquipoService() : this(new EquipoRepository())
        {
        }

        public EquipoService(IEquipoRepository equipoRepo)
        {
            _equipoRepo = equipoRepo;
        }

        public IEnumerable<Equipo> ObtenerEquipos()
        {
            return _equipoRepo.GetAll();
        }

        // Aquí puedes dejar CrearEquipo sin pedir el código,
        // y usar el que genere este método.
        public void CrearEquipo(Equipo equipo)
        {
            if (equipo.TipoEquipoId <= 0)
                throw new ArgumentException("Debe seleccionar un tipo de equipo válido.", nameof(equipo));

            // Normalizar textos
            equipo.Marca = string.IsNullOrWhiteSpace(equipo.Marca) ? null : equipo.Marca.Trim();
            equipo.Modelo = string.IsNullOrWhiteSpace(equipo.Modelo) ? null : equipo.Modelo.Trim();
            equipo.NumeroSerie = string.IsNullOrWhiteSpace(equipo.NumeroSerie) ? null : equipo.NumeroSerie.Trim();
            equipo.DireccionIp = string.IsNullOrWhiteSpace(equipo.DireccionIp) ? null : equipo.DireccionIp.Trim();

            _equipoRepo.Add(equipo);
        }

        // ActualizarEquipo y EliminarEquipo pueden quedarse igual,
        // solo que ya no permitiremos editar el código desde el UI.
        public void ActualizarEquipo(Equipo eq)
        {
            if (eq.Id <= 0)
                throw new ArgumentException("El Id del equipo no es válido.", nameof(eq));

            if (eq.TipoEquipoId <= 0)
                throw new ArgumentException("Debe seleccionar un tipo de equipo válido.", nameof(eq));

            eq.Marca = string.IsNullOrWhiteSpace(eq.Marca) ? null : eq.Marca.Trim();
            eq.Modelo = string.IsNullOrWhiteSpace(eq.Modelo) ? null : eq.Modelo.Trim();
            eq.NumeroSerie = string.IsNullOrWhiteSpace(eq.NumeroSerie) ? null : eq.NumeroSerie.Trim();
            eq.DireccionIp = string.IsNullOrWhiteSpace(eq.DireccionIp) ? null : eq.DireccionIp.Trim();

            _equipoRepo.Update(eq);
        }

        public void EliminarEquipo(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id del equipo no es válido.", nameof(id));

            _equipoRepo.Delete(id);
        }
    }
}
