using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface ITipoMantenimientoRepository
    {
        IEnumerable<TipoMantenimiento> GetAll();
        TipoMantenimiento? GetById(int id);
        void Add(TipoMantenimiento tipo);
        void Update(TipoMantenimiento tipo);
        void Delete(int id);
        bool ExistsNombre(string nombre, int idIgnorar = 0);
    }
}
