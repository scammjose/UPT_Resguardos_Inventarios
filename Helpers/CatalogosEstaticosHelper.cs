using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Helpers
{
    public static class CatalogosEstaticosHelper
    {
        public static string[] ObtenerTiposImpresion()
        {
            return new[]
            {
                "LÁSER", "INYECCIÓN DE TINTA", "TINTA CONTINUA", "MULTIFUNCIONAL",
                "ESCÁNER", "TÓNER", "CARTUCHO", "TINTA", "CREDENCIALIZADORA",
                "IMPRESORA TÉRMICA", "IMPRESORA DE MATRIZ DE PUNTO", "PLOTTER",
                "FOTOCOPIADORA", "SUBLIMACIÓN", "IMPRESORA 3D"
            };
        }
    }
}
