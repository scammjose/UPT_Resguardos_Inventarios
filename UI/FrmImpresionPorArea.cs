using AppEscritorioUPT.Data.Repositories;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Helpers;
using AppEscritorioUPT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscritorioUPT.UI
{
    public partial class FrmImpresionPorArea : Form
    {
        private readonly AreaRepository _areaRepo = new AreaRepository();
        private readonly MantenimientoReportService _reportService = new MantenimientoReportService();

        public FrmImpresionPorArea()
        {
            InitializeComponent();

            this.Load += FrmImpresionPorArea_Load;
            btnImprimir.Click += BtnImprimir_Click;
            cmbAreas.SelectedIndexChanged += CmbAreas_SelectedIndexChanged;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmImpresionPorArea_Load(object? sender, EventArgs e)
        {
            ConfigurarComboArea();
            CargarAreas();

            // Evaluamos el botón al arrancar (se apagará por defecto)
            EvaluarEstadoBoton();
        }

        private void ConfigurarComboArea()
        {
            // Para que el usuario pueda escribir y buscar rápidamente
            cmbAreas.DropDownStyle = ComboBoxStyle.DropDown;
            cmbAreas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAreas.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CargarAreas()
        {
            // Traemos los datos y los ordenamos alfabéticamente
            var areas = _areaRepo.GetAll().OrderBy(a => a.Nombre).ToList();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAreas,
                areas,
                displayMember: "Nombre",
                valueMember: "Id",
                itemDefault: new Area { Id = 0, Nombre = "Seleccione un Área..." }
            );
        }

        // =========================
        // VALIDACIÓN DINÁMICA
        // =========================
        private void CmbAreas_SelectedIndexChanged(object? sender, EventArgs e)
        {
            EvaluarEstadoBoton();
        }

        private void EvaluarEstadoBoton()
        {
            // El botón solo se enciende si se seleccionó un Área válida (Id > 0)
            btnImprimir.Enabled = cmbAreas.SelectedValue is int idArea && idArea > 0;
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int areaId = Convert.ToInt32(cmbAreas.SelectedValue);
                string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

                // Llamar al servicio por ÁREA
                string rutaPdf = _reportService.GenerarPdfPorArea(areaId, fecha);

                MessageBox.Show("Reporte generado correctamente.", "Éxito");

                // Abrir PDF
                var psi = new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    UseShellExecute = true
                };
                Process.Start(psi);
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
