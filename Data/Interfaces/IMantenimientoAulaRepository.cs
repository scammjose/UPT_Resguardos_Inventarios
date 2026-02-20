using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IMantenimientoAulaRepository
    {
        IEnumerable<MantenimientoAula> GetAll();
        IEnumerable<MantenimientoAula> GetByEdificio(int edificioId);
        MantenimientoAula? GetById(int id);
        void Add(MantenimientoAula mantenimiento);
        void Update(MantenimientoAula mantenimiento);
        void Delete(int id);
    }
}
