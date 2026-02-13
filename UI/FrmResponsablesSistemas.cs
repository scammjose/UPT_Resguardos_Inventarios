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
using AppEscritorioUPT.Helpers;

namespace AppEscritorioUPT.UI
{
    public partial class FrmResponsablesSistemas : Form
    {
        private readonly AdministrativoService _administrativoService = new AdministrativoService();
        private readonly ResponsableSistemasService _responsableService = new ResponsableSistemasService();

        private ResponsableSistemas? _responsableSeleccionado;

        public FrmResponsablesSistemas()
        {
            InitializeComponent();

            this.Load += FrmResponsablesSistemas_Load;
            btnAgregar.Click += BtnAgregar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            dgvResponsables.CellClick += DgvResponsables_CellClick;
        }

        // ===== EVENTO LOAD =====
        private void FrmResponsablesSistemas_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarAdministrativos();
            CargarResponsables();
        }

        // ===== CONFIGURACIÓN GRID =====
        private void ConfigurarGrid()
        {
            dgvResponsables.ReadOnly = true;
            dgvResponsables.MultiSelect = false;
            dgvResponsables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResponsables.AllowUserToAddRows = false;
            dgvResponsables.AllowUserToDeleteRows = false;
            dgvResponsables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ===== CARGA DE DATOS =====
        private void CargarAdministrativos()
        {
            // Obtenemos todos los administrativos
            var lista = _administrativoService
                .ObtenerAdministrativos()      // <-- usa el método que ya tengas en tu service
                .OrderBy(a => a.NombreCompleto);

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo,
                lista,
                displayMember: "NombreCompleto",
                valueMember: "Id",
                itemDefault: new Administrativo
                {
                    Id = 0,
                    NombreCompleto = "Selecciona una opción"
                }
            );
        }

        private void CargarResponsables()
        {
            var lista = _responsableService.ObtenerResponsables().ToList();
            dgvResponsables.DataSource = lista;

            if (dgvResponsables.Columns["Id"] != null)
                dgvResponsables.Columns["Id"].Visible = false;

            if (dgvResponsables.Columns["AdministrativoId"] != null)
                dgvResponsables.Columns["AdministrativoId"].Visible = false;

            if (dgvResponsables.Columns["AdministrativoNombre"] != null)
                dgvResponsables.Columns["AdministrativoNombre"].HeaderText = "Nombre";

            if (dgvResponsables.Columns["AreaNombre"] != null)
                dgvResponsables.Columns["AreaNombre"].HeaderText = "Área";
        }

        // ===== UTILIDADES =====
        private void LimpiarSeleccion()
        {
            _responsableSeleccionado = null;
            dgvResponsables.ClearSelection();
            if (cmbAdministrativo.Items.Count > 0)
                cmbAdministrativo.SelectedIndex = 0;
        }

        private bool Validar()
        {
            if (cmbAdministrativo.SelectedValue is not int adminId || adminId <= 0)
            {
                MessageBox.Show("Debe seleccionar un administrativo válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAdministrativo.Focus();
                return false;
            }

            return true;
        }

        // ===== EVENTOS DE BOTÓN =====
        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                var adminId = (int)cmbAdministrativo.SelectedValue!;  // ya validado
                _responsableService.AgregarResponsable(adminId);
                CargarResponsables();
                LimpiarSeleccion();

                MessageBox.Show("Responsable de sistemas agregado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_responsableSeleccionado == null)
            {
                MessageBox.Show("Seleccione un responsable en la tabla para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Seguro que desea eliminar a '{_responsableSeleccionado.AdministrativoNombre}' como responsable de sistemas?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _responsableService.EliminarResponsable(_responsableSeleccionado.Id);
                    CargarResponsables();
                    LimpiarSeleccion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ===== SELECCIÓN EN GRID =====
        private void DgvResponsables_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                LimpiarSeleccion();
                return;
            }

            var fila = dgvResponsables.Rows[e.RowIndex];

            if (fila.DataBoundItem is ResponsableSistemas resp)
            {
                _responsableSeleccionado = resp;

                // Sincronizar combo con el administrativo de ese responsable
                cmbAdministrativo.SelectedValue = resp.AdministrativoId;
            }
        }

    }
}
