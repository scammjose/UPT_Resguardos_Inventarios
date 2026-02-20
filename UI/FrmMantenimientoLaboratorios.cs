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
    public partial class FrmMantenimientoLaboratorios : Form
    {
        private readonly MantenimientoLaboratorioService _mantenimientoService;
        private readonly LaboratorioService _laboratorioService;
        private readonly TipoMantenimientoService _tipoMantenimientoService;

        private MantenimientoLaboratorio? _mantenimientoSeleccionado = null;

        public FrmMantenimientoLaboratorios()
        {
            InitializeComponent();

            // Aplicamos el diseño institucional a toda la pantalla
            //ThemeHelper.AplicarTema(this);

            _mantenimientoService = new MantenimientoLaboratorioService();
            _laboratorioService = new LaboratorioService();
            _tipoMantenimientoService = new TipoMantenimientoService();

            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmMantenimientoLaboratorios_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnImprimir.Click += BtnImprimir_Click;

            // Configurar DataGridView
            dgvMantenimientos.ReadOnly = true;
            dgvMantenimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMantenimientos.MultiSelect = false;
            dgvMantenimientos.AllowUserToAddRows = false;
            dgvMantenimientos.CellClick += DgvMantenimientos_CellClick;
        }

        private void FrmMantenimientoLaboratorios_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            CargarGrid();
        }

        private void CargarCombos()
        {
            try
            {
                // 1. Combo de Laboratorios
                var laboratorios = _laboratorioService.ObtenerTodos();
                ComboBoxHelper.CargarConSeleccionDefault(
                    cmbLaboratorio, laboratorios, "Nombre", "Id",
                    new Laboratorio { Id = 0, Nombre = "Seleccione un laboratorio..." });

                // 2. Combo de Tipos de Mantenimiento
                var tiposMantenimiento = _tipoMantenimientoService.ObtenerTodos();
                ComboBoxHelper.CargarConSeleccionDefault(
                    cmbTipoMantenimiento, tiposMantenimiento, "Nombre", "Id",
                    new TipoMantenimiento { Id = 0, Nombre = "Seleccione el tipo..." });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas desplegables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrid()
        {
            try
            {
                var lista = _mantenimientoService.ObtenerTodos();
                dgvMantenimientos.DataSource = lista;

                // Destruimos las columnas automáticas generadas a mano para que tome las de la clase
                // (Por si acaso se te fue alguna en el diseñador visual)
                dgvMantenimientos.AutoGenerateColumns = true;

                // Ocultar IDs internos que el usuario no necesita ver
                if (dgvMantenimientos.Columns["Id"] != null) dgvMantenimientos.Columns["Id"].Visible = false;
                if (dgvLaboratorios_Check("LaboratorioId")) dgvMantenimientos.Columns["LaboratorioId"].Visible = false;
                if (dgvLaboratorios_Check("TipoMantenimientoId")) dgvMantenimientos.Columns["TipoMantenimientoId"].Visible = false;

                // Ajustar encabezados limpios
                if (dgvLaboratorios_Check("LaboratorioNombre")) dgvMantenimientos.Columns["LaboratorioNombre"].HeaderText = "Laboratorio";
                if (dgvLaboratorios_Check("FechaEjecucion")) dgvMantenimientos.Columns["FechaEjecucion"].HeaderText = "Fecha";
                if (dgvLaboratorios_Check("TipoMantenimientoNombre")) dgvMantenimientos.Columns["TipoMantenimientoNombre"].HeaderText = "Tipo";
                if (dgvLaboratorios_Check("ResponsableSistemasNombre")) dgvMantenimientos.Columns["ResponsableSistemasNombre"].HeaderText = "Ing. Responsable";
                if (dgvLaboratorios_Check("Observaciones")) dgvMantenimientos.Columns["Observaciones"].HeaderText = "Observaciones";

                // Le damos más espacio a las columnas que tienen mucho texto
                if (dgvLaboratorios_Check("LaboratorioNombre")) dgvMantenimientos.Columns["LaboratorioNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (dgvLaboratorios_Check("Observaciones")) dgvMantenimientos.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                LimpiarFormulario(); // Esto formatea los botones y vacía las cajas
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla principal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Pequeño método auxiliar para evitar null checks repetitivos en CargarGrid
        private bool dgvLaboratorios_Check(string columnName)
        {
            return dgvMantenimientos.Columns[columnName] != null;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var mantenimiento = new MantenimientoLaboratorio
                {
                    Id = _mantenimientoSeleccionado?.Id ?? 0,
                    LaboratorioId = Convert.ToInt32(cmbLaboratorio.SelectedValue),
                    TipoMantenimientoId = Convert.ToInt32(cmbTipoMantenimiento.SelectedValue),
                    FechaEjecucion = dtpFecha.Value.ToString("yyyy-MM-dd"),
                    Observaciones = txtObservaciones.Text.Trim()
                };

                _mantenimientoService.GuardarMantenimiento(mantenimiento);

                string accion = _mantenimientoSeleccionado == null ? "registrado" : "actualizado";
                MessageBox.Show($"Checklist de Mantenimiento {accion} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            var confirm = MessageBox.Show($"¿Seguro que desea eliminar el registro de mantenimiento de '{_mantenimientoSeleccionado.LaboratorioNombre}'?",
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

            MessageBox.Show("¡Generador de PDF en construcción!\nAquí mandaremos a llamar a la plantilla HTML del checklist del laboratorio.",
                "Próximamente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aquí en el siguiente paso pondremos algo como:
            // var rutaPdf = _reportService.GenerarPdfMantenimientoLaboratorio(_mantenimientoSeleccionado.Id);
        }

        private void DgvMantenimientos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Clic en la nada = Modo "Nuevo Registro"
            if (e.RowIndex < 0)
            {
                LimpiarFormulario();
                return;
            }

            _mantenimientoSeleccionado = dgvMantenimientos.Rows[e.RowIndex].DataBoundItem as MantenimientoLaboratorio;

            if (_mantenimientoSeleccionado != null)
            {
                // Rellenar controles
                cmbLaboratorio.SelectedValue = _mantenimientoSeleccionado.LaboratorioId;
                cmbTipoMantenimiento.SelectedValue = _mantenimientoSeleccionado.TipoMantenimientoId;
                txtObservaciones.Text = _mantenimientoSeleccionado.Observaciones;

                if (DateTime.TryParse(_mantenimientoSeleccionado.FechaEjecucion, out DateTime fechaParsed))
                {
                    dtpFecha.Value = fechaParsed;
                }

                // GESTIÓN DE BOTONES: Modo "Edición"
                btnGuardar.Text = "Actualizar";
                btnEliminar.Enabled = true;
                btnImprimir.Enabled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (cmbLaboratorio.SelectedValue == null || Convert.ToInt32(cmbLaboratorio.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar un Laboratorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (cmbLaboratorio.Items.Count > 0) cmbLaboratorio.SelectedIndex = 0;
            if (cmbTipoMantenimiento.Items.Count > 0) cmbTipoMantenimiento.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Now;
            txtObservaciones.Clear();
            dgvMantenimientos.ClearSelection();

            // GESTIÓN DE BOTONES: Modo "Nuevo Registro"
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            btnImprimir.Enabled = false;
        }
    }
}
