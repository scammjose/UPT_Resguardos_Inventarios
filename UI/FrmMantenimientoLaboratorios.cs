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
            dgvMantenimientos.MultiSelect = true;
            dgvMantenimientos.AllowUserToAddRows = false;

            // AGREGAMOS ESTA LÍNEA NUEVA
            dgvMantenimientos.SelectionChanged += DgvMantenimientos_SelectionChanged;
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

                dgvMantenimientos.AutoGenerateColumns = true;

                // 1. Ocultar IDs internos
                if (dgvMantenimientos.Columns["Id"] != null) dgvMantenimientos.Columns["Id"].Visible = false;
                if (dgvLaboratorios_Check("LaboratorioId")) dgvMantenimientos.Columns["LaboratorioId"].Visible = false;
                if (dgvLaboratorios_Check("TipoMantenimientoId")) dgvMantenimientos.Columns["TipoMantenimientoId"].Visible = false;

                // 2. Ajustar encabezados limpios
                if (dgvLaboratorios_Check("LaboratorioNombre")) dgvMantenimientos.Columns["LaboratorioNombre"].HeaderText = "Laboratorio";
                if (dgvLaboratorios_Check("FechaEjecucion")) dgvMantenimientos.Columns["FechaEjecucion"].HeaderText = "Fecha";
                if (dgvLaboratorios_Check("TipoMantenimientoNombre")) dgvMantenimientos.Columns["TipoMantenimientoNombre"].HeaderText = "Tipo";
                if (dgvLaboratorios_Check("ResponsableSistemasNombre")) dgvMantenimientos.Columns["ResponsableSistemasNombre"].HeaderText = "Ing. Responsable";
                if (dgvLaboratorios_Check("Observaciones")) dgvMantenimientos.Columns["Observaciones"].HeaderText = "Observaciones";

                // 3. Tamaños
                if (dgvLaboratorios_Check("LaboratorioNombre")) dgvMantenimientos.Columns["LaboratorioNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //if (dgvLaboratorios_Check("Observaciones")) dgvMantenimientos.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                // =========================================================
                // 4. ORDENAR LAS COLUMNAS VISIBLES (El índice 0 es el primero a la izquierda)
                // =========================================================
                if (dgvLaboratorios_Check("LaboratorioNombre")) dgvMantenimientos.Columns["LaboratorioNombre"].DisplayIndex = 0;
                if (dgvLaboratorios_Check("FechaEjecucion")) dgvMantenimientos.Columns["FechaEjecucion"].DisplayIndex = 1;
                if (dgvLaboratorios_Check("TipoMantenimientoNombre")) dgvMantenimientos.Columns["TipoMantenimientoNombre"].DisplayIndex = 2;
                if (dgvLaboratorios_Check("ResponsableSistemasNombre")) dgvMantenimientos.Columns["ResponsableSistemasNombre"].DisplayIndex = 3;
                if (dgvLaboratorios_Check("Observaciones")) dgvMantenimientos.Columns["Observaciones"].DisplayIndex = 4;

                LimpiarFormulario();
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
            int seleccionados = dgvMantenimientos.SelectedRows.Count;
            if (seleccionados == 0) return;

            string mensaje = seleccionados == 1
                ? $"¿Seguro que desea eliminar el registro de mantenimiento seleccionado?"
                : $"¿Seguro que desea eliminar los {seleccionados} registros seleccionados?";

            var confirm = MessageBox.Show(mensaje, "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dgvMantenimientos.SelectedRows)
                    {
                        var mant = row.DataBoundItem as MantenimientoLaboratorio;
                        if (mant != null)
                        {
                            _mantenimientoService.EliminarMantenimiento(mant.Id);
                        }
                    }

                    MessageBox.Show($"Se eliminaron {seleccionados} registro(s) exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            if (dgvMantenimientos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un registro para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // 1. Recolectar todos los IDs seleccionados
                var idsSeleccionados = new List<int>();
                foreach (DataGridViewRow row in dgvMantenimientos.SelectedRows)
                {
                    var mant = row.DataBoundItem as MantenimientoLaboratorio;
                    if (mant != null)
                    {
                        idsSeleccionados.Add(mant.Id);
                    }
                }

                // OPCIONAL: Invertir la lista para que salgan en el orden de arriba hacia abajo
                idsSeleccionados.Reverse();

                // 2. Enviar la lista completa al servicio
                var reportService = new MantenimientoLaboratorioReportService();
                string rutaPdf = reportService.GenerarPdfMasivo(idsSeleccionados);

                // 3. Abrir el PDF resultante
                var p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(rutaPdf) { UseShellExecute = true };
                p.Start();

                MessageBox.Show($"¡Reporte masivo generado con {idsSeleccionados.Count} hojas exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Si hace clic en la parte gris (vacía), quita la selección
            if (e.RowIndex < 0)
            {
                dgvMantenimientos.ClearSelection();
            }
        }

        private void DgvMantenimientos_SelectionChanged(object? sender, EventArgs e)
        {
            int seleccionados = dgvMantenimientos.SelectedRows.Count;

            if (seleccionados == 0)
            {
                // MODO: NUEVO REGISTRO (0 seleccionados)
                _mantenimientoSeleccionado = null;
                LimpiarControlesVisuales();

                btnGuardar.Text = "Guardar";
                btnGuardar.Enabled = true;
                btnEliminar.Enabled = false;
                btnImprimir.Enabled = false;
            }
            else if (seleccionados == 1)
            {
                // MODO: EDICIÓN (1 seleccionado)
                _mantenimientoSeleccionado = dgvMantenimientos.SelectedRows[0].DataBoundItem as MantenimientoLaboratorio;

                if (_mantenimientoSeleccionado != null)
                {
                    cmbLaboratorio.SelectedValue = _mantenimientoSeleccionado.LaboratorioId;
                    cmbTipoMantenimiento.SelectedValue = _mantenimientoSeleccionado.TipoMantenimientoId;
                    txtObservaciones.Text = _mantenimientoSeleccionado.Observaciones;

                    if (DateTime.TryParse(_mantenimientoSeleccionado.FechaEjecucion, out DateTime fechaParsed))
                        dtpFecha.Value = fechaParsed;

                    btnGuardar.Text = "Actualizar";
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnImprimir.Enabled = true;
                }
            }
            else
            {
                // MODO: SELECCIÓN MÚLTIPLE (2 o más seleccionados)
                _mantenimientoSeleccionado = null;
                LimpiarControlesVisuales();

                btnGuardar.Text = "Múltiple";
                btnGuardar.Enabled = false; // MAGIA: Deshabilitamos el botón guardar
                btnEliminar.Enabled = true;
                btnImprimir.Enabled = true;
            }
        }

        private void LimpiarControlesVisuales()
        {
            if (cmbLaboratorio.Items.Count > 0) cmbLaboratorio.SelectedIndex = 0;
            if (cmbTipoMantenimiento.Items.Count > 0) cmbTipoMantenimiento.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            txtObservaciones.Clear();
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
            // Quitar la selección dispara automáticamente el MODO NUEVO REGISTRO
            dgvMantenimientos.ClearSelection();
        }
    }
}
