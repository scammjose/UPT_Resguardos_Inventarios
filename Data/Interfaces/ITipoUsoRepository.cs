using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface ITipoUsoRepository
    {
        IEnumerable<TipoUso> GetAll();
        TipoUso? GetById(int id);
        void Add(TipoUso tipoUso);
        void Update(TipoUso tipoUso);
        void Delete(int id);
    }
}
