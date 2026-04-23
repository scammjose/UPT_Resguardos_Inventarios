using AppEscritorioUPT.Data.Dto;
using AppEscritorioUPT.Domain.Reports;
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
    public partial class FrmResguardosColectivos : Form
    {
        // Servicios necesarios
        private readonly ResguardoService _resguardoService = new ResguardoService();
        private ContextMenuStrip _menuContextual = new ContextMenuStrip();
        private readonly ResguardoReportService _reportService = new ResguardoReportService();
    

        // Variable para guardar el lote que estamos viendo
        private string? _folioLoteSeleccionado;

        public FrmResguardosColectivos()
        {
            InitializeComponent();

            // Eventos de carga y clics
            this.Load += FrmResguardosColectivos_Load;
            cmbLotes.SelectionChangeCommitted += CmbLotes_SelectionChangeCommitted;
            btnDescargarLote.Click += BtnDescargarLote_Click;

            // Tus helpers de diseño
            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmResguardosColectivos_Load(object? sender, EventArgs e)
        {
            ConfigurarComboLotes();
            ConfigurarGrid();
            CargarLotesDisponibles();
            ConfigurarMenuContextual();

            // El botón de PDF arranca apagado hasta que seleccionen un lote
            btnDescargarLote.Enabled = false;
        }

        // =========================
        // CONFIGURACIÓN UI
        // =========================
        private void ConfigurarComboLotes()
        {
            cmbLotes.DropDownStyle = ComboBoxStyle.DropDown;
            cmbLotes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbLotes.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ConfigurarGrid()
        {
            dgvResguardosLote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvResguardosLote.ScrollBars = ScrollBars.Both;
            dgvResguardosLote.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvResguardosLote.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResguardosLote.ReadOnly = true;
            dgvResguardosLote.AllowUserToAddRows = false;
        }

        // =========================
        // CARGAS DE DATOS
        // =========================
        private void CargarLotesDisponibles()
        {
            var lotes = _resguardoService.ObtenerLotesDisponibles();

            var def = new LoteResguardoDto
            {
                FolioLote = "",
                Descripcion = "Selecciona un Lote Colectivo..."
            };

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbLotes,
                lotes,
                displayMember: "Descripcion",
                valueMember: "FolioLote",
                itemDefault: def
            );
        }

        private void CmbLotes_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            if (cmbLotes.SelectedValue is string folio && !string.IsNullOrEmpty(folio))
            {
                _folioLoteSeleccionado = folio;
            }
            else
            {
                _folioLoteSeleccionado = null;
            }

            CargarEquiposDelLote();
        }

        private void CargarEquiposDelLote()
        {
            if (string.IsNullOrEmpty(_folioLoteSeleccionado))
            {
                dgvResguardosLote.DataSource = null;
                btnDescargarLote.Enabled = false;
                return;
            }

            var lista = _resguardoService.ObtenerPorFolioLoteParaReporte(_folioLoteSeleccionado).ToList();

            dgvResguardosLote.DataSource = lista;

            // Ocultamos las columnas técnicas que no le sirven al usuario visualmente
            OcultarColumna("Id");
            OcultarColumna("EquipoId");
            OcultarColumna("AdministrativoNombre"); // Todos son del mismo admin, no hace falta repetirlo
            OcultarColumna("AdministrativoPuesto");
            OcultarColumna("AreaNombre");
            OcultarColumna("ResponsableSistemasNombre");
            OcultarColumna("ResponsableSistemasPuesto");

            // Renombramos las cabeceras importantes
            CambiarHeader("CodigoInventario", "Código UPT");
            CambiarHeader("EquipoDescripcion", "Descripción del Equipo");
            CambiarHeader("EquipoNumeroSerie", "No. Serie");
            CambiarHeader("FechaResguardo", "Fecha");

            // Ajustamos anchos
            AutoAjustarColumna("CodigoInventario");
            AutoAjustarColumna("EquipoDescripcion");
            AutoAjustarColumna("EquipoNumeroSerie");

            btnDescargarLote.Enabled = lista.Any();
        }

        private void OcultarColumna(string nombre)
        {
            if (dgvResguardosLote.Columns[nombre] != null)
                dgvResguardosLote.Columns[nombre].Visible = false;
        }

        private void CambiarHeader(string col, string header)
        {
            if (dgvResguardosLote.Columns[col] != null)
                dgvResguardosLote.Columns[col].HeaderText = header;
        }

        private void AutoAjustarColumna(string col)
        {
            if (dgvResguardosLote.Columns[col] != null)
                dgvResguardosLote.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // =========================
        // GENERACIÓN DE PDF
        // =========================
        private void BtnDescargarLote_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_folioLoteSeleccionado))
            {
                MessageBox.Show("Seleccione un Lote primero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // ¡LE DELEGAMOS TODO EL TRABAJO AL SERVICIO DE REPORTES!
                var pdfPath = _reportService.GenerarPdfResguardoColectivo(_folioLoteSeleccionado);

                Cursor = Cursors.Default;

                string carpetaDestino = System.IO.Path.GetDirectoryName(pdfPath) ?? "";
                MessageBox.Show($"La Carta Responsiva se generó exitosamente en:\n{carpetaDestino}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrimos el PDF
                var p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(pdfPath) { UseShellExecute = true };
                p.Start();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================
        // MENÚ CONTEXTUAL (CLIC DERECHO)
        // =========================
        private void ConfigurarMenuContextual()
        {
            _menuContextual = new ContextMenuStrip();

            var itemEditarEquipo = new ToolStripMenuItem("✏️ Editar Equipo Físico");
            itemEditarEquipo.Click += ItemEditarEquipo_Click;

            var itemRetirarEquipo = new ToolStripMenuItem("❌ Retirar/Dar de baja del Lote");
            itemRetirarEquipo.Click += ItemRetirarEquipo_Click;

            _menuContextual.Items.Add(itemEditarEquipo);
            _menuContextual.Items.Add(itemRetirarEquipo);

            dgvResguardosLote.CellMouseUp += DgvResguardosLote_CellMouseUp;
        }

        private void DgvResguardosLote_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvResguardosLote.ClearSelection();
                dgvResguardosLote.Rows[e.RowIndex].Selected = true;
                _menuContextual.Show(Cursor.Position);
            }
        }

        private void ItemEditarEquipo_Click(object? sender, EventArgs e)
        {
            if (dgvResguardosLote.SelectedRows.Count == 0) return;

            if (dgvResguardosLote.SelectedRows[0].DataBoundItem is ResguardoReportModel resguardo)
            {
                // Abre tu formulario existente de edición de equipos
                var frmEquipos = new FrmEquipos();
                frmEquipos.EquipoIdParaEditar = resguardo.EquipoId;
                frmEquipos.ShowDialog();

                CargarEquiposDelLote();
            }
        }

        private void ItemRetirarEquipo_Click(object? sender, EventArgs e)
        {
            if (dgvResguardosLote.SelectedRows.Count == 0) return;

            if (dgvResguardosLote.SelectedRows[0].DataBoundItem is ResguardoReportModel resguardo)
            {
                var result = MessageBox.Show(
                    $"¿Estás seguro de retirar el equipo con serie {resguardo.EquipoNumeroSerie} de este lote?\n" +
                    $"El contador del lote bajará y el equipo quedará libre.",
                    "Confirmar Retiro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Eliminamos el resguardo individual de esa máquina
                        _resguardoService.EliminarResguardo(resguardo.Id);
                        MessageBox.Show("Equipo retirado del lote correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargamos todo para actualizar el contador del combo y el grid
                        CargarEquiposDelLote();
                        CargarLotesDisponibles();

                        // Si el lote se quedó vacío, limpiamos la selección
                        if (dgvResguardosLote.Rows.Count == 0)
                        {
                            _folioLoteSeleccionado = null;
                            cmbLotes.SelectedValue = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al retirar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
