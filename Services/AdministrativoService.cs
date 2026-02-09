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
    public class AdministrativoService
    {

        private readonly IAdministrativoRepository _repo;

        public AdministrativoService() : this(new AdministrativoRepository())
        {
        }

        public AdministrativoService(IAdministrativoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Administrativo> ObtenerAdministrativos()
        {
            return _repo.GetAll();
        }

        public Administrativo CrearAdministrativo(string nombreCompleto, string? puesto, int areaId)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto))
                throw new ArgumentException("El nombre del administrativo es obligatorio.", nameof(nombreCompleto));

            if (areaId <= 0)
                throw new ArgumentException("Debe seleccionar un área válida.", nameof(areaId));

            var admin = new Administrativo
            {
                NombreCompleto = nombreCompleto.Trim(),
                Puesto = string.IsNullOrWhiteSpace(puesto) ? null : puesto.Trim(),
                AreaId = areaId
            };

            _repo.Add(admin);
            return admin;
        }

        public void ActualizarAdministrativo(Administrativo admin)
        {
            if (admin.Id <= 0)
                throw new ArgumentException("El Id del administrativo no es válido.", nameof(admin));

            if (string.IsNullOrWhiteSpace(admin.NombreCompleto))
                throw new ArgumentException("El nombre del administrativo es obligatorio.", nameof(admin));

            if (admin.AreaId <= 0)
                throw new ArgumentException("Debe seleccionar un área válida.", nameof(admin));

            admin.NombreCompleto = admin.NombreCompleto.Trim();
            admin.Puesto = string.IsNullOrWhiteSpace(admin.Puesto)
                ? null
                : admin.Puesto.Trim();

            _repo.Update(admin);
        }

        public void EliminarAdministrativo(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id del administrativo no es válido.", nameof(id));

            _repo.Delete(id);
        }

    }
}
