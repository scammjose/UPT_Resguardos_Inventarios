using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscritorioUPT.Domain;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IEquipoRepository
    {
        IEnumerable<Equipo> GetAll();
        Equipo? GetById(int id);
        void Add(Equipo equipo);
        void Update(Equipo equipo);
        void Delete(int id);
    }
}
