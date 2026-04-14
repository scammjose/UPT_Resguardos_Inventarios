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
    public class EntregaConsumibleService
    {
        private readonly IEntregaConsumibleRepository _entregaRepo;
        private readonly ConsumibleService _consumibleService;

        public EntregaConsumibleService()
        {
            _entregaRepo = new EntregaConsumibleRepository();
            _consumibleService = new ConsumibleService(); // Lo usamos para restar el stock
        }

        public IEnumerable<EntregaConsumible> ObtenerTodas()
        {
            return _entregaRepo.ObtenerTodas();
        }

        public void RegistrarEntrega(EntregaConsumible entrega)
        {
            // 1. Validaciones estrictas
            if (entrega.ConsumibleId <= 0)
                throw new ArgumentException("Debe seleccionar el tóner o tinta a entregar.");

            if (entrega.EquipoId <= 0)
                throw new ArgumentException("Debe seleccionar la impresora destino.");

            if (entrega.AdministrativoId <= 0)
                throw new ArgumentException("Debe seleccionar el área o personal que recibe.");

            if (entrega.ResponsableSistemasId <= 0)
                throw new ArgumentException("Debe indicar qué técnico de sistemas realizó la instalación.");

            if (entrega.Cantidad <= 0)
                throw new ArgumentException("La cantidad a entregar debe ser al menos 1.");

            // 2. ¡LA MAGIA DEL INVENTARIO!
            // Mandamos llamar al servicio de consumibles. Si intentas entregar 2 tintas
            // y solo queda 1 en el almacén, este método lanzará un error automáticamente
            // y detendrá el guardado, protegiendo tu base de datos.
            _consumibleService.DescontarStockPorEntrega(entrega.ConsumibleId, entrega.Cantidad);

            // 3. Si sí hubo stock, guardamos el registro histórico de la entrega
            entrega.FechaEntrega = DateTime.Now; // Sellamos la hora exacta
            _entregaRepo.Agregar(entrega);
        }
    }
}
