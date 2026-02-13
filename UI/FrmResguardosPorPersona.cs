using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Helpers;
using AppEscritorioUPT.Services;

namespace AppEscritorioUPT.UI
{
    public partial class FrmResguardosPorPersona : Form
    {
        private readonly AdministrativoService _adminService = new AdministrativoService();
        private readonly ResguardoService _resguardoService = new ResguardoService();
        private readonly ResguardoReportService _reportService = new ResguardoReportService();

        private Administrativo? _administrativoSeleccionado;

        public FrmResguardosPorPersona()
        {
            InitializeComponent();

            this.Load += FrmResguardoPorPersona_Load;

            // Evento del ComboBox cuando ya seleccionaste un item de la lista
            cmbAdministrativo.SelectionChangeCommitted += CmbAdministrativo_SelectionChangeCommitted;

            // Si quieres que también cargue al “salir” del combo cuando el usuario escribe:
            // cmbAdministrativo.Leave += CmbAdministrativo_Leave;

            btnDescargarLote.Click += BtnDescargarLote_Click;
        }

        private void FrmResguardoPorPersona_Load(object? sender, EventArgs e)
        {
            ConfigurarComboAdministrativo();
            ConfigurarGrid();
            CargarAdministrativos();

            // Estado inicial
            btnDescargarLote.Enabled = false;
        }

        // =========================
        // CONFIGURACIÓN UI
        // =========================

        private void ConfigurarComboAdministrativo()
        {
            // Autocomplete estilo "buscar"
            cmbAdministrativo.DropDownStyle = ComboBoxStyle.DropDown;
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ConfigurarGrid()
        {
            dgvResguardosPersona.ReadOnly = true;
            dgvResguardosPersona.MultiSelect = false;
            dgvResguardosPersona.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResguardosPersona.AllowUserToAddRows = false;
            dgvResguardosPersona.AllowUserToDeleteRows = false;

            // Para ver texto completo y tener scroll horizontal
            dgvResguardosPersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvResguardosPersona.ScrollBars = ScrollBars.Both;
            dgvResguardosPersona.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        // =========================
        // CARGAS
        // =========================

        private void CargarAdministrativos()
        {
            var admins = _adminService.ObtenerAdministrativos()
                .OrderBy(a => a.NombreCompleto)
                .ToList();

            // Item default
            var def = new Administrativo
            {
                Id = 0,
                NombreCompleto = "Selecciona una opción",
                Puesto = "",
                AreaId = 0
            };

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo,
                admins,
                displayMember: "NombreCompleto",
                valueMember: "Id",
                itemDefault: def
            );
        }

        private void CargarResguardosDeSeleccion()
        {
            if (_administrativoSeleccionado == null || _administrativoSeleccionado.Id <= 0)
            {
                dgvResguardosPersona.DataSource = null;
                btnDescargarLote.Enabled = false;
                return;
            }

            var lista = _resguardoService
                .ObtenerResguardosPorAdministrativo(_administrativoSeleccionado.Id)
                .ToList();

            dgvResguardosPersona.DataSource = lista;

            // Ajustes de columnas (ocultar IDs si están)
            OcultarColumna("Id");
            OcultarColumna("EquipoId");
            OcultarColumna("AdministrativoId");
            OcultarColumna("ResponsableSistemasId");

            // Renombrar headers si existen
            CambiarHeader("CodigoInventario", "Código");
            CambiarHeader("FechaResguardo", "Fecha");
            CambiarHeader("EquipoDescripcion", "Equipo");
            CambiarHeader("AdministrativoNombre", "Administrativo");
            CambiarHeader("AreaNombre", "Área");
            CambiarHeader("ResponsableSistemasNombre", "Sistemas");

            // Autosize “por contenido” solo en columnas importantes
            AutoAjustarColumna("CodigoInventario");
            AutoAjustarColumna("FechaResguardo");
            AutoAjustarColumna("EquipoDescripcion");

            btnDescargarLote.Enabled = lista.Any();
        }

        private void OcultarColumna(string nombre)
        {
            if (dgvResguardosPersona.Columns[nombre] != null)
                dgvResguardosPersona.Columns[nombre].Visible = false;
        }

        private void CambiarHeader(string col, string header)
        {
            if (dgvResguardosPersona.Columns[col] != null)
                dgvResguardosPersona.Columns[col].HeaderText = header;
        }

        private void AutoAjustarColumna(string col)
        {
            if (dgvResguardosPersona.Columns[col] != null)
                dgvResguardosPersona.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // =========================
        // EVENTOS
        // =========================

        private void CmbAdministrativo_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            // Tomamos el seleccionado (tu combo trae objetos Administrativo en DataSource)
            if (cmbAdministrativo.SelectedItem is Administrativo admin && admin.Id > 0)
            {
                _administrativoSeleccionado = admin;
            }
            else
            {
                _administrativoSeleccionado = null;
            }

            CargarResguardosDeSeleccion();
        }

        private void BtnDescargarLote_Click(object? sender, EventArgs e)
        {
            if (_administrativoSeleccionado == null || _administrativoSeleccionado.Id <= 0)
            {
                MessageBox.Show("Seleccione un administrativo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // IMPORTANTE:
                // Ajusta el nombre del método si el tuyo se llama distinto.
                var pdfPath = _reportService.GenerarPdfResguardosPorAdministrativo(_administrativoSeleccionado.Id);

                MessageBox.Show("PDF generado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: abrir el PDF
                // System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                // {
                //     FileName = pdfPath,
                //     UseShellExecute = true
                // });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
