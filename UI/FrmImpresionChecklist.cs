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
    public partial class FrmImpresionChecklist : Form
    {
        private readonly AdministrativoRepository _adminRepo = new AdministrativoRepository();
        private readonly MantenimientoReportService _reportService = new MantenimientoReportService();

        public FrmImpresionChecklist()
        {
            InitializeComponent();

            this.Load += FrmImpresionChecklist_Load;
            btnImprimir.Click += BtnImprimir_Click;
            cmbAdministrativo.SelectedIndexChanged += CmbAdministrativo_SelectedIndexChanged;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);

        }

        private void FrmImpresionChecklist_Load(object? sender, EventArgs e)
        {
            ConfigurarComboAdministrativo();
            CargarAdministrativos();

            // Evaluamos el botón al arrancar (se apagará por defecto)
            EvaluarEstadoBoton();
        }

        private void ConfigurarComboAdministrativo()
        {
            // Para que el usuario pueda escribir y buscar rápidamente
            cmbAdministrativo.DropDownStyle = ComboBoxStyle.DropDown;
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CargarAdministrativos()
        {
            // Traemos los datos y los ordenamos alfabéticamente
            var admins = _adminRepo.GetAll().OrderBy(a => a.NombreCompleto).ToList();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo,
                admins,
                displayMember: "NombreCompleto",
                valueMember: "Id",
                itemDefault: new Administrativo { Id = 0, NombreCompleto = "Selecciona una opción" }
            );
        }

        private void CmbAdministrativo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            EvaluarEstadoBoton();
        }

        private void EvaluarEstadoBoton()
        {
            // El botón solo se enciende si se seleccionó un Administrativo válido (Id > 0)
            btnImprimir.Enabled = cmbAdministrativo.SelectedValue is int idAdmin && idAdmin > 0;
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int adminId = Convert.ToInt32(cmbAdministrativo.SelectedValue);
                string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

                // Generar PDF
                string rutaPdf = _reportService.GenerarPdfPorAdministrativo(adminId, fecha);

                // Abrir el PDF automáticamente
                MessageBox.Show("PDF Generado correctamente.", "Éxito");

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
