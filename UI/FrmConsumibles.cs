using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Helpers;
using AppEscritorioUPT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscritorioUPT.UI
{
    public partial class FrmConsumibles : Form
    {
        private readonly ConsumibleService _consumibleService;
        private int _consumibleIdSeleccionado = 0; // 0 = Modo Guardar | >0 = Modo Actualizar
        private ContextMenuStrip _menuOpciones = new ContextMenuStrip();

        public FrmConsumibles()
        {
            InitializeComponent();
            _consumibleService = new ConsumibleService();

            // Eventos
            this.Load += FrmConsumibles_Load;
            btnGuardar.Click += BtnGuardar_Click;

            // Evento para detectar el clic derecho en el Grid
            dgvConsumibles.MouseDown += DgvConsumibles_MouseDown;
            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmConsumibles_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarComboTipos();
            CargarComboColores();
            ConfigurarMenuContextual();
            CargarGrid();
            LimpiarFormulario();
        }

        // ===== CONFIGURACIONES INICIALES =====

        private void ConfigurarGrid()
        {
            dgvConsumibles.AutoGenerateColumns = false;
            dgvConsumibles.ReadOnly = true;
            dgvConsumibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsumibles.AllowUserToAddRows = false;
            dgvConsumibles.RowHeadersVisible = false;
            dgvConsumibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvConsumibles.Columns.Clear();
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo / Nombre" });
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Tipo", HeaderText = "Tipo", Width = 150 });
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Color", HeaderText = "Color", Width = 150 });
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockActual", HeaderText = "Stock", Width = 80 });
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockMinimo", HeaderText = "Stock Mínimo", Width = 100 });
        }

        private void CargarComboTipos()
        {
            // Traemos la lista de tu Helper estático
            var tipos = CatalogosEstaticosHelper.ObtenerTiposImpresion();

            // Usamos tu Helper de ComboBoxes
            // Le pasamos "" (texto vacío) en display y value porque es una lista de strings simples, no de objetos
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbTipo,
                tipos,
                "",
                "",
                "Selecciona una opción..."
            );

            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarComboColores()
        {
            var colores = new string[] {
                "NEGRO (BLACK)",
                "CIAN (CYAN)",
                "MAGENTA",
                "AMARILLO (YELLOW)",
                "TRICOLOR",
                "N/A (ÚNICO)" // Para los tóners láser que solo son uno
            };

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbColor, colores, "", "", "Selecciona un color..."
            );
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigurarMenuContextual()
        {
            var menuActualizar = new ToolStripMenuItem("Actualizar", null, MenuActualizar_Click);
            var menuEliminar = new ToolStripMenuItem("Eliminar", null, MenuEliminar_Click);
            var menuCancelar = new ToolStripMenuItem("Cancelar Selección", null, (s, e) => LimpiarFormulario());

            _menuOpciones.Items.Add(menuActualizar);
            _menuOpciones.Items.Add(menuEliminar);
            _menuOpciones.Items.Add(new ToolStripSeparator()); // Una rayita divisoria
            _menuOpciones.Items.Add(menuCancelar); // Agregué un cancelar por si se arrepienten de dar clic
        }

        private void CargarGrid()
        {
            var consumibles = _consumibleService.ObtenerTodos().ToList();
            dgvConsumibles.DataSource = consumibles;

            // UX: Colorear de rojo los que están bajos de stock
            foreach (DataGridViewRow row in dgvConsumibles.Rows)
            {
                int actual = Convert.ToInt32(row.Cells[4].Value);
                int minimo = Convert.ToInt32(row.Cells[5].Value);

                if (actual <= minimo)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
                }
            }

            dgvConsumibles.ClearSelection();
        }

        // ===== LÓGICA PRINCIPAL =====

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            // Validaciones visuales
            if (string.IsNullOrWhiteSpace(txtModelo.Text) || cmbTipo.SelectedIndex <= 0 || cmbColor.SelectedIndex <= 0)
            {
                MessageBox.Show("El Modelo, el Tipo y el Color son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Armamos el objeto con lo que está en la pantalla
                var consumible = new Consumible
                {
                    Id = _consumibleIdSeleccionado,
                    Modelo = txtModelo.Text.Trim().ToUpper(),
                    Tipo = cmbTipo.SelectedItem?.ToString() ?? "",
                    Color = cmbColor.SelectedItem?.ToString() ?? "",
                    StockActual = (int)nudStockActual.Value,
                    StockMinimo = (int)nudStockMinimo.Value
                };

                // Si el ID es 0, es un registro nuevo
                if (_consumibleIdSeleccionado == 0)
                {
                    _consumibleService.Agregar(consumible);
                    MessageBox.Show("Consumible registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Si el ID es mayor a 0, estamos actualizando
                else
                {
                    _consumibleService.Actualizar(consumible);
                    MessageBox.Show("Consumible actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarGrid();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== LÓGICA DEL CLIC DERECHO (MENÚ) =====

        private void DgvConsumibles_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvConsumibles.HitTest(e.X, e.Y);

                if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
                {
                    dgvConsumibles.ClearSelection();
                    dgvConsumibles.Rows[hit.RowIndex].Selected = true;

                    // Desplegamos el menú flotante en la posición del puntero
                    _menuOpciones.Show(dgvConsumibles, e.Location);
                }
            }
        }

        private void MenuActualizar_Click(object? sender, EventArgs e)
        {
            if (dgvConsumibles.SelectedRows.Count > 0)
            {
                var row = dgvConsumibles.SelectedRows[0];
                _consumibleIdSeleccionado = Convert.ToInt32(row.Cells[0].Value);

                txtModelo.Text = row.Cells[1].Value?.ToString();
                cmbTipo.SelectedItem = row.Cells[2].Value?.ToString();
                cmbColor.SelectedItem = row.Cells[3].Value?.ToString();
                nudStockActual.Value = Convert.ToDecimal(row.Cells[4].Value);
                nudStockMinimo.Value = Convert.ToDecimal(row.Cells[5].Value);

                // Transformamos el botón
                btnGuardar.Text = "Actualizar";
            }
        }

        private void MenuEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvConsumibles.SelectedRows.Count > 0)
            {
                var row = dgvConsumibles.SelectedRows[0];
                int idEliminar = Convert.ToInt32(row.Cells[0].Value);
                string modeloEliminar = row.Cells[1].Value?.ToString() ?? "este consumible";

                var result = MessageBox.Show($"¿Está seguro de eliminar '{modeloEliminar}'?\nSi ya tiene un historial de entregas, esto podría causar errores.",
                                             "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _consumibleService.Eliminar(idEliminar);
                        CargarGrid();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ===== UTILIDADES =====

        private void LimpiarFormulario()
        {
            _consumibleIdSeleccionado = 0;
            txtModelo.Clear();

            // Lo regresamos a la posición de tu itemDefault
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
            if (cmbColor.Items.Count > 0) cmbColor.SelectedIndex = 0;

            nudStockActual.Value = 0;
            nudStockMinimo.Value = 0;

            btnGuardar.Text = "Guardar";
            txtModelo.Focus();
        }
    }
}
