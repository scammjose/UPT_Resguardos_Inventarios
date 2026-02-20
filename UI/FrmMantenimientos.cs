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
    public partial class FrmMantenimientos : Form
    {
        private readonly MantenimientoService _service;
        private readonly TipoEquipoRepository _tipoEquipoRepository;
        private readonly TipoMantenimientoService _tipoMantenimientoService;
        public FrmMantenimientos()
        {
            InitializeComponent();
            _service = new MantenimientoService();
            _tipoEquipoRepository = new TipoEquipoRepository();
            _tipoMantenimientoService = new TipoMantenimientoService();

            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Load += FrmMantenimientos_Load;
            btnGenerar.Click += BtnGenerar_Click;
        }

        private void FrmMantenimientos_Load(object? sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            var tiposMantenimiento = _tipoMantenimientoService.ObtenerTodos();
            // 1. Cargar Tipos de Mantenimiento
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbTipoMantenimiento,
                tiposMantenimiento,
                "Nombre",
                "Id",
                new TipoMantenimiento { Id = 0, Nombre = "Selecciona una opción" }
            );

            // 2. Cargar Tipos de Equipo
            var tipos = _tipoEquipoRepository.GetAll();

            // CORRECCIÓN: Agregamos el 5º parámetro creando el objeto default al vuelo
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbTipoEquipo,
                tipos,
                "Nombre",
                "Id",
                new TipoEquipo { Id = 0, Nombre = "Selecciona una opción" } // <--- Este faltaba
            );
        }

        private void BtnGenerar_Click(object? sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrEmpty(cmbTipoMantenimiento.Text))
            {
                MessageBox.Show("Selecciona el tipo de mantenimiento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que se haya seleccionado un Tipo de Equipo real (Id != 0)
            if (cmbTipoEquipo.SelectedValue == null || (int)cmbTipoEquipo.SelectedValue == 0)
            {
                MessageBox.Show("Por favor selecciona un Tipo de Equipo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación
            var confirm = MessageBox.Show(
                $"Se generarán los checklist para TODOS los equipos del tipo '{cmbTipoEquipo.Text}'.\n¿Deseas continuar?",
                "Confirmar Generación Masiva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;

                // Datos para el servicio
                int tipoEquipoId = (int)cmbTipoEquipo.SelectedValue;
                string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                string tipoMant = cmbTipoMantenimiento.Text;

                // Ejecutar lógica
                int cantidad = _service.GenerarChecklistPorTipoEquipo(tipoEquipoId, fecha, tipoMant);

                if (cantidad > 0)
                {
                    MessageBox.Show($"¡Proceso finalizado!\nSe generaron {cantidad} registros de mantenimiento.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se generaron registros.\nVerifica que existan equipos resguardados de este tipo o que no se hayan generado ya para la fecha seleccionada.",
                        "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

    }
}
