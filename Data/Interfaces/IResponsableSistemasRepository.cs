using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscritorioUPT.Domain;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IResponsableSistemasRepository
    {
        IEnumerable<ResponsableSistemas> GetAll();
        ResponsableSistemas? GetById(int id);
        void Add(int administrativoId);
        void Delete(int id);
        bool ExistsByAdministrativo(int administrativoId);
    }
}
