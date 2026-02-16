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
            _estadisticasService = new EstadisticasService();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            this.Load += FrmEstadisticas_Load;
            // Asumiendo que el botón sigue existiendo fuera del panel de scroll
            if (btnActualizar != null) btnActualizar.Click += BtnActualizar_Click;

            ConfigurarGridBase(dgvEquiposPorTipo);
            ConfigurarGridBase(dgvEquiposPorArea);
            ConfigurarGridBase(dgvAdministrativosPorArea);
        }

        private void ConfigurarGridBase(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = SystemColors.ControlLightLight; // Fondo blanco para limpieza

            // --- MEJORA PARA COLUMNAS LARGAS ---
            // 1. Que ocupen todo el ancho
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 2. Permitir que el texto baje a la siguiente línea (Word Wrap)
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // 3. Ajustar altura de filas automáticamente si el texto hace wrap
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CargarTotales()
        {
            // AHORA SOLO TOCAMOS LOS LABELS DE VALOR, NO LOS TÍTULOS
            // Asegúrate de haber renombrado los labels en el diseñador como indico abajo:

            lblValTotalAdministrativos.Text = _estadisticasService.ObtenerTotalAdministrativos().ToString();
            lblValTotalEquipos.Text = _estadisticasService.ObtenerTotalEquipos().ToString();
            lblValTotalResguardos.Text = _estadisticasService.ObtenerTotalResguardos().ToString();
        }

        private void CargarTablas()
        {
            // Equipos por Tipo
            var datosEquiposTipo = _estadisticasService.ObtenerEquiposPorTipo()
                .Select(x => new { Tipo_Equipo = x.Key, Cantidad = x.Value })
                .ToList();
            dgvEquiposPorTipo.DataSource = datosEquiposTipo;

            // Equipos por Área (Aquí es donde suele haber nombres largos)
            var datosEquiposArea = _estadisticasService.ObtenerEquiposPorArea()
                .Select(x => new { Nombre_Área = x.Key, Total_Equipos = x.Value })
                .OrderByDescending(x => x.Total_Equipos)
                .ToList();
            dgvEquiposPorArea.DataSource = datosEquiposArea;

            // Administrativos por Área
            var datosAdminsArea = _estadisticasService.ObtenerAdministrativosPorArea()
                .Select(x => new { Nombre_Área = x.Key, Personal_Asignado = x.Value })
                .OrderByDescending(x => x.Personal_Asignado)
                .ToList();
            dgvAdministrativosPorArea.DataSource = datosAdminsArea;
        }

    }
}
