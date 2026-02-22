using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppEscritorioUPT.Helpers
{
    public static class ThemeHelper
    {
        // Definimos nuestros colores base aquí arriba para usarlos fácilmente
        private static readonly Color ColorFondoVentana = Color.White; // Fondo general
        private static readonly Color ColorTextoGuinda = ColorTranslator.FromHtml("#A02142"); // Guinda UPT
        private static readonly Color ColorFondoCrema = ColorTranslator.FromHtml("#FDFBF7"); // Un crema muy suave y elegante
        private static readonly Color ColorTextoCarbon = ColorTranslator.FromHtml("#39393A"); // Carbón para el texto que escribe el usuario
        private static readonly Color ColorDorado = ColorTranslator.FromHtml("#A0825A");
        private static readonly Color ColorFondoGrisClaro = ColorTranslator.FromHtml("#E0E0E0");
        private static readonly Color ColorCabeceraGrid = ColorTranslator.FromHtml("#F2F2F2"); // Gris muy claro para los títulos
        private static readonly Color ColorBordeGrid = ColorTranslator.FromHtml("#EAEAEA"); // Líneas divisorias súper tenues
        private static readonly Color ColorCabeceraGuindaClaro = ColorTranslator.FromHtml("#C45A72"); // Guinda claro para títulos
        private static readonly Color ColorBordeDoradoClaro = ColorTranslator.FromHtml("#D8CDBF"); // Crema/Dorado sutil para las líneas
        // NUEVOS COLORES: ESTADO DESHABILITADO (Apagado)
        private static readonly Color ColorBotonApagadoFondo = ColorTranslator.FromHtml("#E5E5E5"); // Gris muy pálido
        private static readonly Color ColorBotonApagadoTexto = ColorTranslator.FromHtml("#A6A6A6"); // Gris medio (deslavado)
        /// <summary>
        /// Aplica la paleta de colores oficial a los controles del formulario.
        /// </summary>
        public static void AplicarTema(Form formulario)
        {
            // 1. Pintamos el fondo principal de la ventana
            formulario.BackColor = ColorFondoVentana;

            // Aquí iremos agregando el recorrido de los controles poco a poco...
            AplicarColorRecursivo(formulario.Controls);
        }

        private static void AplicarColorRecursivo(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                // Si el control es un contenedor (como un Panel o GroupBox), entramos a buscar más controles
                if (control.HasChildren)
                {
                    AplicarColorRecursivo(control.Controls);
                }

                // ==========================================
                // ETIQUETAS (Labels)
                // ==========================================
                if (control is Label lbl)
                {
                    lbl.ForeColor = ColorTextoGuinda;
                    lbl.BackColor = Color.Transparent; // Que tome el color del fondo de la ventana
                    lbl.Font = new Font("Arial", 9F, FontStyle.Bold); // Hacemos que resalte un poco más
                }
                // ==========================================
                // CAJAS DE TEXTO (TextBox)
                // ==========================================
                else if (control is TextBox txt)
                {
                    txt.BackColor = ColorFondoCrema;
                    txt.ForeColor = ColorTextoCarbon;
                    txt.BorderStyle = BorderStyle.FixedSingle; // Le quita el efecto 3D viejo de Windows y lo hace plano y moderno
                }
                // ==========================================
                // COMBOBOX (Listas Desplegables)
                // ==========================================
                else if (control is ComboBox cmb)
                {
                    cmb.BackColor = ColorFondoCrema;
                    cmb.ForeColor = ColorTextoCarbon;
                    cmb.FlatStyle = FlatStyle.Flat; // Estilo plano

                    // ¡MAGIA! Le decimos a Windows que nosotros dibujaremos los elementos
                    cmb.DrawMode = DrawMode.OwnerDrawFixed;

                    // Nos aseguramos de no suscribir el evento dos veces por accidente
                    cmb.DrawItem -= Cmb_DrawItem;
                    cmb.DrawItem += Cmb_DrawItem;
                }
                // ==========================================
                // BOTONES (Button)
                // ==========================================
                else if (control is Button btn)
                {
                    // 1. Le quitamos el feo efecto 3D de Windows antiguo
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0; // Sin borde negro

                    // 2. Le ponemos la fuente en Negritas (Bold) y cursor de manita
                    btn.Font = new Font("Arial", 10F, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;

                    // 3. Si es el botón principal (Guardar / Agregar)
                    if (btn.Name.Contains("Guardar") || btn.Name.Contains("Agregar"))
                    {
                        btn.BackColor = ColorTextoGuinda; // Fondo Guinda
                        btn.ForeColor = Color.White;      // Texto Blanco
                    }
                    else if (btn.Name.Contains("Actualizar"))
                    {
                        btn.BackColor = ColorDorado;
                        btn.ForeColor = Color.White;
                    }
                    else if (btn.Name.Contains("Eliminar"))
                    {
                        btn.BackColor = ColorFondoGrisClaro;
                        // Usamos negro puro para garantizar la máxima legibilidad sobre el gris
                        btn.ForeColor = Color.Black;
                    }
                    btn.Paint -= Btn_Paint;
                    btn.Paint += Btn_Paint;
                }
                // ==========================================
                // TABLAS (DataGridView)
                // ==========================================
                else if (control is DataGridView dgv)
                {
                    // 1. Apariencia General
                    dgv.BackgroundColor = ColorFondoVentana;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.RowHeadersVisible = false;
                    dgv.AllowUserToResizeRows = false;

                    // 2. Líneas de la cuadrícula (Visibles y Doradas/Crema)
                    dgv.GridColor = ColorBordeDoradoClaro;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Cuadrícula completa

                    // 3. Cabeceras (Tonalidad Guinda Claro y sin Azul)
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorCabeceraGuindaClaro;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    // ¡MAGIA! Esto evita que se ponga azul al hacer clic en el título de la columna
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorCabeceraGuindaClaro;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9F, FontStyle.Bold);
                    dgv.ColumnHeadersHeight = 35;

                    // 4. Filas normales y Selección
                    dgv.DefaultCellStyle.BackColor = ColorFondoVentana;
                    dgv.DefaultCellStyle.ForeColor = ColorTextoCarbon;
                    dgv.DefaultCellStyle.Font = new Font("Arial", 9F, FontStyle.Regular);

                    dgv.DefaultCellStyle.SelectionBackColor = ColorTextoGuinda;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                    dgv.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);
                    dgv.RowTemplate.Height = 35;
                }
            }
        }

        // ==========================================
        // DIBUJADORES PERSONALIZADOS (Paint Events)
        // ==========================================

        // 1. Dibuja los botones cuando están deshabilitados
        private static void Btn_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;

            // Si el botón está APAGADO, nosotros lo dibujamos
            if (btn != null && !btn.Enabled)
            {
                // Pintamos el cuadro de fondo gris pálido
                using (SolidBrush brochaFondo = new SolidBrush(ColorBotonApagadoFondo))
                {
                    e.Graphics.FillRectangle(brochaFondo, btn.ClientRectangle);
                }

                // Pintamos el texto encima con un color gris deslavado
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, ColorBotonApagadoTexto,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        // ==========================================
        // DIBUJADOR PERSONALIZADO PARA COMBOBOX
        // ==========================================
        private static void Cmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox cmb = sender as ComboBox;

            // Obtenemos el texto real a mostrar (muy importante para evitar errores con bases de datos)
            string textoItem = cmb.GetItemText(cmb.Items[e.Index]);

            // Detectamos si el mouse está posado sobre este elemento (Selected)
            bool estaSeleccionado = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            // Elegimos los colores dependiendo del estado
            Color colorFondo = estaSeleccionado ? ColorTextoGuinda : ColorFondoCrema;
            Color colorTexto = estaSeleccionado ? Color.White : ColorTextoCarbon;

            // 1. Pintamos el cuadro de fondo
            using (SolidBrush brochaFondo = new SolidBrush(colorFondo))
            {
                e.Graphics.FillRectangle(brochaFondo, e.Bounds);
            }

            // 2. Pintamos el texto encima
            using (SolidBrush brochaTexto = new SolidBrush(colorTexto))
            {
                // Le damos un pequeño margen de 2 píxeles a la izquierda para que no pegue con el borde
                Rectangle margenTexto = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height);

                StringFormat formato = new StringFormat
                {
                    LineAlignment = StringAlignment.Center, // Centrado verticalmente
                    Alignment = StringAlignment.Near        // Alineado a la izquierda
                };

                e.Graphics.DrawString(textoItem, e.Font, brochaTexto, margenTexto, formato);
            }
        }
    }
}
