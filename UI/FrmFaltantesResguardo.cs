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
    public partial class FrmFaltantesResguardo : Form
    {
        private readonly AdministrativoService _adminService = new AdministrativoService();

        public FrmFaltantesResguardo()
        {
            InitializeComponent();
            this.Load += FrmFaltantesResguardo_Load;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmFaltantesResguardo_Load(object? sender, EventArgs e)
        {
            CargarFaltantes();
            ConfigurarGrid();
        }

        private void CargarFaltantes()
        {
            var faltantes = _adminService.ObtenerAdministrativosSinResguardo().ToList();
            dgvFaltantes.DataSource = faltantes;

            // Mostramos un mensaje si todos tienen resguardo (¡Buenas noticias!)
            if (!faltantes.Any())
            {
                MessageBox.Show("¡Excelente! Todos los administrativos del sistema tienen al menos un resguardo asignado.",
                                "Auditoría Limpia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfigurarGrid()
        {
            dgvFaltantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvFaltantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFaltantes.AllowUserToAddRows = false;
            dgvFaltantes.ReadOnly = true;

            if (dgvFaltantes.Columns["Id"] != null)
                dgvFaltantes.Columns["Id"].Visible = false;

            if (dgvFaltantes.Columns["AreaId"] != null)
                dgvFaltantes.Columns["AreaId"].Visible = false; // Ocultamos el ID interno del área

            if (dgvFaltantes.Columns["NombreCompleto"] != null)
                dgvFaltantes.Columns["NombreCompleto"].HeaderText = "Nombre del Administrativo";

            if (dgvFaltantes.Columns["Puesto"] != null)
                dgvFaltantes.Columns["Puesto"].HeaderText = "Puesto";

            if (dgvFaltantes.Columns["AreaNombre"] != null)
            {
                dgvFaltantes.Columns["AreaNombre"].HeaderText = "Área Asignada";
                dgvFaltantes.Columns["AreaNombre"].DisplayIndex = 2; // Para ponerla después del nombre
            }
        }
    }
}
