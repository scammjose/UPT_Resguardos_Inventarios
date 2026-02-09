using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscritorioUPT.Domain;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IResguardoRepository
    {
        IEnumerable<Resguardo> GetAll();
        Resguardo? GetById(int id);
        int Add(Resguardo resguardo);
        void Update(Resguardo resguardo);
        void Delete(int id);

        string? ObtenerUltimoCodigoPorAreaYAnio(string nomenclaturaArea, int anio);
    }
}
