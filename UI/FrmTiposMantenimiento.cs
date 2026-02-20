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
    public partial class FrmTiposMantenimiento : Form
    {
        private readonly TipoMantenimientoService _tipoService;
        private TipoMantenimiento? _tipoSeleccionado = null;

        public FrmTiposMantenimiento()
        {
            InitializeComponent();
            _tipoService = new TipoMantenimientoService();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmTiposMantenimiento_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            // Configuración del DataGridView
            dgvTiposMantenimiento.ReadOnly = true;
            dgvTiposMantenimiento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiposMantenimiento.MultiSelect = false;
            dgvTiposMantenimiento.AllowUserToAddRows = false;

            // MAGIA PARA EL SCROLL: AllCells obliga a la columna a medir lo que mida el texto.
            // Si el texto es más ancho que la tabla, aparece el scroll horizontal automáticamente.
            dgvTiposMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvTiposMantenimiento.CellClick += DgvTiposMantenimiento_CellClick;
        }

        private void FrmTiposMantenimiento_Load(object? sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            try
            {
                var lista = _tipoService.ObtenerTodos();
                dgvTiposMantenimiento.DataSource = lista;

                // Ocultamos la columna del Id interno
                if (dgvTiposMantenimiento.Columns["Id"] != null)
                    dgvTiposMantenimiento.Columns["Id"].Visible = false;

                // Ajustamos el título de la columna principal
                if (dgvTiposMantenimiento.Columns["Nombre"] != null)
                    dgvTiposMantenimiento.Columns["Nombre"].HeaderText = "Tipo de Mantenimiento";

                LimpiarFormulario(); // Reseteamos el estado visual
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Si _tipoSeleccionado es null, creamos uno nuevo (Id = 0).
                // Si no es null, reutilizamos su Id para que el Servicio sepa que es un UPDATE.
                var tipo = new TipoMantenimiento
                {
                    Id = _tipoSeleccionado?.Id ?? 0,
                    Nombre = txtNombre.Text.Trim()
                };

                _tipoService.GuardarTipoMantenimiento(tipo);

                string accion = _tipoSeleccionado == null ? "agregado" : "actualizado";
                MessageBox.Show($"Tipo de mantenimiento {accion} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid(); // Al cargar el grid, se limpia el formulario automáticamente
            }
            catch (Exception ex)
            {
                // Aquí atrapamos si intentan guardar un nombre repetido
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_tipoSeleccionado == null) return;

            var confirm = MessageBox.Show($"¿Seguro que desea eliminar el tipo '{_tipoSeleccionado.Nombre}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _tipoService.EliminarTipoMantenimiento(_tipoSeleccionado.Id);
                    MessageBox.Show("Registro eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                }
                catch (Microsoft.Data.Sqlite.SqliteException)
                {
                    // Si el Tipo ya está en uso en un Mantenimiento de Aula, la BD no dejará borrarlo.
                    MessageBox.Show("No se puede eliminar este tipo de mantenimiento porque ya está siendo utilizado en un registro existente.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvTiposMantenimiento_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si el usuario hace clic en el área gris vacía de la tabla (fuera de las filas)
            // reseteamos el formulario para que pueda agregar uno nuevo.
            if (e.RowIndex < 0)
            {
                LimpiarFormulario();
                return;
            }

            // Seleccionamos la fila
            _tipoSeleccionado = dgvTiposMantenimiento.Rows[e.RowIndex].DataBoundItem as TipoMantenimiento;

            if (_tipoSeleccionado != null)
            {
                txtNombre.Text = _tipoSeleccionado.Nombre;

                // Cambiamos el comportamiento visual
                btnGuardar.Text = "Actualizar";
                btnEliminar.Enabled = true; // Habilitamos el botón
            }
        }

        private void LimpiarFormulario()
        {
            _tipoSeleccionado = null;
            txtNombre.Clear();

            // Reseteamos el comportamiento visual
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false; // Bloqueamos el botón

            dgvTiposMantenimiento.ClearSelection();
        }
    }
}
