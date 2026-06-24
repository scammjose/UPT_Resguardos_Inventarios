using AppEscritorioUPT.Data.Dto;
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
    public partial class FrmTraspasoLotes : Form
    {
        private readonly ResguardoService _resguardoService = new ResguardoService();
        private readonly AdministrativoService _adminService = new AdministrativoService();
        private readonly ResponsableSistemasService _responsableService = new ResponsableSistemasService();
        private readonly ResguardoReportService _reportService = new ResguardoReportService();

        private string? _folioSeleccionado = null;

        public FrmTraspasoLotes()
        {
            InitializeComponent();
            this.Load += FrmTraspasoLotes_Load;
            cmbLoteOrigen.SelectionChangeCommitted += CmbLoteOrigen_SelectionChangeCommitted;
            btnTransferir.Click += BtnTransferir_Click;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmTraspasoLotes_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            ConfigurarGrid();
            btnTransferir.Enabled = false;
        }

        private void CargarCombos()
        {
            // 1. Lotes Origen
            var lotes = _resguardoService.ObtenerLotesDisponibles();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbLoteOrigen, lotes, "Descripcion", "FolioLote",
                new LoteResguardoDto { FolioLote = "", Descripcion = "Seleccione el Lote o Laboratorio a transferir..." }
            );

            // 2. Administrativo Destino
            var admins = _adminService.ObtenerAdministrativos().OrderBy(a => a.NombreCompleto).ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativoDestino, admins, "NombreCompleto", "Id",
                new Administrativo { Id = 0, NombreCompleto = "Seleccione al NUEVO Responsable..." }
            );

            // 3. Responsable de Sistemas
            var responsables = _responsableService.ObtenerResponsables().OrderBy(r => r.AdministrativoNombre).ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbResponsableSistemas, responsables, "AdministrativoNombre", "Id",
                new ResponsableSistemas { Id = 0, AdministrativoNombre = "Técnico que autoriza el cambio..." }
            );
        }

        private void ConfigurarGrid()
        {
            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.ReadOnly = true;
        }

        private void CmbLoteOrigen_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            if (cmbLoteOrigen.SelectedValue is string folio && !string.IsNullOrEmpty(folio))
            {
                _folioSeleccionado = folio;
                var lista = _resguardoService.ObtenerPorFolioLoteParaReporte(folio).ToList();
                dgvEquipos.DataSource = lista;

                // Ocultar IDs y basura
                foreach (DataGridViewColumn col in dgvEquipos.Columns) col.Visible = false;

                // Mostrar lo importante
                dgvEquipos.Columns["CodigoInventario"].Visible = true;
                dgvEquipos.Columns["CodigoInventario"].HeaderText = "Cód. UPT";

                dgvEquipos.Columns["EquipoNumeroSerie"].Visible = true;
                dgvEquipos.Columns["EquipoNumeroSerie"].HeaderText = "No. Serie";

                dgvEquipos.Columns["EquipoDescripcion"].Visible = true;
                dgvEquipos.Columns["EquipoDescripcion"].HeaderText = "Descripción";

                btnTransferir.Enabled = lista.Any();
            }
            else
            {
                _folioSeleccionado = null;
                dgvEquipos.DataSource = null;
                btnTransferir.Enabled = false;
            }
        }

        private void BtnTransferir_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_folioSeleccionado)) return;

            int idAdminNuevo = cmbAdministrativoDestino.SelectedValue is int a && a > 0 ? a : 0;
            int idSistemas = cmbResponsableSistemas.SelectedValue is int s && s > 0 ? s : 0;

            if (idAdminNuevo <= 0 || idSistemas <= 0)
            {
                MessageBox.Show("Por favor seleccione el nuevo responsable y el técnico que entrega.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de reasignar TODOS los equipos de este lote al nuevo responsable?\n\nEl titular anterior quedará liberado de estos equipos.",
                "Confirmar Traspaso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // 1. Ejecutamos el traspaso
                    string nuevoFolio = _resguardoService.TransferirLoteColectivo(_folioSeleccionado, idAdminNuevo, idSistemas, DateTime.Today);

                    // 2. Generamos automáticamente el PDF con el nuevo dueño
                    string pdfPath = _reportService.GenerarPdfResguardoColectivo(nuevoFolio);

                    Cursor = Cursors.Default;
                    MessageBox.Show($"¡Traspaso exitoso!\n\nSe generó el nuevo folio: {nuevoFolio}", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Abrimos el PDF
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true });

                    // 4. Limpiamos y recargamos
                    CargarCombos();
                    dgvEquipos.DataSource = null;
                    btnTransferir.Enabled = false;
                    _folioSeleccionado = null;
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Error durante el traspaso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
