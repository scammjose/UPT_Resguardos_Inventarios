using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AppEscritorioUPT.Services;

namespace AppEscritorioUPT.UI
{
    public partial class FrmDashboard : Form
    {
        private readonly EstadisticaService _estadisticaService = new EstadisticaService();

        // Controles visuales puros
        private Label lblTitulo = new Label();
        private Label lblTotalEquipos = new Label();
        private Label lblTotalResguardos = new Label();

        // Tablas para los datos duros
        private DataGridView dgvHardware = new DataGridView();
        private DataGridView dgvLaboratorios = new DataGridView();
        private DataGridView dgvUso = new DataGridView();

        public FrmDashboard()
        {
            InitializeComponent();
            ConstruirInterfazPorCodigo();
            this.Load += FrmDashboard_Load;
        }

        private void ConstruirInterfazPorCodigo()
        {
            // === Configuración de la Ventana ===
            this.Text = "Reporte de Estadísticas Exactas";
            this.Size = new Size(1100, 600);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterParent;

            // === Títulos y Totales ===
            lblTitulo.Text = "REPORTE DE INVENTARIO Y RESGUARDOS UPT";
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(160, 33, 66); // Guinda
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.AutoSize = true;

            lblTotalEquipos.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTotalEquipos.ForeColor = Color.FromArgb(39, 39, 39);
            lblTotalEquipos.Location = new Point(30, 60);
            lblTotalEquipos.AutoSize = true;

            lblTotalResguardos.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTotalResguardos.ForeColor = Color.FromArgb(39, 39, 39);
            lblTotalResguardos.Location = new Point(350, 60);
            lblTotalResguardos.AutoSize = true;

            // === Configurar Tablas ===
            ConfigurarEstiloTabla(dgvHardware, new Point(30, 120), "Total por Tipo de Equipo (Hardware)");
            ConfigurarEstiloTabla(dgvLaboratorios, new Point(380, 120), "Equipos por Laboratorio Destino");
            ConfigurarEstiloTabla(dgvUso, new Point(730, 120), "Equipos por Tipo de Uso");

            // Agregamos todo a la pantalla
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblTotalEquipos);
            this.Controls.Add(lblTotalResguardos);
            this.Controls.Add(dgvHardware);
            this.Controls.Add(dgvLaboratorios);
            this.Controls.Add(dgvUso);
        }

        private void ConfigurarEstiloTabla(DataGridView dgv, Point ubicacion, string titulo)
        {
            dgv.Location = ubicacion;
            dgv.Size = new Size(320, 400);
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo visual de la universidad
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(160, 33, 66);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(160, 130, 90); // Dorado al seleccionar
        }

        private void FrmDashboard_Load(object? sender, EventArgs e)
        {
            CargarDashboard();
        }

        private void CargarDashboard()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var datos = _estadisticaService.ObtenerDashboard();

                lblTotalEquipos.Text = $"Total Hardware Físico: {datos.TotalEquiposRegistrados}";
                lblTotalResguardos.Text = $"Equipos en Resguardo Activo: {datos.TotalEquiposEnResguardo}";

                // Llenar tabla 1: Hardware
                dgvHardware.DataSource = datos.EquiposPorTipoHardware;
                RenombrarColumnas(dgvHardware, "Tipo de Hardware", "Cantidad");

                // Llenar tabla 2: Laboratorios
                dgvLaboratorios.DataSource = datos.EquiposPorMarca; // Usamos esta lista para los labs
                RenombrarColumnas(dgvLaboratorios, "Laboratorio", "Equipos");

                // Llenar tabla 3: Uso
                dgvUso.DataSource = datos.EquiposPorTipoUso;
                RenombrarColumnas(dgvUso, "Propósito / Uso", "Equipos");

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void RenombrarColumnas(DataGridView dgv, string tituloCol1, string tituloCol2)
        {
            if (dgv.Columns.Contains("Etiqueta"))
                dgv.Columns["Etiqueta"].HeaderText = tituloCol1;

            if (dgv.Columns.Contains("Valor"))
            {
                dgv.Columns["Valor"].HeaderText = tituloCol2;
                dgv.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}