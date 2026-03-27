using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscritorioUPT.Helpers
{
    public class LoteGridHelper
    {
        public static void ConfigurarGridBase(DataGridView dgv)
        {
            // ===== 1. DESBLOQUEAR EDICIÓN =====
            dgv.ReadOnly = false;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;

            if (dgv.Columns["Fila"] != null)
            {
                dgv.Columns["Fila"].HeaderText = "#";
                dgv.Columns["Fila"].ReadOnly = true;
                dgv.Columns["Fila"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            }

            // Títulos Base
            if (dgv.Columns["NumeroSerie"] != null) dgv.Columns["NumeroSerie"].HeaderText = "Núm. Serie";
            if (dgv.Columns["DireccionIp"] != null) dgv.Columns["DireccionIp"].HeaderText = "Dirección IP";
            if (dgv.Columns["MacAddress"] != null) dgv.Columns["MacAddress"].HeaderText = "MAC Address";

            // Títulos Telefonía
            if (dgv.Columns["NumeroExtension"] != null) dgv.Columns["NumeroExtension"].HeaderText = "Extensión";
            if (dgv.Columns["PrivilegiosLlamadas"] != null) dgv.Columns["PrivilegiosLlamadas"].HeaderText = "Privilegios";

            // Títulos Periféricos
            if (dgv.Columns["MonitorMarca"] != null) dgv.Columns["MonitorMarca"].HeaderText = "Marca Monitor";
            if (dgv.Columns["MonitorModelo"] != null) dgv.Columns["MonitorModelo"].HeaderText = "Mod. Monitor";
            if (dgv.Columns["MonitorSerie"] != null) dgv.Columns["MonitorSerie"].HeaderText = "S/N Monitor";

            if (dgv.Columns["TecladoMarca"] != null) dgv.Columns["TecladoMarca"].HeaderText = "Marca Teclado";
            if (dgv.Columns["TecladoModelo"] != null) dgv.Columns["TecladoModelo"].HeaderText = "Mod. Teclado";
            if (dgv.Columns["TecladoSerie"] != null) dgv.Columns["TecladoSerie"].HeaderText = "S/N Teclado";

            if (dgv.Columns["MouseMarca"] != null) dgv.Columns["MouseMarca"].HeaderText = "Marca Mouse";
            if (dgv.Columns["MouseModelo"] != null) dgv.Columns["MouseModelo"].HeaderText = "Mod. Mouse";
            if (dgv.Columns["MouseSerie"] != null) dgv.Columns["MouseSerie"].HeaderText = "S/N Mouse";
        }

        public static void AjustarColumnasPorTipo(DataGridView dgv, string categoriaEquipo)
        {
            // 1. Apagamos TODAS las columnas que son opcionales primero
            string[] todasOpcionales = {
                "DireccionIp", "MacAddress", "NumeroExtension", "PrivilegiosLlamadas",
                "TipoImpresion",
                "MonitorMarca", "MonitorModelo", "MonitorSerie",
                "TecladoMarca", "TecladoModelo", "TecladoSerie",
                "MouseMarca", "MouseModelo", "MouseSerie"
            };

            foreach (var col in todasOpcionales)
            {
                if (dgv.Columns[col] != null) dgv.Columns[col].Visible = false;
            }

            // 2. Encendemos solo las que le tocan a cada equipo
            if (categoriaEquipo == "PC_ESCRITORIO")
            {
                if (dgv.Columns["DireccionIp"] != null) dgv.Columns["DireccionIp"].Visible = true;

                string[] perifericos = { "MonitorMarca", "MonitorModelo", "MonitorSerie", "TecladoMarca", "TecladoModelo", "TecladoSerie", "MouseMarca", "MouseModelo", "MouseSerie" };
                foreach (var p in perifericos) if (dgv.Columns[p] != null) dgv.Columns[p].Visible = true;
            }
            else if (categoriaEquipo == "LAPTOP_AIO")
            {
                if (dgv.Columns["DireccionIp"] != null) dgv.Columns["DireccionIp"].Visible = true;
                // MAC es opcional en laptops, pero si quieres la activas aquí.
            }
            else if (categoriaEquipo == "TELEFONO")
            {
                if (dgv.Columns["DireccionIp"] != null) dgv.Columns["DireccionIp"].Visible = true;
                if (dgv.Columns["MacAddress"] != null) dgv.Columns["MacAddress"].Visible = true;
                if (dgv.Columns["NumeroExtension"] != null) dgv.Columns["NumeroExtension"].Visible = true;
                if (dgv.Columns["PrivilegiosLlamadas"] != null) dgv.Columns["PrivilegiosLlamadas"].Visible = true;
            }
            // CATEGORÍA PARA IMPRESORAS!
            else if (categoriaEquipo == "IMPRESORA")
            {
                if (dgv.Columns["DireccionIp"] != null) dgv.Columns["DireccionIp"].Visible = true; // Impresoras de red
                if (dgv.Columns["TipoImpresion"] != null)
                {
                    int index = dgv.Columns["TipoImpresion"].Index;
                    dgv.Columns.Remove("TipoImpresion"); // Borramos la que se generó sola

                    var cmbCol = new DataGridViewComboBoxColumn
                    {
                        Name = "TipoImpresion",
                        DataPropertyName = "TipoImpresion", // Enlace con el DTO
                        HeaderText = "Tipo de Impresión",   // ¡Con espacio y acento!
                        DataSource = CatalogosEstaticosHelper.ObtenerTiposImpresion(),
                        FlatStyle = FlatStyle.Flat
                    };
                    dgv.Columns.Insert(index, cmbCol); // Metemos el ComboBox en esa posición
                }
            }
        }
    }
}
