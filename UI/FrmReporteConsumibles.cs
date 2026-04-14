using AppEscritorioUPT.Data.Dto;
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
    public partial class FrmReporteConsumibles : Form
    {
        // 1. Declaramos el servicio
        private readonly ConsumibleService _consumibleService;

        public FrmReporteConsumibles()
        {
            InitializeComponent();

            // 2. Inicializamos el servicio
            _consumibleService = new ConsumibleService();

            // 3. Conectamos el evento Load para que se ejecute al abrir la pantalla
            this.Load += FrmReporteConsumibles_Load;
            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmReporteConsumibles_Load(object? sender, EventArgs e)
        {
            // Ejecutamos tus métodos en orden
            ConfigurarGrid();
            CargarReporte();
        }

        private void ConfigurarGrid()
        {
            dgvReporte.AutoGenerateColumns = false;
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvReporte.Columns.Clear();

            // Ubicación y Responsable (Global)
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AreaNombre", HeaderText = "Área / Departamento", Width = 150 });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ResponsableNombre", HeaderText = "Responsable", Width = 180 });

            // Datos del Equipo
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MarcaEquipo", HeaderText = "Marca" });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ModeloEquipo", HeaderText = "Modelo Impresora" });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SerieEquipo", HeaderText = "S/N", Width = 100 });

            // Datos del Consumible
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ModeloConsumible", HeaderText = "Tóner/Tinta", MinimumWidth = 120 });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Color", HeaderText = "Color", Width = 90 });
            dgvReporte.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockActual", HeaderText = "Stock", Width = 70 });
        }

        private void CargarReporte()
        {
            // Traemos los datos de la BD
            var datos = _consumibleService.ObtenerReporteGeneral().ToList();
            dgvReporte.DataSource = datos;

            // Pintar de rojo si el stock es bajo para que el administrador lo vea rápido
            foreach (DataGridViewRow row in dgvReporte.Rows)
            {
                // Hacemos el casting al DTO para leer sus propiedades
                var item = (ReporteConsumibleDto)row.DataBoundItem;

                if (item.RequiereCompra)
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }

            dgvReporte.ClearSelection();
        }

        private void btnImprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // 1. ¡LE DELEGAMOS TODO EL TRABAJO PESADO AL SERVICIO!
                string rutaPdfGenerado = _consumibleService.GenerarYGuardarReportePdf();

                Cursor = Cursors.Default;

                // 2. Mensajes de éxito
                string carpeta = System.IO.Path.GetDirectoryName(rutaPdfGenerado) ?? "Documentos";
                MessageBox.Show($"El reporte se generó correctamente en:\n{carpeta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Abrimos el visor de PDF
                var p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(rutaPdfGenerado) { UseShellExecute = true };
                p.Start();
            }
            catch (InvalidOperationException ex)
            {
                // Este catch atrapa específicamente el error de "No hay datos" que lanzamos en el servicio
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Este catch atrapa errores graves (como que no esté instalado el wkhtmltopdf)
                Cursor = Cursors.Default;
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarRequisicion_Click(object? sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Delegamos la tarea pesada al servicio
                string rutaPdfGenerado = _consumibleService.GenerarYGuardarReporteComprasPdf();

                Cursor = Cursors.Default;

                string carpeta = System.IO.Path.GetDirectoryName(rutaPdfGenerado) ?? "Documentos";
                MessageBox.Show($"La Requisición de Compras se generó correctamente en:\n{carpeta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrimos el PDF
                var p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(rutaPdfGenerado) { UseShellExecute = true };
                p.Start();
            }
            catch (InvalidOperationException ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
