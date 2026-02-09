using AppEscritorioUPT.Data;
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
    public class ResguardoService
    {
        private readonly IResguardoRepository _resRepo;
        private readonly IAdministrativoRepository _adminRepo;
        private readonly IAreaRepository _areaRepo;

        public ResguardoService()
            : this(new ResguardoRepository(), new AdministrativoRepository(), new AreaRepository())
        {
        }

        public ResguardoService(
            IResguardoRepository resRepo,
            IAdministrativoRepository adminRepo,
            IAreaRepository areaRepo)
        {
            _resRepo = resRepo;
            _adminRepo = adminRepo;
            _areaRepo = areaRepo;
        }

        public IEnumerable<Resguardo> ObtenerResguardos()
        {
            return _resRepo.GetAll();
        }

        private string GenerarCodigoInventario(int administrativoId, int? anioOverride = null)
        {
            var admin = _adminRepo.GetById(administrativoId)
                ?? throw new ArgumentException("El administrativo especificado no existe.", nameof(administrativoId));

            var area = _areaRepo.GetById(admin.AreaId)
                ?? throw new InvalidOperationException("El área asociada al administrativo no existe.");

            if (string.IsNullOrWhiteSpace(area.NomenclaturaInventario))
                throw new InvalidOperationException("El área no tiene definida una nomenclatura de inventario.");

            var anio = anioOverride ?? DateTime.Now.Year;
            var nomen = area.NomenclaturaInventario.Trim().ToUpper();

            var ultimo = _resRepo.ObtenerUltimoCodigoPorAreaYAnio(nomen, anio);
            int consecutivo = 1;

            if (!string.IsNullOrWhiteSpace(ultimo))
            {
                var parteNumerica = ultimo.Substring(ultimo.Length - 4);
                if (int.TryParse(parteNumerica, out int num))
                {
                    consecutivo = num + 1;
                }
            }

            var consecutivoStr = consecutivo.ToString("D4");
            return $"UPT-{nomen}-{anio}-{consecutivoStr}";
        }

        public Resguardo CrearResguardo(
            int equipoId,
            int administrativoId,
            int responsableSistemasId,
            string? notas)
        {
            if (equipoId <= 0)
                throw new ArgumentException("El equipo no es válido.", nameof(equipoId));
            if (administrativoId <= 0)
                throw new ArgumentException("El administrativo no es válido.", nameof(administrativoId));
            if (responsableSistemasId <= 0)
                throw new ArgumentException("El responsable de sistemas no es válido.", nameof(responsableSistemasId));

            var codigo = GenerarCodigoInventario(administrativoId);

            var res = new Resguardo
            {
                EquipoId = equipoId,
                AdministrativoId = administrativoId,
                ResponsableSistemasId = responsableSistemasId,
                CodigoInventario = codigo,
                FechaResguardo = DateTime.Now.ToString("yyyy-MM-dd"),
                Notas = string.IsNullOrWhiteSpace(notas) ? null : notas.Trim()
            };

            _resRepo.Add(res);
            return res;
        }

        public void ActualizarResguardo(Resguardo r)
        {
            if (r.Id <= 0)
                throw new ArgumentException("El Id del resguardo no es válido.", nameof(r));

            r.Notas = string.IsNullOrWhiteSpace(r.Notas) ? null : r.Notas.Trim();
            _resRepo.Update(r);
        }

        public void EliminarResguardo(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id del resguardo no es válido.", nameof(id));

            _resRepo.Delete(id);
        }
    }
}
