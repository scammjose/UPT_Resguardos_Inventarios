using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IEdificioRepository
    {
        IEnumerable<Edificio> GetAll();
        Edificio? GetById(int id);
        void Add(Edificio edificio);
        void Update(Edificio edificio);
        void Delete(int id);
    }
}
