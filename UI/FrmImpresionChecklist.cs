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
    public partial class FrmImpresionChecklist : Form
    {
        private readonly AdministrativoRepository _adminRepo;
        private readonly MantenimientoReportService _reportService;

        public FrmImpresionChecklist()
        {
            InitializeComponent();
            _adminRepo = new AdministrativoRepository();
            _reportService = new MantenimientoReportService();
            this.Load += FrmImpresionChecklist_Load;
            btnImprimir.Click += BtnImprimir_Click;
        }

        private void FrmImpresionChecklist_Load(object? sender, EventArgs e)
        {
            // Cargar administrativos
            var admins = _adminRepo.GetAll();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo,
                admins,
                "NombreCompleto",
                "Id",
                new Domain.Administrativo { Id = 0, NombreCompleto = "Seleccione..." }
            );
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbAdministrativo.SelectedValue) == 0)
            {
                MessageBox.Show("Seleccione un administrativo.", "Aviso");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                int adminId = Convert.ToInt32(cmbAdministrativo.SelectedValue);
                string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

                // Generar PDF
                string rutaPdf = _reportService.GenerarPdfPorAdministrativo(adminId, fecha);

                // Abrir el PDF automáticamente
                MessageBox.Show("PDF Generado correctamente.", "Éxito");

                var p = new Process();
                p.StartInfo = new ProcessStartInfo(rutaPdf) { UseShellExecute = true };
                p.Start();
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
