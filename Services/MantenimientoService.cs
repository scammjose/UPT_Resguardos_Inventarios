using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class MantenimientoService
    {
        private readonly MantenimientoRepository _mantenimientoRepository;
        private readonly ResguardoRepository _resguardoRepository;

        public MantenimientoService()
        {
            _mantenimientoRepository = new MantenimientoRepository();
            _resguardoRepository = new ResguardoRepository();
        }

        public int GenerarChecklistPorTipoEquipo(int tipoEquipoId, string fecha, string tipoMantenimiento)
        {
            // 1. Obtener todos los resguardos de ese TIPO de equipo
            var resguardosDelTipo = _resguardoRepository.GetByTipoEquipoId(tipoEquipoId);

            int contador = 0;

            foreach (var resguardo in resguardosDelTipo)
            {
                // Validación para no duplicar el mismo día
                if (_mantenimientoRepository.ExisteMantenimiento(resguardo.EquipoId, fecha))
                {
                    continue;
                }

                // 2. Crear el mantenimiento usando los datos DEL RESGUARDO
                var mantenimiento = new Mantenimiento
                {
                    EquipoId = resguardo.EquipoId,

                    // El administrativo que tiene el equipo actualmente
                    AdministrativoId = resguardo.AdministrativoId,

                    // El técnico que figura en el resguardo (según tu indicación)
                    ResponsableSistemasId = resguardo.ResponsableSistemasId,

                    Fecha = fecha,
                    Tipo = tipoMantenimiento,
                    Observaciones = "",
                    CreadoAutomaticamente = true
                };

                _mantenimientoRepository.Add(mantenimiento);
                contador++;
            }

            return contador;
        }

        public int GenerarChecklistPorAreaYTipo(int areaId, int tipoEquipoId, string fecha, string tipoMantenimiento)
        {
            // 1. Obtener resguardos filtrados por ÁREA y TIPO
            var resguardosFiltrados = _resguardoRepository.GetByAreaAndTipoEquipo(areaId, tipoEquipoId);

            int contador = 0;

            foreach (var resguardo in resguardosFiltrados)
            {
                // Validación anti-duplicados (Igual que antes)
                if (_mantenimientoRepository.ExisteMantenimiento(resguardo.EquipoId, fecha))
                {
                    continue;
                }

                var mantenimiento = new Mantenimiento
                {
                    EquipoId = resguardo.EquipoId,
                    AdministrativoId = resguardo.AdministrativoId,
                    ResponsableSistemasId = resguardo.ResponsableSistemasId,
                    Fecha = fecha,
                    Tipo = tipoMantenimiento,
                    // Agregamos una nota para distinguir que fue por Área
                    Observaciones = "",
                    CreadoAutomaticamente = true
                };

                _mantenimientoRepository.Add(mantenimiento);
                contador++;
            }

            return contador;
        }

        public IEnumerable<Mantenimiento> ObtenerHistorial()
        {
            return _mantenimientoRepository.GetAll();
        }

        public IEnumerable<MantenimientoDetalleDto> ObtenerHistorialPorFecha(string fecha)
        {
            return _mantenimientoRepository.GetDetalladoPorFecha(fecha);
        }

        public void ActualizarMantenimiento(int id, string nuevaFecha, string nuevasObservaciones)
        {
            // 1. Obtenemos el registro original para no perder los IDs (Equipo, Admin, etc.)
            var mantenimiento = _mantenimientoRepository.GetById(id);

            if (mantenimiento != null)
            {
                // 2. Solo modificamos lo permitido
                mantenimiento.Fecha = nuevaFecha;
                mantenimiento.Observaciones = nuevasObservaciones;

                // 3. Guardamos
                _mantenimientoRepository.Update(mantenimiento);
            }
        }

    }
}
