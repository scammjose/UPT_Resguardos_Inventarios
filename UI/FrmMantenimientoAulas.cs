using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Helpers;
using AppEscritorioUPT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscritorioUPT.UI
{
    public partial class FrmMantenimientoAulas : Form
    {
        private readonly MantenimientoAulaService _mantenimientoService;
        private readonly EdificioRepository _edificioRepo;
        private readonly MantenimientoAulaReportService _reportService;
        private readonly TipoMantenimientoService _tipoMantenimientoService;

        private MantenimientoAula? _mantenimientoSeleccionado = null;

        public FrmMantenimientoAulas()
        {
            InitializeComponent();

            _mantenimientoService = new MantenimientoAulaService();
            _edificioRepo = new EdificioRepository();
            _reportService = new MantenimientoAulaReportService();
            _tipoMantenimientoService = new TipoMantenimientoService();

            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmMantenimientoAulas_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnActualizar.Click += BtnActualizar_Click; // Cambiado: Ahora usamos Actualizar
            btnEliminar.Click += BtnEliminar_Click;
            btnImprimir.Click += BtnImprimir_Click;

            // Configurar DataGridView
            dgvMantenimientos.ReadOnly = true;
            dgvMantenimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMantenimientos.MultiSelect = false;
            dgvMantenimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvMantenimientos.AllowUserToAddRows = false;
            dgvMantenimientos.CellClick += DgvMantenimientos_CellClick;
        }

        private void FrmMantenimientoAulas_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            CargarGrid();
        }

        private void CargarCombos()
        {
            try
            {
                // 1. Combo de Edificios usando tu Helper
                var edificios = _edificioRepo.GetAll();
                var edificioDefault = new Edificio { Id = 0, Nombre = "Seleccione un Edificio..." };

                ComboBoxHelper.CargarConSeleccionDefault(
                    cmbEdificio,
                    edificios,
                    "Nombre",
                    "Id",
                    edificioDefault
                );

                // 2. Combo de Tipo de Mantenimiento
                var tiposMantenimiento = _tipoMantenimientoService.ObtenerTodos();

                ComboBoxHelper.CargarConSeleccionDefault(
                    cmbTipoMantenimiento,
                    tiposMantenimiento,
                    "Nombre",
                    "Id",
                    new TipoMantenimiento { Id = 0, Nombre = "Selecciona una opción" }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrid()
        {
            try
            {
                var lista = _mantenimientoService.ObtenerTodos();
                dgvMantenimientos.DataSource = lista;

                // Ocultar IDs internos
                if (dgvMantenimientos.Columns["Id"] != null)
                    dgvMantenimientos.Columns["Id"].Visible = false;
                if (dgvMantenimientos.Columns["EdificioId"] != null)
                    dgvMantenimientos.Columns["EdificioId"].Visible = false;

                // Nombres de columnas limpios
                if (dgvMantenimientos.Columns["EdificioNombre"] != null)
                    dgvMantenimientos.Columns["EdificioNombre"].HeaderText = "Edificio";
                if (dgvMantenimientos.Columns["FechaEjecucion"] != null)
                    dgvMantenimientos.Columns["FechaEjecucion"].HeaderText = "Fecha";
                if (dgvMantenimientos.Columns["TipoMantenimiento"] != null)
                    dgvMantenimientos.Columns["TipoMantenimiento"].HeaderText = "Tipo";

                if (dgvMantenimientos.Columns["Observaciones"] != null)
                    dgvMantenimientos.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                LimpiarFormulario(); // Esto ahora también gestiona el estado de los botones
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN GUARDAR (Solo para registros nuevos) ---
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var mantenimiento = new MantenimientoAula
                {
                    Id = 0, // Siempre 0 para asegurar que es un Insert
                    EdificioId = Convert.ToInt32(cmbEdificio.SelectedValue),
                    FechaEjecucion = dtpFecha.Value.ToString("yyyy-MM-dd"),
                    TipoMantenimiento = cmbTipoMantenimiento.Text, // Usamos Text porque está bindeado con objetos
                    Observaciones = txtObservaciones.Text.Trim()
                };

                _mantenimientoService.GuardarMantenimiento(mantenimiento);

                MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN ACTUALIZAR (Solo para registros existentes) ---
        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            if (_mantenimientoSeleccionado == null) return;
            if (!ValidarCampos()) return;

            try
            {
                var mantenimiento = new MantenimientoAula
                {
                    Id = _mantenimientoSeleccionado.Id, // Mantenemos el ID para hacer el Update
                    EdificioId = Convert.ToInt32(cmbEdificio.SelectedValue),
                    FechaEjecucion = dtpFecha.Value.ToString("yyyy-MM-dd"),
                    TipoMantenimiento = cmbTipoMantenimiento.Text,
                    Observaciones = txtObservaciones.Text.Trim()
                };

                _mantenimientoService.GuardarMantenimiento(mantenimiento);

                MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_mantenimientoSeleccionado == null) return;

            var confirm = MessageBox.Show("¿Seguro que desea eliminar este registro de mantenimiento?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _mantenimientoService.EliminarMantenimiento(_mantenimientoSeleccionado.Id);
                    MessageBox.Show("Registro eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            if (_mantenimientoSeleccionado == null) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                string rutaPdf = _reportService.GenerarPdfMantenimientoAula(_mantenimientoSeleccionado.Id);
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(rutaPdf) { UseShellExecute = true };
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DgvMantenimientos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si hace clic en el espacio vacío del grid, resetea todo a "modo nuevo"
            if (e.RowIndex < 0)
            {
                LimpiarFormulario();
                return;
            }

            _mantenimientoSeleccionado = dgvMantenimientos.Rows[e.RowIndex].DataBoundItem as MantenimientoAula;

            if (_mantenimientoSeleccionado != null)
            {
                cmbEdificio.SelectedValue = _mantenimientoSeleccionado.EdificioId;

                // NOTA: Cambié esto a .Text para evitar problemas con la clase objeto del Helper
                cmbTipoMantenimiento.Text = _mantenimientoSeleccionado.TipoMantenimiento;

                txtObservaciones.Text = _mantenimientoSeleccionado.Observaciones;

                if (DateTime.TryParse(_mantenimientoSeleccionado.FechaEjecucion, out DateTime fechaParsed))
                {
                    dtpFecha.Value = fechaParsed;
                }

                // GESTIÓN DE BOTONES: Modo Edición
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                btnImprimir.Enabled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (cmbEdificio.SelectedValue == null || Convert.ToInt32(cmbEdificio.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar un Edificio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbTipoMantenimiento.SelectedValue == null || Convert.ToInt32(cmbTipoMantenimiento.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Mantenimiento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _mantenimientoSeleccionado = null;

            if (cmbEdificio.Items.Count > 0) cmbEdificio.SelectedIndex = 0;
            if (cmbTipoMantenimiento.Items.Count > 0) cmbTipoMantenimiento.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Now;
            txtObservaciones.Clear();
            dgvMantenimientos.ClearSelection();

            // GESTIÓN DE BOTONES: Modo Nuevo Registro
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnImprimir.Enabled = false;
        }
    }
}
