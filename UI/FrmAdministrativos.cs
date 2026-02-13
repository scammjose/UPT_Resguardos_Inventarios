using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Services;
using AppEscritorioUPT.Helpers;

namespace AppEscritorioUPT.UI
{
    public partial class FrmAdministrativos : Form
    {
        private readonly AdministrativoService _adminService = new AdministrativoService();
        private readonly AreaService _areaService = new AreaService();

        private Administrativo? _adminSeleccionado;
        public FrmAdministrativos()
        {
            InitializeComponent();
            this.Load += FrmAdministrativos_Load;

            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            dgvAdministrativos.CellClick += DgvAdministrativos_CellClick;
        }

        private void FrmAdministrativos_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarAreasCombo();
            CargarAdministrativos();

            // 🔹 Que solo puedan seleccionar (no escribir texto libre)
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;

            // 🔹 Ancho del desplegable (ajusta el número a tu gusto)
            cmbArea.DropDownWidth = 400;
        }

        private void ConfigurarGrid()
        {
            dgvAdministrativos.ReadOnly = true;
            dgvAdministrativos.MultiSelect = false;
            dgvAdministrativos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdministrativos.AllowUserToAddRows = false;
            dgvAdministrativos.AllowUserToDeleteRows = false;
            dgvAdministrativos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarAreasCombo()
        {
            var areas = _areaService.ObtenerAreas();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbArea,
                areas,
                displayMember: "Nombre",
                valueMember: "Id",
                itemDefault: new Area
                {
                    Id = 0,
                    Nombre = "Selecciona una opción"
                }
            );
        }

        private void CargarAdministrativos()
        {
            var admins = _adminService.ObtenerAdministrativos().ToList();
            var areas = _areaService.ObtenerAreas().ToList();

            // Asignar el nombre del área a cada administrativo
            foreach (var admin in admins)
            {
                admin.AreaNombre = areas
                    .FirstOrDefault(a => a.Id == admin.AreaId)?.Nombre ?? string.Empty;
            }

            dgvAdministrativos.DataSource = admins;

            // Ocultar columnas que no quieres ver
            if (dgvAdministrativos.Columns["Id"] != null)
                dgvAdministrativos.Columns["Id"].Visible = false;

            if (dgvAdministrativos.Columns["AreaId"] != null)
                dgvAdministrativos.Columns["AreaId"].Visible = false;

            // Cambiar encabezado de AreaNombre
            if (dgvAdministrativos.Columns["AreaNombre"] != null)
                dgvAdministrativos.Columns["AreaNombre"].HeaderText = "Área";
        }

        private void LimpiarFormulario()
        {
            txtNombreCompleto.Text = string.Empty;
            txtPuesto.Text = string.Empty;
            _adminSeleccionado = null;

            if (cmbArea.Items.Count > 0)
                cmbArea.SelectedIndex = 0;
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("El nombre del administrativo es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return false;
            }

            if (cmbArea.SelectedValue is not int areaId || areaId <= 0)
            {
                MessageBox.Show("Debe seleccionar un área.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbArea.Focus();
                return false;
            }

            return true;
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                var nombre = txtNombreCompleto.Text;
                var puesto = txtPuesto.Text;
                var areaId = (int)cmbArea.SelectedValue!;

                _adminService.CrearAdministrativo(nombre, puesto, areaId);

                CargarAdministrativos();
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
            if (_adminSeleccionado == null)
            {
                MessageBox.Show("Seleccione un administrativo de la tabla.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Validar()) return;

            try
            {
                _adminSeleccionado.NombreCompleto = txtNombreCompleto.Text;
                _adminSeleccionado.Puesto = txtPuesto.Text;
                _adminSeleccionado.AreaId = (int)cmbArea.SelectedValue!;
                _adminService.ActualizarAdministrativo(_adminSeleccionado);

                CargarAdministrativos();
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
            if (_adminSeleccionado == null)
            {
                MessageBox.Show("Seleccione un administrativo para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Seguro que desea eliminar al administrativo '{_adminSeleccionado.NombreCompleto}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _adminService.EliminarAdministrativo(_adminSeleccionado.Id);
                    CargarAdministrativos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvAdministrativos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si se hace clic en el encabezado o fuera de las filas
            if (e.RowIndex < 0)
            {
                dgvAdministrativos.ClearSelection(); // Quita cualquier selección
                LimpiarFormulario();                 // Limpia los controles y _adminSeleccionado
                return;
            }

            var fila = dgvAdministrativos.Rows[e.RowIndex];

            if (fila.DataBoundItem is Administrativo admin)
            {
                _adminSeleccionado = admin;
                txtNombreCompleto.Text = admin.NombreCompleto;
                txtPuesto.Text = admin.Puesto;

                // Sincronizar área seleccionada en el combo
                cmbArea.SelectedValue = admin.AreaId;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
