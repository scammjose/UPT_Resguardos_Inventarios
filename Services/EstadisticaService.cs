using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class EstadisticaService
    {
        public DashboardEstadisticasDto ObtenerDashboard() => new EstadisticaRepository().ObtenerDatosDashboard();
    }
}
