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
    public partial class FrmImpresionResguardoPorArea : Form
    {
        // 1. Instanciamos los servicios necesarios
        private readonly AreaService _areaService = new AreaService();
        private readonly ResguardoService _resguardoService = new ResguardoService();
        private readonly ResguardoReportService _reportService = new ResguardoReportService();

        public FrmImpresionResguardoPorArea()
        {
            InitializeComponent();

            // 2. Suscribimos los eventos
            this.Load += FrmImpresionResguardoPorArea_Load;
            cmbArea.SelectedIndexChanged += CmbArea_SelectedIndexChanged;
            btnGenerarPdf.Click += BtnGenerarPdf_Click;

            // 3. Aplicamos el tema visual
            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmImpresionResguardoPorArea_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarAreas();

            // Apagamos el botón hasta que seleccionen un área con datos
            btnGenerarPdf.Enabled = false;
        }

        private void ConfigurarGrid()
        {
            dgvResguardosArea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResguardosArea.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResguardosArea.ReadOnly = true;
            dgvResguardosArea.AllowUserToAddRows = false;
        }

        private void CargarAreas()
        {
            var areas = _areaService.ObtenerAreas().OrderBy(a => a.Nombre).ToList();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbArea,
                areas,
                displayMember: "Nombre",
                valueMember: "Id",
                itemDefault: new Area { Id = 0, Nombre = "Seleccione un Área..." }
            );

            // Buscador integrado en el combo
            cmbArea.DropDownStyle = ComboBoxStyle.DropDown;
            cmbArea.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbArea.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CmbArea_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbArea.SelectedValue is int areaId && areaId > 0)
            {
                var lista = _resguardoService.ObtenerResguardosPorArea(areaId);
                dgvResguardosArea.DataSource = lista;

                // Mostramos el botón de PDF solo si hay resultados
                btnGenerarPdf.Enabled = lista.Any();

                if (lista.Any())
                {
                    LimpiarColumnasVisuales();
                }
            }
            else
            {
                dgvResguardosArea.DataSource = null;
                btnGenerarPdf.Enabled = false;
            }
        }

        // =========================
        // UTILIDADES VISUALES
        // =========================
        private void LimpiarColumnasVisuales()
        {
            // Ocultamos absolutamente todas las columnas primero
            foreach (DataGridViewColumn col in dgvResguardosArea.Columns)
            {
                col.Visible = false;
            }

            // Y encendemos SOLO las que queremos que vea el usuario en la previsualización
            MostrarColumna("AdministrativoNombre", "Empleado", 0);
            MostrarColumna("TipoEquipoNombre", "Tipo", 1);
            MostrarColumna("EquipoMarca", "Marca", 2);
            MostrarColumna("EquipoModelo", "Modelo", 3);
            MostrarColumna("CodigoInventario", "Cód. Inventario", 4);
            MostrarColumna("FechaResguardo", "Fecha", 5);

            // Estiramos la columna de empleado para que llene los huecos
            if (dgvResguardosArea.Columns["AdministrativoNombre"] != null)
                dgvResguardosArea.Columns["AdministrativoNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void MostrarColumna(string nombreOriginal, string nuevoTitulo, int orden)
        {
            if (dgvResguardosArea.Columns[nombreOriginal] != null)
            {
                dgvResguardosArea.Columns[nombreOriginal].Visible = true;
                dgvResguardosArea.Columns[nombreOriginal].HeaderText = nuevoTitulo;
                dgvResguardosArea.Columns[nombreOriginal].DisplayIndex = orden;
            }
        }

        // =========================
        // GENERACIÓN DE PDF
        // =========================
        private void BtnGenerarPdf_Click(object? sender, EventArgs e)
        {
            if (cmbArea.SelectedValue is int areaId && areaId > 0)
            {
                try
                {
                    // Cambiamos el cursor al de "cargando" porque los PDFs pesados tardan un par de segundos
                    Cursor = Cursors.WaitCursor;

                    var pdfPath = _reportService.GenerarPdfConcentradoPorArea(areaId);

                    if (File.Exists(pdfPath))
                    {
                        MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrimos el PDF mágicamente
                        var psi = new ProcessStartInfo
                        {
                            FileName = pdfPath,
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al generar el PDF:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}
