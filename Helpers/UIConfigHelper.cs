using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppEscritorioUPT.Helpers
{
    public static class UIConfigHelper
    {
        public static void ConfigurarControles(Form formulario)
        {
            AplicarConfiguracionRecursiva(formulario.Controls);
        }

        private static void AplicarConfiguracionRecursiva(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                // Si el control tiene contenedores adentro, aplicamos recursividad
                if (control.HasChildren)
                {
                    AplicarConfiguracionRecursiva(control.Controls);
                }

                // ==========================================
                // 1. CONFIGURACIÓN DE COMBOBOX
                // ==========================================
                if (control is ComboBox cmb)
                {
                    // Forzar a que solo se pueda seleccionar, no escribir texto libre
                    cmb.DropDownStyle = ComboBoxStyle.DropDownList;

                    // Altura de los elementos de la lista desplegable (para que no se vean apretados)
                    cmb.ItemHeight = 20;
                }

                // ==========================================
                // 2. CONFIGURACIÓN DE LABELS
                // ==========================================
                else if (control is Label lbl)
                {
                    // Evitar que el texto quede pegado a los bordes del control
                    lbl.Padding = new Padding(3, 3, 3, 3);

                    // Asegurar que el control crezca si el texto es muy largo
                    lbl.AutoSize = true;

                    // Aquí en el futuro podemos agregar la lógica para redondear bordes si le ponemos un color de fondo
                }

                // ==========================================
                // CONFIGURACIÓN DE TABLAS (DataGridView)
                // ==========================================
                else if (control is DataGridView dgv)
                {
                    dgv.ReadOnly = true;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.AllowUserToAddRows = false;
                    dgv.AllowUserToDeleteRows = false;
                    // ¡LA MAGIA!: Obliga a la tabla a limpiar cualquier selección automática 
                    // justo después de que se le inyectan los datos desde la base de datos.
                    dgv.DataBindingComplete += (sender, e) =>
                    {
                        dgv.ClearSelection();
                        dgv.CurrentCell = null;
                    };
                }
            }
        }
    }
}
