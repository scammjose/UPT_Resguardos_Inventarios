using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class EstadisticasService
    {
        private readonly IEstadisticasRepository _estadisticasRepository;

        // Constructor por defecto instanciando el repositorio concreto
        public EstadisticasService() : this(new EstadisticasRepository())
        {
        }

        // Constructor para inyección de dependencias
        public EstadisticasService(IEstadisticasRepository estadisticasRepository)
        {
            _estadisticasRepository = estadisticasRepository;
        }


        public int ObtenerTotalAdministrativos()
        {
            return _estadisticasRepository.GetTotalAdministrativos();
        }

        public int ObtenerTotalEquipos()
        {
            return _estadisticasRepository.GetTotalEquipos();
        }

        public int ObtenerTotalResguardos()
        {
            return _estadisticasRepository.GetTotalResguardos();
        }


        public Dictionary<string, int> ObtenerAdministrativosPorArea()
        {
            return _estadisticasRepository.GetAdministrativosPorArea();
        }

        public Dictionary<string, int> ObtenerEquiposPorTipo()
        {
            return _estadisticasRepository.GetEquiposPorTipo();
        }

        public Dictionary<string, int> ObtenerEquiposPorArea()
        {
            return _estadisticasRepository.GetEquiposPorArea();
        }

        public Dictionary<string, int> ObtenerResguardosPorAnio()
        {
            return _estadisticasRepository.GetResguardosPorAnio();
        }

        public Dictionary<string, int> ObtenerImpresorasPorTipoImpresion()
        {
            return _estadisticasRepository.GetImpresorasPorTipoImpresion();
        }

    }
}
