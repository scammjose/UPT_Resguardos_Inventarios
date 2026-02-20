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
    public partial class FrmEdificios : Form
    {
        private readonly EdificioService _edificioService;
        private readonly ResponsableSistemasRepository _responsableRepo;

        private Edificio? _edificioSeleccionado = null;

        public FrmEdificios()
        {
            InitializeComponent();
            _edificioService = new EdificioService();
            _responsableRepo = new ResponsableSistemasRepository();

            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmEdificios_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnActualizar.Click += BtnActualizar_Click; // Tu nuevo botón
            btnEliminar.Click += BtnEliminar_Click;

            // Configurar DataGridView
            dgvEdificios.ReadOnly = true;
            dgvEdificios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEdificios.MultiSelect = false;
            dgvEdificios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvEdificios.AllowUserToAddRows = false;

            // Evento para cuando se hace clic en una fila o en el fondo
            dgvEdificios.CellClick += DgvEdificios_CellClick;
        }

        private void FrmEdificios_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            CargarGrid();
        }

        private void CargarCombos()
        {
            try
            {
                // Consumimos el método que acabas de crear
                var responsables = _responsableRepo.GetAll();

                var responsableDefault = new ResponsableSistemas
                {
                    Id = 0,
                    AdministrativoNombre = "Seleccione un responsable..."
                };

                // 3. Usamos tu Helper
                ComboBoxHelper.CargarConSeleccionDefault(
                    cmbResponsable,
                    responsables,
                    "AdministrativoNombre", // Lo que se muestra
                    "Id",                   // Lo que se guarda
                    responsableDefault
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar responsables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrid()
        {
            try
            {
                var lista = _edificioService.ObtenerTodos();
                dgvEdificios.DataSource = lista;

                // Ocultar columnas internas
                if (dgvEdificios.Columns["Id"] != null)
                    dgvEdificios.Columns["Id"].Visible = false;

                if (dgvEdificios.Columns["ResponsableSistemasId"] != null)
                    dgvEdificios.Columns["ResponsableSistemasId"].Visible = false;

                // Nombres amigables
                if (dgvEdificios.Columns["CantidadAulas"] != null)
                    dgvEdificios.Columns["CantidadAulas"].HeaderText = "No. Aulas";

                if (dgvEdificios.Columns["ResponsableNombre"] != null)
                    dgvEdificios.Columns["ResponsableNombre"].HeaderText = "Responsable Asignado";

                // Limpiamos los campos visualmente después de recargar
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar edificios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN GUARDAR (NUEVO REGISTRO) ---
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var edificio = new Edificio
                {
                    Id = 0, // Siempre 0 para forzar que sea un INSERT
                    Nombre = txtNombre.Text.Trim(),
                    Ubicacion = txtUbicacion.Text.Trim(),
                    CantidadAulas = (int)nudCantidadAulas.Value,
                    ResponsableSistemasId = Convert.ToInt32(cmbResponsable.SelectedValue)
                };

                _edificioService.GuardarEdificio(edificio);

                MessageBox.Show("Edificio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid(); // Esto también llama a LimpiarFormulario() internamente
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN ACTUALIZAR (MODIFICAR REGISTRO EXISTENTE) ---
        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            if (_edificioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un edificio de la tabla para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                var edificio = new Edificio
                {
                    Id = _edificioSeleccionado.Id, // Usamos el ID del seleccionado para forzar UPDATE
                    Nombre = txtNombre.Text.Trim(),
                    Ubicacion = txtUbicacion.Text.Trim(),
                    CantidadAulas = (int)nudCantidadAulas.Value,
                    ResponsableSistemasId = Convert.ToInt32(cmbResponsable.SelectedValue)
                };

                _edificioService.GuardarEdificio(edificio);

                MessageBox.Show("Edificio actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN ELIMINAR ---
        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_edificioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un edificio para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show($"¿Seguro que desea eliminar el edificio '{_edificioSeleccionado.Nombre}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _edificioService.EliminarEdificio(_edificioSeleccionado.Id);

                    MessageBox.Show("Edificio eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvEdificios_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si hace clic fuera de las filas (ej. encabezado), limpiamos
            if (e.RowIndex < 0)
            {
                LimpiarFormulario();
                return;
            }

            _edificioSeleccionado = dgvEdificios.Rows[e.RowIndex].DataBoundItem as Edificio;

            if (_edificioSeleccionado != null)
            {
                txtNombre.Text = _edificioSeleccionado.Nombre;
                txtUbicacion.Text = _edificioSeleccionado.Ubicacion;
                nudCantidadAulas.Value = _edificioSeleccionado.CantidadAulas > 0 ? _edificioSeleccionado.CantidadAulas : 1;
                cmbResponsable.SelectedValue = _edificioSeleccionado.ResponsableSistemasId;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del edificio es obligatorio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbResponsable.SelectedValue == null || Convert.ToInt32(cmbResponsable.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar un Responsable de Sistemas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _edificioSeleccionado = null;
            txtNombre.Clear();
            txtUbicacion.Clear();
            nudCantidadAulas.Value = 1;

            if (cmbResponsable.Items.Count > 0)
                cmbResponsable.SelectedIndex = 0;

            dgvEdificios.ClearSelection();
        }
    }
}
