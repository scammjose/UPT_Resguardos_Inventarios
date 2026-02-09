using AppEscritorioUPT.Data;
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
    public partial class FrmEquipos : Form
    {
        private readonly EquipoService _equipoService = new EquipoService();
        private readonly TipoEquipoService _tipoService = new TipoEquipoService();

        private Equipo? _equipoSeleccionado;

        public FrmEquipos()
        {
            InitializeComponent();

            this.Load += FrmEquipos_Load;

            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            dgvEquipos.CellClick += DgvEquipos_CellClick;
        }

        // ========== LOAD ==========

        private void FrmEquipos_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarCombos();
            CargarEquipos();

            cmbTipoEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEquipo.DropDownWidth = 220;
        }

        // ========== CONFIGURACIÓN GRID ==========

        private void ConfigurarGrid()
        {
            dgvEquipos.ReadOnly = true;
            dgvEquipos.MultiSelect = false;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.AllowUserToAddRows = false;
            dgvEquipos.AllowUserToDeleteRows = false;
            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ========== CARGA DE DATOS ==========

        private void CargarCombos()
        {
            var tipos = _tipoService.ObtenerTipos().ToList();

            cmbTipoEquipo.DisplayMember = "Nombre";
            cmbTipoEquipo.ValueMember = "Id";
            cmbTipoEquipo.DataSource = tipos;
            cmbTipoEquipo.SelectedIndex = tipos.Any() ? 0 : -1;
        }

        private void CargarEquipos()
        {
            var equipos = _equipoService.ObtenerEquipos().ToList();
            var tipos = _tipoService.ObtenerTipos().ToList();

            // Asignamos nombre de tipo al objeto para mostrarlo en el DataGridView
            foreach (var eq in equipos)
            {
                eq.TipoNombre = tipos.FirstOrDefault(t => t.Id == eq.TipoEquipoId)?.Nombre ?? string.Empty;
            }

            dgvEquipos.DataSource = equipos;

            if (dgvEquipos.Columns["Id"] != null)
                dgvEquipos.Columns["Id"].Visible = false;

            if (dgvEquipos.Columns["TipoEquipoId"] != null)
                dgvEquipos.Columns["TipoEquipoId"].Visible = false;

            if (dgvEquipos.Columns["TipoNombre"] != null)
                dgvEquipos.Columns["TipoNombre"].HeaderText = "Tipo de equipo";

            if (dgvEquipos.Columns["NumeroSerie"] != null)
                dgvEquipos.Columns["NumeroSerie"].HeaderText = "Núm. serie";

            if (dgvEquipos.Columns["DireccionIp"] != null)
                dgvEquipos.Columns["DireccionIp"].HeaderText = "Dirección IP";
        }

        // ========== UTILIDADES ==========

        private void LimpiarFormulario()
        {
            txtMarca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtNumeroSerie.Text = string.Empty;
            txtDireccionIp.Text = string.Empty;

            _equipoSeleccionado = null;

            if (cmbTipoEquipo.Items.Count > 0)
                cmbTipoEquipo.SelectedIndex = 0;
        }

        private bool Validar()
        {
            if (cmbTipoEquipo.SelectedValue is null)
            {
                MessageBox.Show("Debe seleccionar un tipo de equipo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoEquipo.Focus();
                return false;
            }

            return true;
        }

        // ========== BOTONES ==========

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                var tipoValue = cmbTipoEquipo.SelectedValue;
                if (tipoValue is null) return;

                int tipoId = (int)tipoValue;

                var marca = txtMarca.Text;
                var modelo = txtModelo.Text;
                var serie = txtNumeroSerie.Text;
                var ip = txtDireccionIp.Text;

                _equipoService.CrearEquipo(
                    tipoId,
                    marca,
                    modelo,
                    serie,
                    ip
                );

                CargarEquipos();
                LimpiarFormulario();
                dgvEquipos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            if (_equipoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un equipo de la tabla para actualizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Validar()) return;

            try
            {
                var tipoValue = cmbTipoEquipo.SelectedValue;
                if (tipoValue is null) return;

                _equipoSeleccionado.TipoEquipoId = (int)tipoValue;
                _equipoSeleccionado.Marca = txtMarca.Text;
                _equipoSeleccionado.Modelo = txtModelo.Text;
                _equipoSeleccionado.NumeroSerie = txtNumeroSerie.Text;
                _equipoSeleccionado.DireccionIp = txtDireccionIp.Text;

                _equipoService.ActualizarEquipo(_equipoSeleccionado);

                CargarEquipos();
                LimpiarFormulario();
                dgvEquipos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_equipoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un equipo para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Seguro que desea eliminar el equipo seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _equipoService.EliminarEquipo(_equipoSeleccionado.Id);

                    CargarEquipos();
                    LimpiarFormulario();
                    dgvEquipos.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========== SELECCIÓN EN GRID ==========

        private void DgvEquipos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si se hace clic en el encabezado o fuera de las filas
            if (e.RowIndex < 0)
            {
                dgvEquipos.ClearSelection(); // Quita cualquier selección
                LimpiarFormulario();       // Limpia los controles y _adminSeleccionado
                return;
            }

            var fila = dgvEquipos.Rows[e.RowIndex];

            if (fila.DataBoundItem is Equipo eq)
            {
                _equipoSeleccionado = eq;

                cmbTipoEquipo.SelectedValue = eq.TipoEquipoId;
                txtMarca.Text = eq.Marca;
                txtModelo.Text = eq.Modelo;
                txtNumeroSerie.Text = eq.NumeroSerie;
                txtDireccionIp.Text = eq.DireccionIp;
            }
        }
    }
}
