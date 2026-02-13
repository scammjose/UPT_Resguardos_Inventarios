using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Domain.Reports;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IResguardoRepository
    {
        IEnumerable<Resguardo> GetAll();
        Resguardo? GetById(int id);
        void Add(Resguardo resguardo);
        void Update(Resguardo resguardo);
        void Delete(int id);

        // Para generación de código de inventario
        string? GetUltimoCodigoInventarioPorPrefijo(string prefijo);

        //ResguardoReportModel? GetByIdForReport(int id);
    }
}
