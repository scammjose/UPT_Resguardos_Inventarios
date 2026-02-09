using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscritorioUPT.Domain;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface ITipoEquipoRepository
    {
        IEnumerable<TipoEquipo> GetAll();
        TipoEquipo? GetById(int id);
        int Add(TipoEquipo tipo);
        void Update(TipoEquipo tipo);
        void Delete(int id);
    }
}
