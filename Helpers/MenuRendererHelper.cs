using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppEscritorioUPT.Helpers
{
    // 1. Definimos exactamente qué colores usar para cada estado del menú
    public class MenuColorTable : ProfessionalColorTable
    {
        // Color de fondo de la barra superior (Guinda)
        public override Color MenuStripGradientBegin => ColorTranslator.FromHtml("#A02142");
        public override Color MenuStripGradientEnd => ColorTranslator.FromHtml("#A02142");

        // Color del cuadrito al pasar el mouse (Hover) en la barra principal (Dorado)
        public override Color MenuItemSelected => ColorTranslator.FromHtml("#A0825A");
        public override Color MenuItemSelectedGradientBegin => ColorTranslator.FromHtml("#A0825A");
        public override Color MenuItemSelectedGradientEnd => ColorTranslator.FromHtml("#A0825A");

        // Color de fondo cuando haces clic y se queda presionado (Guinda más oscuro o Carbón)
        public override Color MenuItemPressedGradientBegin => ColorTranslator.FromHtml("#39393A");
        public override Color MenuItemPressedGradientEnd => ColorTranslator.FromHtml("#39393A");
        public override Color MenuItemPressedGradientMiddle => ColorTranslator.FromHtml("#39393A");

        // Color de fondo de la lista que se despliega hacia abajo (Blanco)
        public override Color ToolStripDropDownBackground => Color.White;

        // Quitar los bordes grises feos por defecto
        public override Color MenuBorder => Color.Transparent;
        public override Color MenuItemBorder => Color.Transparent;
    }

    // 2. Le aplicamos los colores al menú y controlamos el texto
    public class MenuRendererHelper : ToolStripProfessionalRenderer
    {
        public MenuRendererHelper() : base(new MenuColorTable()) { }

        // Aquí controlamos el color del texto dependiendo de dónde esté
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.IsOnDropDown)
            {
                // Texto de las opciones desplegadas hacia abajo (Carbón para que resalte en el fondo blanco)
                e.Item.ForeColor = ColorTranslator.FromHtml("#39393A");
            }
            else
            {
                // Texto de la barra principal superior (Blanco para que contraste con el Guinda)
                e.Item.ForeColor = Color.White;
            }

            base.OnRenderItemText(e);
        }
    }
}
