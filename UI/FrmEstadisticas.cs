using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppEscritorioUPT.Services;
using System.Drawing;

namespace AppEscritorioUPT.UI
{
    public partial class FrmEstadisticas : Form
    {
        private readonly EstadisticasService _estadisticasService;
        public FrmEstadisticas()
        {
            InitializeComponent();
            _estadisticasService = new EstadisticasService(); // Inyección manual simple
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Eventos
            this.Load += FrmEstadisticas_Load;
            if (btnActualizar != null) btnActualizar.Click += BtnActualizar_Click;

            // Configuración visual base de los Grids (Siguiendo tu convención)
            ConfigurarGridBase(dgvEquiposPorTipo);
            ConfigurarGridBase(dgvEquiposPorArea);
            ConfigurarGridBase(dgvAdministrativosPorArea);
        }

        private void ConfigurarGridBase(DataGridView dgv)
        {
            // Aplicamos las reglas de tu convención de UI
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Fill para que ocupe todo el ancho
            dgv.RowHeadersVisible = false; // Ocultar la columna gris de la izquierda
            dgv.BackgroundColor = SystemColors.Control; // Color de fondo limpio
            dgv.BorderStyle = BorderStyle.None;
        }

        private void FrmEstadisticas_Load(object? sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void CargarEstadisticas()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                CargarTotales();
                CargarTablas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CargarTotales()
        {
            // Labels de números grandes
            lblTotalAdministrativos.Text = _estadisticasService.ObtenerTotalAdministrativos().ToString();
            lblTotalEquipos.Text = _estadisticasService.ObtenerTotalEquipos().ToString();
            lblTotalResguardos.Text = _estadisticasService.ObtenerTotalResguardos().ToString();
        }

        private void CargarTablas()
        {
            // 1. Equipos por Tipo
            // Transformamos el Dictionary a una lista anónima para que el DataGridView muestre columnas bonitas
            var datosEquiposTipo = _estadisticasService.ObtenerEquiposPorTipo()
                .Select(x => new { Tipo = x.Key, Cantidad = x.Value })
                .ToList();

            dgvEquiposPorTipo.DataSource = datosEquiposTipo;

            // 2. Equipos por Área
            var datosEquiposArea = _estadisticasService.ObtenerEquiposPorArea()
                .Select(x => new { Área = x.Key, Total_Equipos = x.Value }) // Guiones bajos se ven bien en headers automáticos
                .OrderByDescending(x => x.Total_Equipos) // Ordenamos para ver las áreas con más equipo primero
                .ToList();

            dgvEquiposPorArea.DataSource = datosEquiposArea;

            // 3. Administrativos por Área
            var datosAdminsArea = _estadisticasService.ObtenerAdministrativosPorArea()
                .Select(x => new { Área = x.Key, Personal = x.Value })
                .OrderByDescending(x => x.Personal)
                .ToList();

            dgvAdministrativosPorArea.DataSource = datosAdminsArea;
        }

    }
}
