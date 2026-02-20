using AppEscritorioUPT.Data.Repositories;
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
    public partial class FrmLaboratorios : Form
    {
        private readonly LaboratorioService _laboratorioService;
        private readonly EdificioRepository _edificioRepo;
        private readonly AreaRepository _areaRepo;
        private readonly ResponsableSistemasRepository _responsableRepo;

        private Laboratorio? _laboratorioSeleccionado = null;

        public FrmLaboratorios()
        {
            InitializeComponent();

            // Aplicamos el diseño institucional
            //ThemeHelper.AplicarTema(this);

            _laboratorioService = new LaboratorioService();
            _edificioRepo = new EdificioRepository();
            _areaRepo = new AreaRepository();
            _responsableRepo = new ResponsableSistemasRepository();

            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmLaboratorios_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            // Configurar DataGridView
            dgvLaboratorios.ReadOnly = true;
            dgvLaboratorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLaboratorios.MultiSelect = false;
            dgvLaboratorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; // Scroll horizontal
            dgvLaboratorios.AllowUserToAddRows = false;
            dgvLaboratorios.CellClick += DgvLaboratorios_CellClick;
        }

        private void FrmLaboratorios_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            CargarGrid();
        }

        private void CargarCombos()
        {
            try
            {
                // 1. Combo Edificios (Ubicación)
                var edificios = _edificioRepo.GetAll();
                ComboBoxHelper.CargarConSeleccionDefault(
                    cmbUbicacion, edificios, "Nombre", "Id",
                    new Edificio { Id = 0, Nombre = "Seleccione una ubicación..." });

                // 2. Combo Responsables de Sistemas
                var responsables = _responsableRepo.GetAll();
                ComboBoxHelper.CargarConSeleccionDefault(
                    cmbResponsableSistemas, responsables, "AdministrativoNombre", "Id",
                    new ResponsableSistemas { Id = 0, AdministrativoNombre = "Seleccione un responsable..." });

                // 3. Combo Áreas
                var areas = _areaRepo.GetAll();
                ComboBoxHelper.CargarConSeleccionDefault(
                    cmbAreaResponsable, areas, "Nombre", "Id",
                    new Area { Id = 0, Nombre = "Seleccione un área..." });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrid()
        {
            try
            {
                var lista = _laboratorioService.ObtenerTodos();
                dgvLaboratorios.DataSource = lista;

                // Ocultar columnas de IDs internos (Keys)
                if (dgvLaboratorios.Columns["Id"] != null) dgvLaboratorios.Columns["Id"].Visible = false;
                if (dgvLaboratorios.Columns["EdificioId"] != null) dgvLaboratorios.Columns["EdificioId"].Visible = false;
                if (dgvLaboratorios.Columns["AreaId"] != null) dgvLaboratorios.Columns["AreaId"].Visible = false;
                if (dgvLaboratorios.Columns["ResponsableSistemasId"] != null) dgvLaboratorios.Columns["ResponsableSistemasId"].Visible = false;

                // Ajustar nombres de columnas visibles
                if (dgvLaboratorios.Columns["EdificioNombre"] != null) dgvLaboratorios.Columns["EdificioNombre"].HeaderText = "Ubicación";
                if (dgvLaboratorios.Columns["AreaNombre"] != null) dgvLaboratorios.Columns["AreaNombre"].HeaderText = "Área";
                if (dgvLaboratorios.Columns["ResponsableSistemasNombre"] != null) dgvLaboratorios.Columns["ResponsableSistemasNombre"].HeaderText = "Responsable TI";
                if (dgvLaboratorios.Columns["CantidadEquipos"] != null) dgvLaboratorios.Columns["CantidadEquipos"].HeaderText = "Equipos";

                // Le damos más espacio al Nombre del Laboratorio
                if (dgvLaboratorios.Columns["Nombre"] != null) dgvLaboratorios.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                LimpiarFormulario(); // Resetea el modo de los botones
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var laboratorio = new Laboratorio
                {
                    // Si hay un lab seleccionado, toma su ID para Actualizar. Si no, es 0 para Insertar.
                    Id = _laboratorioSeleccionado?.Id ?? 0,
                    Nombre = txtNombre.Text.Trim(),
                    EdificioId = Convert.ToInt32(cmbUbicacion.SelectedValue),
                    ResponsableSistemasId = Convert.ToInt32(cmbResponsableSistemas.SelectedValue),
                    AreaId = Convert.ToInt32(cmbAreaResponsable.SelectedValue),
                    CantidadEquipos = (int)nudCantidadEquipos.Value
                };

                _laboratorioService.GuardarLaboratorio(laboratorio);

                string accion = _laboratorioSeleccionado == null ? "agregado" : "actualizado";
                MessageBox.Show($"Laboratorio {accion} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_laboratorioSeleccionado == null) return;

            var confirm = MessageBox.Show($"¿Seguro que desea eliminar el laboratorio '{_laboratorioSeleccionado.Nombre}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _laboratorioService.EliminarLaboratorio(_laboratorioSeleccionado.Id);
                    MessageBox.Show("Registro eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                catch (Microsoft.Data.Sqlite.SqliteException)
                {
                    MessageBox.Show("No se puede eliminar este laboratorio porque ya tiene mantenimientos registrados.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvLaboratorios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si hace clic en espacio vacío, limpia todo
            if (e.RowIndex < 0)
            {
                LimpiarFormulario();
                return;
            }

            _laboratorioSeleccionado = dgvLaboratorios.Rows[e.RowIndex].DataBoundItem as Laboratorio;

            if (_laboratorioSeleccionado != null)
            {
                txtNombre.Text = _laboratorioSeleccionado.Nombre;
                cmbUbicacion.SelectedValue = _laboratorioSeleccionado.EdificioId;
                cmbResponsableSistemas.SelectedValue = _laboratorioSeleccionado.ResponsableSistemasId;
                cmbAreaResponsable.SelectedValue = _laboratorioSeleccionado.AreaId;
                nudCantidadEquipos.Value = _laboratorioSeleccionado.CantidadEquipos;

                // CAMBIO VISUAL A MODO "EDICIÓN"
                btnGuardar.Text = "Actualizar";
                btnEliminar.Enabled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del laboratorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbUbicacion.SelectedValue == null || (int)cmbUbicacion.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar una ubicación (Edificio).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbResponsableSistemas.SelectedValue == null || (int)cmbResponsableSistemas.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar un responsable de sistemas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbAreaResponsable.SelectedValue == null || (int)cmbAreaResponsable.SelectedValue == 0)
            {
                MessageBox.Show("Debe seleccionar un área responsable.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _laboratorioSeleccionado = null;

            txtNombre.Clear();
            if (cmbUbicacion.Items.Count > 0) cmbUbicacion.SelectedIndex = 0;
            if (cmbResponsableSistemas.Items.Count > 0) cmbResponsableSistemas.SelectedIndex = 0;
            if (cmbAreaResponsable.Items.Count > 0) cmbAreaResponsable.SelectedIndex = 0;
            nudCantidadEquipos.Value = 0;

            dgvLaboratorios.ClearSelection();

            // CAMBIO VISUAL A MODO "NUEVO REGISTRO"
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
        }
    }
}
