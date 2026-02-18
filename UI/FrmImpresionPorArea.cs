using AppEscritorioUPT.Data.Repositories;
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
        private readonly AreaRepository _areaRepo;
        private readonly MantenimientoReportService _reportService;

        public FrmImpresionPorArea()
        {
            InitializeComponent();
            _areaRepo = new AreaRepository();
            _reportService = new MantenimientoReportService();

            this.Load += FrmImpresionPorArea_Load;
            btnImprimir.Click += BtnImprimir_Click;
        }

        private void FrmImpresionPorArea_Load(object? sender, EventArgs e)
        {
            // Cargar Áreas
            var areas = _areaRepo.GetAll();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAreas,
                areas,
                "Nombre", // Asegúrate que tu clase Area tenga propiedad 'Nombre'
                "Id",
                new Domain.Area { Id = 0, Nombre = "Seleccione un Área..." }
            );
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbAreas.SelectedValue) == 0)
            {
                MessageBox.Show("Seleccione un Área.", "Aviso");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                int areaId = Convert.ToInt32(cmbAreas.SelectedValue);
                string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

                // Llamar al servicio por ÁREA
                string rutaPdf = _reportService.GenerarPdfPorArea(areaId, fecha);

                MessageBox.Show("Reporte generado correctamente.", "Éxito");

                // Abrir PDF
                new Process { StartInfo = new ProcessStartInfo(rutaPdf) { UseShellExecute = true } }.Start();
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
