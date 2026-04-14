using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Domain
{
    public class EntregaConsumible
    {
        public int Id { get; set; }
        public int ConsumibleId { get; set; }
        public int EquipoId { get; set; }

        // Área o Persona a la que se le instala (Aprovechamos tu catálogo de Administrativos)
        public int AdministrativoId { get; set; }

        // El técnico de tu equipo de sistemas que fue a poner el tóner
        public int ResponsableSistemasId { get; set; }

        public DateTime FechaEntrega { get; set; }
        public int Cantidad { get; set; } = 1; // Por defecto casi siempre es 1
    }
}
