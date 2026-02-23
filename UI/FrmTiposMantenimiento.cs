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
    public partial class FrmTiposMantenimiento : Form
    {
        private readonly TipoMantenimientoService _tipoService;
        private TipoMantenimiento? _tipoSeleccionado = null;

        public FrmTiposMantenimiento()
        {
            InitializeComponent();
            _tipoService = new TipoMantenimientoService();

            this.Load += FrmTiposMantenimiento_Load;
            this.Shown += FrmTiposMantenimiento_Shown;

            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            dgvTiposMantenimiento.CellClick += DgvTiposMantenimiento_CellClick;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmTiposMantenimiento_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarGrid();
        }

        private void FrmTiposMantenimiento_Shown(object? sender, EventArgs e)
        {
            // Windows ya pintó todo, limpiamos la selección
            LimpiarFormulario();
        }

        // ===== CONFIGURACIÓN GRID =====
        private void ConfigurarGrid()
        {
            // Las demás reglas las aplica el UIConfigHelper
            // MAGIA PARA EL SCROLL: AllCells obliga a la columna a medir lo que mida el texto.
            dgvTiposMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GestionarBotones(bool esNuevo = true)
        {
            // Adaptamos la lógica para tu botón dinámico
            btnGuardar.Text = esNuevo ? "Guardar" : "Actualizar";
            btnEliminar.Enabled = !esNuevo;
        }

        private void LimpiarFormulario()
        {
            _tipoSeleccionado = null;
            txtNombre.Clear();

            dgvTiposMantenimiento.ClearSelection();
            GestionarBotones();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

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
                LimpiarFormulario();
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
                    LimpiarFormulario();
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
                GestionarBotones(false); // Habilitamos el botón
            }
        }
    }
}
