using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface ILaboratorioRepository
    {
        IEnumerable<Laboratorio> GetAll();
        Laboratorio? GetById(int id);
        void Add(Laboratorio laboratorio);
        void Update(Laboratorio laboratorio);
        void Delete(int id);
    }
}
