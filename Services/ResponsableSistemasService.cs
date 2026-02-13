using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;

namespace AppEscritorioUPT.Services
{
    public class ResponsableSistemasService
    {
        private readonly IResponsableSistemasRepository _repo;

        public ResponsableSistemasService()
        {
            _repo = new ResponsableSistemasRepository();
        }

        public IEnumerable<ResponsableSistemas> ObtenerResponsables()
        {
            return _repo.GetAll();
        }

        public void AgregarResponsable(int administrativoId)
        {
            if (administrativoId <= 0)
                throw new ArgumentException("Debe seleccionar un administrativo válido.", nameof(administrativoId));

            if (_repo.ExistsByAdministrativo(administrativoId))
                throw new InvalidOperationException("Ese administrativo ya está registrado como responsable de sistemas.");

            _repo.Add(administrativoId);
        }

        public void EliminarResponsable(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id de responsable inválido.", nameof(id));

            _repo.Delete(id);
        }
    }
}
