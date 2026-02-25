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
    public partial class FrmMantenimientosPorArea : Form
    {
        private readonly MantenimientoService _service = new MantenimientoService();
        private readonly TipoEquipoRepository _tipoEquipoRepo = new TipoEquipoRepository();
        private readonly AreaRepository _areaRepo = new AreaRepository();
        private readonly TipoMantenimientoService _tipoMantenimientoService = new TipoMantenimientoService();
        public FrmMantenimientosPorArea()
        {
            InitializeComponent();
            this.Load += FrmMantenimientosPorArea_Load;
            btnGenerar.Click += BtnGenerar_Click;

            // Eventos para escuchar cuando el usuario cambia la selección de los combos
            cmbArea.SelectedIndexChanged += Combos_SelectedIndexChanged;
            cmbTipoEquipo.SelectedIndexChanged += Combos_SelectedIndexChanged;
            cmbTipoMantenimiento.SelectedIndexChanged += Combos_SelectedIndexChanged;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmMantenimientosPorArea_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            EvaluarEstadoBoton();
        }

        private void CargarCombos()
        {
            // 1. Áreas
            var areas = _areaRepo.GetAll();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbArea,
                areas,
                "Nombre",
                "Id",
                new Area { Id = 0, Nombre = "Selecciona una opción" } // Objeto dummy
            );

            // 2. Tipos de Equipo
            var tipos = _tipoEquipoRepo.GetAll();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbTipoEquipo,
                tipos,
                "Nombre",
                "Id",
                new TipoEquipo { Id = 0, Nombre = "Selecciona una opción" }
            );

            // 3. Tipos Mantenimiento
            var tiposMantenimiento = _tipoMantenimientoService.ObtenerTodos();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbTipoMantenimiento,
                tiposMantenimiento,
                "Nombre",
                "Id",
                new TipoMantenimiento { Id = 0, Nombre = "Selecciona una opción" }
            );
        }

        private void Combos_SelectedIndexChanged(object? sender, EventArgs e)
        {
            EvaluarEstadoBoton();
        }

        private void EvaluarEstadoBoton()
        {
            // Verificamos que LOS TRES combos tengan un valor válido (Id > 0)
            bool areaValida = cmbArea.SelectedValue is int idArea && idArea > 0;
            bool tipoEquipoValido = cmbTipoEquipo.SelectedValue is int idEq && idEq > 0;
            bool tipoMantValido = cmbTipoMantenimiento.SelectedValue is int idMant && idMant > 0;

            // El botón solo se enciende si TODOS son válidos
            btnGenerar.Enabled = areaValida && tipoEquipoValido && tipoMantValido;
        }

        private void BtnGenerar_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Se generarán mantenimientos para:\n" +
                $"Área: {cmbArea.Text}\n" +
                $"Equipo: {cmbTipoEquipo.Text}\n\n" +
                $"¿Confirmar?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;

                int areaId = Convert.ToInt32(cmbArea.SelectedValue);
                int tipoId = Convert.ToInt32(cmbTipoEquipo.SelectedValue);
                string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                string tipoMant = cmbTipoMantenimiento.Text;

                // Llamada al NUEVO método del servicio
                int cantidad = _service.GenerarChecklistPorAreaYTipo(areaId, tipoId, fecha, tipoMant);

                if (cantidad > 0)
                {
                    MessageBox.Show($"¡Éxito! Se generaron {cantidad} registros.", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontraron equipos asignados en esa área para este tipo.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

    }
}
