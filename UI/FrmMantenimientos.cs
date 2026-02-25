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
        private readonly MantenimientoService _service = new MantenimientoService();
        private readonly TipoEquipoRepository _tipoEquipoRepository = new TipoEquipoRepository();
        private readonly TipoMantenimientoService _tipoMantenimientoService = new TipoMantenimientoService();
        public FrmMantenimientos()
        {
            InitializeComponent();

            // Eventos principales
            this.Load += FrmMantenimientos_Load;
            btnGenerar.Click += BtnGenerar_Click;

            // Eventos para escuchar cuando el usuario cambia la selección de los combos
            cmbTipoMantenimiento.SelectedIndexChanged += Combos_SelectedIndexChanged;
            cmbTipoEquipo.SelectedIndexChanged += Combos_SelectedIndexChanged;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmMantenimientos_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            EvaluarEstadoBoton();
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

        // =========================
        // VALIDACIÓN DINÁMICA
        // =========================
        private void Combos_SelectedIndexChanged(object? sender, EventArgs e)
        {
            EvaluarEstadoBoton();
        }

        private void EvaluarEstadoBoton()
        {
            // Verificamos que ambos combos tengan un valor válido (Id > 0)
            bool tipoMantValido = cmbTipoMantenimiento.SelectedValue is int idMant && idMant > 0;
            bool tipoEquipoValido = cmbTipoEquipo.SelectedValue is int idEq && idEq > 0;

            // El botón solo se enciende si AMBOS son válidos
            btnGenerar.Enabled = tipoMantValido && tipoEquipoValido;
        }

        private void BtnGenerar_Click(object? sender, EventArgs e)
        {
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
                int tipoEquipoId = (int)cmbTipoEquipo.SelectedValue!;
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
