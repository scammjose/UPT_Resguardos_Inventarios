using AppEscritorioUPT.Domain;
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
    public partial class FrmAreas : Form
    {

        private readonly AreaService _areaService = new AreaService();
        private Area? _areaSeleccionada;
        public FrmAreas()
        {
            InitializeComponent();

            // Eventos
            this.Load += FrmAreas_Load;
            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            dgvAreas.CellClick += DgvAreas_CellClick;
        }

        // ========== EVENTO LOAD ==========

        private void FrmAreas_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarAreas();
        }

        // ========== CONFIGURACIÓN DEL GRID ==========
        private void ConfigurarGrid()
        {
            dgvAreas.ReadOnly = true;
            dgvAreas.MultiSelect = false;
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreas.AllowUserToAddRows = false;
            dgvAreas.AllowUserToDeleteRows = false;
            dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ========== UTILIDADES ==========

        private void CargarAreas()
        {
            var lista = _areaService.ObtenerAreas().ToList();
            dgvAreas.DataSource = lista;

            // Ocultamos la columna Id si existe
            if (dgvAreas.Columns["Id"] != null)
            {
                dgvAreas.Columns["Id"].Visible = false;
            }

            if (dgvAreas.Columns["NomenclaturaInventario"] != null)
            {
                dgvAreas.Columns["NomenclaturaInventario"].HeaderText = "Nomenclatura";
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNomenclatura.Text = string.Empty;
            _areaSeleccionada = null;
        }

        private bool ValidarCamposObligatorios()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del área es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNomenclatura.Text))
            {
                MessageBox.Show("La nomenclatura de inventario es obligatoria.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomenclatura.Focus();
                return false;
            }

            return true;
        }

        // ========== EVENTOS DE BOTONES ==========

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCamposObligatorios())
                return;

            try
            {
                var nombre = txtNombre.Text;
                var descripcion = txtDescripcion.Text;
                var nomenclatura = txtNomenclatura.Text;

                _areaService.CrearArea(nombre, descripcion, nomenclatura);

                CargarAreas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            if (_areaSeleccionada == null)
            {
                MessageBox.Show("Seleccione un área de la tabla para actualizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCamposObligatorios())
                return;

            try
            {
                _areaSeleccionada.Nombre = txtNombre.Text;
                _areaSeleccionada.Descripcion = txtDescripcion.Text;
                _areaSeleccionada.NomenclaturaInventario = txtNomenclatura.Text;

                _areaService.ActualizarArea(_areaSeleccionada);

                CargarAreas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_areaSeleccionada == null)
            {
                MessageBox.Show("Seleccione un área de la tabla para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Seguro que desea eliminar el área '{_areaSeleccionada.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _areaService.EliminarArea(_areaSeleccionada.Id);
                    CargarAreas();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========== GRID: SELECCIÓN DE FILA ==========

        private void DgvAreas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si se hace clic en el encabezado o fuera de las filas
            if (e.RowIndex < 0)
            {
                dgvAreas.ClearSelection(); // Quita cualquier selección
                LimpiarFormulario();       // Limpia los controles y _adminSeleccionado
                return;
            }

            var fila = dgvAreas.Rows[e.RowIndex];

            if (fila.DataBoundItem is Area area)
            {
                _areaSeleccionada = area;
                txtNombre.Text = area.Nombre;
                txtDescripcion.Text = area.Descripcion;
                txtNomenclatura.Text = area.NomenclaturaInventario;
            }
        }
    }
}
