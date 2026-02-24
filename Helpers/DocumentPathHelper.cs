using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Helpers
{
    public static class DocumentPathHelper
    {
        // Esta línea es la magia pura. Detecta la carpeta "Documentos" del usuario actual en cualquier PC
        // y le concatena la carpeta principal de tu sistema "UPTecamac".
        private static readonly string RutaBase = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "UPTecamac"
        );

        /// <summary>
        /// Devuelve la ruta para los Resguardos (ej. Documents\UPTecamac\Resguardos)
        /// Si la carpeta no existe, la crea automáticamente.
        /// </summary>
        public static string ObtenerRutaResguardos()
        {
            string ruta = Path.Combine(RutaBase, "Resguardos");
            AsegurarCarpeta(ruta);
            return ruta;
        }

        /// <summary>
        /// Devuelve la ruta para los Checklists de Mantenimiento de Aulas
        /// </summary>
        public static string ObtenerRutaMantenimientoAulas()
        {
            string ruta = Path.Combine(RutaBase, "Mantenimientos_Aulas");
            AsegurarCarpeta(ruta);
            return ruta;
        }

        /// <summary>
        /// Devuelve la ruta para los Checklists de Mantenimiento de Laboratorios
        /// </summary>
        public static string ObtenerRutaMantenimientoLaboratorios()
        {
            string ruta = Path.Combine(RutaBase, "Mantenimientos_Laboratorios");
            AsegurarCarpeta(ruta);
            return ruta;
        }

        /// <summary>
        /// Devuelve la ruta para los Checklists de Mantenimiento de Administrativos
        /// </summary>
        public static string ObtenerRutaMantenimientoAdministrativos()
        {
            string ruta = Path.Combine(RutaBase, "Mantenimientos_Administrativos");
            AsegurarCarpeta(ruta);
            return ruta;
        }

        // Método privado de apoyo para no repetir el "Directory.Exists"
        private static void AsegurarCarpeta(string ruta)
        {
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
        }
    }
}
