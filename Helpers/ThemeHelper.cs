using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Helpers
{
    public static class ThemeHelper
    {
        // === PALETA DE COLORES INSTITUCIONALES ===
        public static readonly Color ColorGuinda = Color.FromArgb(160, 33, 66);
        public static readonly Color ColorDorado = Color.FromArgb(160, 130, 90);
        public static readonly Color ColorBeige = Color.FromArgb(220, 198, 162);
        public static readonly Color ColorCarbon = Color.FromArgb(57, 57, 58);
        public static readonly Color ColorBlanco = Color.FromArgb(255, 255, 255);
        public static readonly Color ColorFondo = Color.FromArgb(245, 246, 250); // Un gris ultra claro y moderno

        // === FUENTE GLOBAL ===
        public static readonly Font FuenteNormal = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FuenteNegrita = new Font("Segoe UI", 10F, FontStyle.Bold);

        /// <summary>
        /// Aplica el tema institucional a todo el formulario y sus controles internos.
        /// </summary>
        public static void AplicarTema(Form formulario)
        {
            // 1. Estilo base del Formulario
            formulario.BackColor = ColorFondo;
            formulario.ForeColor = ColorCarbon;
            formulario.Font = FuenteNormal;

            // 2. Recorrer todos los controles usando recursividad
            AplicarEstiloControles(formulario.Controls);
        }

        private static void AplicarEstiloControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                // Si el control tiene más controles adentro (ej. un Panel o un GroupBox), aplicamos recursividad
                if (control.HasChildren)
                {
                    AplicarEstiloControles(control.Controls);
                }

                // === ESTILO PARA BOTONES ===
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = ColorGuinda;
                    btn.ForeColor = ColorBlanco;
                    btn.Font = FuenteNegrita;
                    btn.Cursor = Cursors.Hand;

                    // Si quieres que el botón Eliminar sea de otro color (Dorado), puedes hacerlo así:
                    if (btn.Name.Contains("Eliminar") || btn.Name.Contains("Limpiar"))
                    {
                        btn.BackColor = ColorDorado;
                    }
                }

                // === ESTILO PARA TABLAS (DataGridView) ===
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = ColorBlanco;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                    // Forzar que pinte nuestros colores en el encabezado
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorGuinda;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorBlanco;
                    dgv.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
                    dgv.ColumnHeadersHeight = 35;

                    // Color de la fila al seleccionarla
                    dgv.DefaultCellStyle.SelectionBackColor = ColorDorado;
                    dgv.DefaultCellStyle.SelectionForeColor = ColorBlanco;
                    dgv.DefaultCellStyle.BackColor = ColorBlanco;
                    dgv.DefaultCellStyle.ForeColor = ColorCarbon;

                    dgv.RowTemplate.Height = 30; // Filas un poco más altas para que respire el texto
                }

                // === ESTILO PARA CAJAS DE TEXTO Y COMBOS ===
                else if (control is TextBox txt)
                {
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.BackColor = ColorBlanco;
                    txt.ForeColor = ColorCarbon;
                }
                else if (control is ComboBox cmb)
                {
                    cmb.FlatStyle = FlatStyle.Flat;
                    cmb.BackColor = ColorBlanco;
                    cmb.ForeColor = ColorCarbon;
                }

                // === ESTILO PARA ETIQUETAS (Labels) ===
                else if (control is Label lbl)
                {
                    lbl.ForeColor = ColorCarbon;
                    lbl.BackColor = Color.Transparent;

                    // Si tienes un título específico, puedes detectarlo por su nombre
                    if (lbl.Name.StartsWith("lblTitulo"))
                    {
                        lbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        lbl.ForeColor = ColorGuinda;
                    }
                }
            }
        }
    }
}
