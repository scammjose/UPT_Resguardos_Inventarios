using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Data.Interfaces
{
    public interface IMantenimientoRepository
    {
        // CRUD Estándar
        IEnumerable<Mantenimiento> GetAll();
        Mantenimiento? GetById(int id);
        int Add(Mantenimiento mantenimiento);
        void Update(Mantenimiento mantenimiento);
        void Delete(int id);

        // Métodos específicos para la lógica de negocio
        IEnumerable<Mantenimiento> GetByAdministrativoId(int administrativoId); // Para ver el historial de alguien
        bool ExisteMantenimiento(int equipoId, string fecha); // Para evitar duplicados el mismo día
        IEnumerable<MantenimientoDetalleDto> GetDetalladoPorFecha(string fecha);
        IEnumerable<MantenimientoDetalleDto> GetByAdministrativoYFecha(int administrativoId, string fecha);
    }
}
