using AppEscritorioUPT.Domain.Reports;
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
    public partial class FrmReclasificarCodigos : Form
    {
        private readonly AdministrativoService _adminService = new AdministrativoService();
        private readonly AreaService _areaService = new AreaService();
        private readonly ResguardoService _resguardoService = new ResguardoService();

        public FrmReclasificarCodigos()
        {
            InitializeComponent();
            this.Load += FrmReclasificarCodigos_Load;

            cmbAdministrativo.SelectedIndexChanged += CmbAdministrativo_SelectedIndexChanged;
            btnRegenerar.Click += BtnRegenerar_Click;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmReclasificarCodigos_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarCombos();
            btnRegenerar.Enabled = false;
        }

        private void ConfigurarGrid()
        {
            // Permitimos seleccionar varias filas al mismo tiempo (con Ctrl o Shift)
            dgvResguardos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResguardos.MultiSelect = true;
            dgvResguardos.ReadOnly = true;
            dgvResguardos.AllowUserToAddRows = false;
            dgvResguardos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void CargarCombos()
        {
            // 1. Combo de Administrativos
            var admins = _adminService.ObtenerAdministrativos().OrderBy(a => a.NombreCompleto).ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo, admins, "NombreCompleto", "Id",
                new Administrativo { Id = 0, NombreCompleto = "Seleccione un administrativo..." });

            cmbAdministrativo.DropDownStyle = ComboBoxStyle.DropDown;
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;

            // 2. Combo de Áreas (Para reclasificar)
            var areas = _areaService.ObtenerAreas().OrderBy(a => a.Nombre).ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbArea, areas, "Nombre", "Id",
                new Area { Id = 0, Nombre = "Seleccione el Área Correcta..." });

            cmbArea.DropDownStyle = ComboBoxStyle.DropDown;
            cmbArea.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbArea.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CmbAdministrativo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CargarResguardos();
        }

        private void CargarResguardos()
        {
            if (cmbAdministrativo.SelectedValue is int adminId && adminId > 0)
            {
                var lista = _resguardoService.ObtenerModelosReportePorAdministrativo(adminId);
                dgvResguardos.DataSource = lista;

                OcultarColumnasVisuales();
                btnRegenerar.Enabled = lista.Any();
            }
            else
            {
                dgvResguardos.DataSource = null;
                btnRegenerar.Enabled = false;
            }
        }

        private void OcultarColumnasVisuales()
        {
            foreach (DataGridViewColumn col in dgvResguardos.Columns)
                col.Visible = false;

            // Mostramos lo importante
            MostrarColumna("CodigoInventario", "Código Actual", 0);
            MostrarColumna("EquipoMarca", "Marca", 1);
            MostrarColumna("EquipoModelo", "Modelo", 2);
            MostrarColumna("EquipoNumeroSerie", "N/S", 3);
            MostrarColumna("FechaResguardo", "Fecha", 4);

            if (dgvResguardos.Columns["CodigoInventario"] != null)
                dgvResguardos.Columns["CodigoInventario"].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        }

        private void MostrarColumna(string nomOriginal, string titulo, int orden)
        {
            if (dgvResguardos.Columns[nomOriginal] != null)
            {
                dgvResguardos.Columns[nomOriginal].Visible = true;
                dgvResguardos.Columns[nomOriginal].HeaderText = titulo;
                dgvResguardos.Columns[nomOriginal].DisplayIndex = orden;
            }
        }

        private void BtnRegenerar_Click(object? sender, EventArgs e)
        {
            if (dgvResguardos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un resguardo de la tabla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbArea.SelectedValue is not int areaIdDestino || areaIdDestino <= 0)
            {
                MessageBox.Show("Seleccione el Área a la cual se debe reclasificar el inventario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de regenerar el código de {dgvResguardos.SelectedRows.Count} equipo(s) seleccionados?\nEsta acción asignará la nomenclatura del área seleccionada.",
                "Confirmar Reclasificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // Extraemos los IDs de los resguardos seleccionados
                    var idsSeleccionados = dgvResguardos.SelectedRows
                        .Cast<DataGridViewRow>()
                        .Select(r => ((ResguardoReportModel)r.DataBoundItem).Id)
                        .ToList();

                    // Llamamos al nuevo método del servicio
                    _resguardoService.ReclasificarCodigosInventarioMasivo(idsSeleccionados, areaIdDestino);

                    MessageBox.Show("Los códigos de inventario han sido actualizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refrescamos la tabla para ver los nuevos códigos
                    CargarResguardos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}
