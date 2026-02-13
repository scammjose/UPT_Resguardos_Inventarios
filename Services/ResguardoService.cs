using AppEscritorioUPT.Data;
using AppEscritorioUPT.Data.Interfaces;
using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Domain.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Services
{
    public class ResguardoService
    {
        private readonly IResguardoRepository _resguardoRepo;
        private readonly IAdministrativoRepository _adminRepo;
        private readonly IAreaRepository _areaRepo;

        public ResguardoService()
        {
            _resguardoRepo = new ResguardoRepository();
            _adminRepo = new AdministrativoRepository();
            _areaRepo = new AreaRepository();
        }

        public IEnumerable<Resguardo> ObtenerResguardos()
        {
            return _resguardoRepo.GetAll();
        }

        public Resguardo? ObtenerPorId(int id) => _resguardoRepo.GetById(id);

        public void CrearResguardo(int equipoId, int administrativoId, int responsableSistemasId,
                                   DateTime fechaResguardo, string? notas)
        {
            if (equipoId <= 0)
                throw new ArgumentException("Debe seleccionar un equipo válido.", nameof(equipoId));
            if (administrativoId <= 0)
                throw new ArgumentException("Debe seleccionar un administrativo válido.", nameof(administrativoId));
            if (responsableSistemasId <= 0)
                throw new ArgumentException("Debe seleccionar un responsable de sistemas válido.", nameof(responsableSistemasId));

            var codigo = GenerarCodigoInventario(administrativoId, fechaResguardo);

            var resguardo = new Resguardo
            {
                EquipoId = equipoId,
                AdministrativoId = administrativoId,
                ResponsableSistemasId = responsableSistemasId,
                CodigoInventario = codigo,
                FechaResguardo = fechaResguardo.ToString("yyyy-MM-dd"),
                Notas = notas
            };

            _resguardoRepo.Add(resguardo);
        }

        public void ActualizarResguardo(Resguardo resguardo, DateTime fechaResguardo, string? notas)
        {
            if (resguardo.Id <= 0)
                throw new ArgumentException("Resguardo inválido.", nameof(resguardo));

            resguardo.FechaResguardo = fechaResguardo.ToString("yyyy-MM-dd");
            resguardo.EquipoId = resguardo.EquipoId;
            resguardo.Notas = notas;

            _resguardoRepo.Update(resguardo);
        }

        public void EliminarResguardo(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id inválido.", nameof(id));

            _resguardoRepo.Delete(id);
        }

        // ===== Generación de código de inventario =====
        private string GenerarCodigoInventario(int administrativoId, DateTime fecha)
        {
            var admin = _adminRepo.GetById(administrativoId)
                        ?? throw new InvalidOperationException("No se encontró el administrativo.");

            var area = _areaRepo.GetById(admin.AreaId)
                       ?? throw new InvalidOperationException("No se encontró el área del administrativo.");

            // Ej: UPT-SIS-2026-0007
            var anio = fecha.Year;
            var prefijo = $"UPT-{area.NomenclaturaInventario}-{anio}-";

            var ultimoCodigo = _resguardoRepo.GetUltimoCodigoInventarioPorPrefijo(prefijo);

            int consecutivo = 1;

            if (!string.IsNullOrWhiteSpace(ultimoCodigo))
            {
                // Partimos por guiones y tomamos el último segmento
                var partes = ultimoCodigo.Split('-');
                if (partes.Length >= 4 && int.TryParse(partes[^1], out int num))
                {
                    consecutivo = num + 1;
                }
            }

            return $"{prefijo}{consecutivo:0000}";
        }
        public ResguardoReportModel? ObtenerModeloReporte(int id)
        {
            // si tu repo está en interfaz, agrega también el método a la interfaz
            return ((ResguardoRepository)_resguardoRepo).GetByIdForReport(id);
        }
    }
}
