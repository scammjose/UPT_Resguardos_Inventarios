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
using AppEscritorioUPT.Helpers;
using AppEscritorioUPT.Services;

namespace AppEscritorioUPT.UI
{
    public partial class FrmTiposEquipos : Form
    {
        private readonly TipoEquipoService _service = new TipoEquipoService();
        private TipoEquipo? _tipoSeleccionado;
        public FrmTiposEquipos()
        {
            InitializeComponent();

            this.Load += FrmTiposEquipos_Load;

            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            dgvTipos.CellClick += DgvTipos_CellClick;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmTiposEquipos_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarTipos();
            LimpiarFormulario();
        }

        private void ConfigurarGrid()
        {
            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarTipos()
        {
            var lista = _service.ObtenerTipos().ToList();
            dgvTipos.DataSource = lista;

            if (dgvTipos.Columns["Id"] != null)
            {
                dgvTipos.Columns["Id"].Visible = false;
            }
        }

        private void GestionarBotones(bool esNuevo = true)
        {
            btnAgregar.Enabled = esNuevo;             // Si es nuevo, enciende Agregar
            btnActualizar.Enabled = !esNuevo;         // Lo contrario
            btnEliminar.Enabled = !esNuevo;           // Lo contrario
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            _tipoSeleccionado = null;
            GestionarBotones();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del tipo de equipo es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                _service.CrearTipo(txtNombre.Text);
                CargarTipos();
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
            if (_tipoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un tipo de equipo de la tabla.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Validar()) return;

            try
            {
                _tipoSeleccionado.Nombre = txtNombre.Text;
                _service.ActualizarTipo(_tipoSeleccionado);

                CargarTipos();
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
            if (_tipoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un tipo de equipo para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Seguro que desea eliminar el tipo '{_tipoSeleccionado.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _service.EliminarTipo(_tipoSeleccionado.Id);
                    CargarTipos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvTipos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si se hace clic en el encabezado o fuera de las filas
            if (e.RowIndex < 0)
            {
                dgvTipos.ClearSelection(); // Quita cualquier selección
                LimpiarFormulario();       // Limpia los controles y _adminSeleccionado
                return;
            }

            var fila = dgvTipos.Rows[e.RowIndex];

            if (fila.DataBoundItem is TipoEquipo tipo)
            {
                _tipoSeleccionado = tipo;
                txtNombre.Text = tipo.Nombre;
                GestionarBotones(false);
            }
        }

    }
}
