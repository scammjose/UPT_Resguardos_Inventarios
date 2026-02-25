using AppEscritorioUPT.Data.Dto;
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
    public partial class FrmHistorialMantenimientos : Form
    {
        private readonly MantenimientoService _service = new MantenimientoService();
        private int _idSeleccionado = 0; // Para saber qué registro estamos editando
        public FrmHistorialMantenimientos()
        {
            InitializeComponent();

            this.Load += FrmHistorialMantenimientos_Load;
            dtpFiltro.ValueChanged += DtpFiltro_ValueChanged;
            dgvMantenimientos.CellClick += DgvMantenimientos_CellClick;
            btnGuardarCambios.Click += BtnGuardarCambios_Click;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmHistorialMantenimientos_Load(object? sender, EventArgs e)
        {
            //dgvMantenimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LimpiarEdicion();
            // Cargar datos de la fecha actual al iniciar
            CargarGrid(dtpFiltro.Value);
        }

        private void DtpFiltro_ValueChanged(object? sender, EventArgs e)
        {
            CargarGrid(dtpFiltro.Value);
        }

        private void CargarGrid(DateTime fecha)
        {
            try
            {
                string fechaStr = fecha.ToString("yyyy-MM-dd");
                var lista = _service.ObtenerHistorialPorFecha(fechaStr);
                dgvMantenimientos.DataSource = lista;

                // Ocultar columna ID visualmente si quieres
                if (dgvMantenimientos.Columns["Id"] != null)
                    dgvMantenimientos.Columns["Id"].Visible = false;

                // Limpiar selección previa
                LimpiarEdicion();
                dgvMantenimientos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}");
            }
        }

        private void HabilitarEdicion(bool habilitar)
        {
            btnGuardarCambios.Enabled = habilitar;
            dtpEditarFecha.Enabled = habilitar;
            txtEditarObservaciones.Enabled = habilitar;
        }

        private void LimpiarEdicion()
        {
            _idSeleccionado = 0;
            txtEditarObservaciones.Clear();
            dtpEditarFecha.Value = DateTime.Now;
            HabilitarEdicion(false);
        }

        private void DgvMantenimientos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si se hace clic en el encabezado o fuera de las filas
            if (e.RowIndex < 0)
            {
                dgvMantenimientos.ClearSelection(); // Quita cualquier selección
                LimpiarEdicion();       // Limpia los controles y _adminSeleccionado
                return;
            }

            // Obtener el objeto seleccionado
            var fila = dgvMantenimientos.Rows[e.RowIndex].DataBoundItem as MantenimientoDetalleDto;

            if (fila != null)
            {
                _idSeleccionado = fila.Id;

                // Cargar datos en los controles de edición
                // Convertimos el string YYYY-MM-DD de vuelta a DateTime para el picker
                if (DateTime.TryParse(fila.Fecha, out DateTime fechaMantenimiento))
                {
                    dtpEditarFecha.Value = fechaMantenimiento;
                }

                txtEditarObservaciones.Text = fila.Observaciones;

                HabilitarEdicion(true);
            }
        }

        private void BtnGuardarCambios_Click(object? sender, EventArgs e)
        {
            if (_idSeleccionado == 0) return;

            if (MessageBox.Show("¿Deseas actualizar este registro?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                string nuevaFecha = dtpEditarFecha.Value.ToString("yyyy-MM-dd");
                string nuevasObs = txtEditarObservaciones.Text.Trim();

                // Llamada al servicio
                _service.ActualizarMantenimiento(_idSeleccionado, nuevaFecha, nuevasObs);

                MessageBox.Show("Registro actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar la tabla para ver cambios (usamos la fecha del filtro original, no la nueva)
                CargarGrid(dtpFiltro.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
