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
    public partial class FrmFaltantesResguardo : Form
    {
        private readonly AdministrativoService _adminService = new AdministrativoService();
        private ContextMenuStrip _menuContextual = new ContextMenuStrip();

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
            ConfigurarMenuContextual();
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

        // =========================
        // MENÚ CONTEXTUAL (CLIC DERECHO)
        // =========================
        private void ConfigurarMenuContextual()
        {
            var itemAsignar = new ToolStripMenuItem("Asignar Equipos (Masivo)");
            itemAsignar.Click += ItemAsignar_Click;

            _menuContextual.Items.Add(itemAsignar);
            dgvFaltantes.CellMouseUp += DgvFaltantes_CellMouseUp;
        }

        private void DgvFaltantes_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {
            // Si dieron clic derecho sobre una fila válida
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvFaltantes.ClearSelection();
                dgvFaltantes.Rows[e.RowIndex].Selected = true;
                _menuContextual.Show(Cursor.Position);
            }
        }

        private void ItemAsignar_Click(object? sender, EventArgs e)
        {
            if (dgvFaltantes.SelectedRows.Count == 0) return;

            // Casteamos al objeto Administrativo
            if (dgvFaltantes.SelectedRows[0].DataBoundItem is Administrativo adminSeleccionado)
            {
                // Abrimos el formulario de asignación masiva
                var frmMasivo = new FrmResguardoMasivo();
                frmMasivo.AdministrativoIdPreseleccionado = adminSeleccionado.Id;
                frmMasivo.ShowDialog(); // ShowDialog congela esta pantalla hasta que termines de asignar

                // Cuando regreses de asignar los equipos, recargamos esta lista
                // ¡El administrativo ya no debería aparecer porque ya tiene resguardo!
                CargarFaltantes();
            }
        }
    }
}
