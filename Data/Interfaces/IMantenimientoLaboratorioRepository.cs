using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IMantenimientoLaboratorioRepository
    {
        IEnumerable<MantenimientoLaboratorio> GetAll();
        IEnumerable<MantenimientoLaboratorio> GetByLaboratorio(int laboratorioId);
        MantenimientoLaboratorio? GetById(int id);
        void Add(MantenimientoLaboratorio mantenimiento);
        void Update(MantenimientoLaboratorio mantenimiento);
        void Delete(int id);
    }
}
