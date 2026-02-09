using System;
using System.Collections.Generic;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;

namespace AppEscritorioUPT.Services
{
    public class AreaService
    {
        private readonly IAreaRepository _areaRepository;

        // Para no complicarnos aún con inyección de dependencias,
        // instanciamos el repositorio aquí.
        public AreaService() : this(new AreaRepository())
        {
        }

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public IEnumerable<Area> ObtenerAreas()
        {
            return _areaRepository.GetAll();
        }

        public Area? ObtenerAreaPorId(int id)
        {
            return _areaRepository.GetById(id);
        }

        public Area CrearArea(string nombre, string? descripcion, string nomenclatura)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del área es obligatorio.", nameof(nombre));

            if (string.IsNullOrWhiteSpace(nomenclatura))
                throw new ArgumentException("La nomenclatura de inventario es obligatoria.", nameof(nomenclatura));

            var area = new Area
            {
                Nombre = nombre.Trim(),
                Descripcion = string.IsNullOrWhiteSpace(descripcion)
                    ? null
                    : descripcion.Trim(),
                NomenclaturaInventario = nomenclatura.Trim().ToUpper()
            };

            _areaRepository.Add(area);
            return area;
        }

        public void ActualizarArea(Area area)
        {
            if (area.Id <= 0)
                throw new ArgumentException("El Id del área no es válido.", nameof(area));

            if (string.IsNullOrWhiteSpace(area.Nombre))
                throw new ArgumentException("El nombre del área es obligatorio.", nameof(area));

            if (string.IsNullOrWhiteSpace(area.NomenclaturaInventario))
                throw new ArgumentException("La nomenclatura de inventario es obligatoria.", nameof(area));

            area.Nombre = area.Nombre.Trim();
            area.Descripcion = string.IsNullOrWhiteSpace(area.Descripcion)
                ? null
                : area.Descripcion.Trim();
            area.NomenclaturaInventario = area.NomenclaturaInventario.Trim().ToUpper();

            _areaRepository.Update(area);
        }

        public void EliminarArea(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id del área no es válido.", nameof(id));

            _areaRepository.Delete(id);
        }
    }
}
