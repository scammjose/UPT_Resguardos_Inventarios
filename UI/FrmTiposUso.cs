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
    public partial class FrmTiposUso : Form
    {
        private readonly TipoUsoService _tipoUsoService = new TipoUsoService();
        private int _idSeleccionado = 0; // Si es 0, guarda nuevo. Si es > 0, actualiza.
        private ContextMenuStrip _menuContextual = new ContextMenuStrip();

        public FrmTiposUso()
        {
            InitializeComponent();
            this.Load += FrmTiposUso_Load;
            btnGuardar.Click += BtnGuardar_Click;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmTiposUso_Load(object? sender, EventArgs e)
        {
            ConfigurarMenuContextual();
            ConfigurarGrid();
            CargarGrid();
            LimpiarFormulario();
        }

        private void ConfigurarGrid()
        {
            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipos.ReadOnly = true;
            dgvTipos.AllowUserToAddRows = false;
            dgvTipos.MultiSelect = false;

            // Evento para detectar el clic derecho
            dgvTipos.CellMouseUp += DgvTipos_CellMouseUp;
        }

        private void CargarGrid()
        {
            dgvTipos.DataSource = _tipoUsoService.ObtenerTiposUso().ToList();

            if (dgvTipos.Columns["Id"] != null)
                dgvTipos.Columns["Id"].Visible = false;

            if (dgvTipos.Columns["Nombre"] != null)
                dgvTipos.Columns["Nombre"].HeaderText = "Etiqueta / Tipo de Uso";
        }

        // ==========================================
        // LÓGICA DEL MENÚ CONTEXTUAL (CLIC DERECHO)
        // ==========================================
        private void ConfigurarMenuContextual()
        {
            var itemActualizar = new ToolStripMenuItem("Actualizar Registro");
            itemActualizar.Image = SystemIcons.Information.ToBitmap(); // Icono genérico (opcional)
            itemActualizar.Click += ItemActualizar_Click;

            var itemEliminar = new ToolStripMenuItem("Eliminar Registro");
            itemEliminar.Image = SystemIcons.Error.ToBitmap(); // Icono genérico (opcional)
            itemEliminar.Click += ItemEliminar_Click;

            _menuContextual.Items.Add(itemActualizar);
            _menuContextual.Items.Add(itemEliminar);
        }

        private void DgvTipos_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {
            // Si el clic fue con el botón derecho y en una fila válida
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Seleccionamos la fila donde se hizo clic
                dgvTipos.ClearSelection();
                dgvTipos.Rows[e.RowIndex].Selected = true;

                // Mostramos el menú donde está el mouse
                _menuContextual.Show(Cursor.Position);
            }
        }

        private void ItemActualizar_Click(object? sender, EventArgs e)
        {
            if (dgvTipos.SelectedRows.Count > 0 && dgvTipos.SelectedRows[0].DataBoundItem is TipoUso tipo)
            {
                _idSeleccionado = tipo.Id;
                txtNombre.Text = tipo.Nombre;
                btnGuardar.Text = "Actualizar"; // Cambiamos el texto del botón visualmente
            }
        }

        private void ItemEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvTipos.SelectedRows.Count > 0 && dgvTipos.SelectedRows[0].DataBoundItem is TipoUso tipo)
            {
                var confirmacion = MessageBox.Show($"¿Está seguro de eliminar el tipo de uso '{tipo.Nombre}'?",
                                                   "Confirmar Eliminación",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        _tipoUsoService.Eliminar(tipo.Id);
                        MessageBox.Show("Registro eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrid();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // BOTÓN GUARDAR (INSERTA Y ACTUALIZA)
        // ==========================================
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                var tipo = new TipoUso
                {
                    Id = _idSeleccionado,
                    Nombre = txtNombre.Text
                };

                // El servicio ya sabe que si el Id es 0 inserta, y si es mayor a 0, actualiza
                _tipoUsoService.Guardar(tipo);

                MessageBox.Show("Registro guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            txtNombre.Text = string.Empty;
            btnGuardar.Text = "Guardar"; // Restauramos el texto del botón
            dgvTipos.ClearSelection();
            txtNombre.Focus();
        }
    }
}
