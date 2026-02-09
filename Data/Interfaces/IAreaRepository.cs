using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppEscritorioUPT.Domain;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IAreaRepository
    {
        IEnumerable<Area> GetAll();
        Area? GetById(int id);
        int Add(Area area);
        void Update(Area area);
        void Delete(int id);
    }
}
