using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IAdministrativoRepository
    {
        IEnumerable<Administrativo> GetAll();
        Administrativo? GetById(int id);
        int Add(Administrativo admin);
        void Update(Administrativo admin);
        void Delete(int id);
    }
}
