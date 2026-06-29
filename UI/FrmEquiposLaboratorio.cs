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
    public partial class FrmEquiposLaboratorio : Form
    {
        private readonly int _laboratorioId;
        private readonly string _laboratorioNombre;
        private readonly ResguardoService _resguardoService = new ResguardoService();

        private DataGridView dgvEquipos = new DataGridView();
        private Label lblTitulo = new Label();
        private Label lblConteo = new Label();

        public FrmEquiposLaboratorio(int laboratorioId, string laboratorioNombre)
        {
            InitializeComponent();
            _laboratorioId = laboratorioId;
            _laboratorioNombre = laboratorioNombre;

            ConstruirInterfaz();
            this.Load += FrmEquiposLaboratorio_Load;
        }

        private void ConstruirInterfaz()
        {
            this.Text = $"Detalle de Equipos - {_laboratorioNombre}";
            this.Size = new Size(900, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            lblTitulo.Text = $"Equipos Asignados: {_laboratorioNombre}";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(160, 33, 66);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.AutoSize = true;

            lblConteo.Text = "Total de máquinas: 0";
            lblConteo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblConteo.Location = new Point(25, 60);
            lblConteo.AutoSize = true;

            dgvEquipos.Location = new Point(25, 90);
            dgvEquipos.Size = new Size(830, 350);
            dgvEquipos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEquipos.ReadOnly = true;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.AllowUserToAddRows = false;
            dgvEquipos.BackgroundColor = Color.White;
            dgvEquipos.RowHeadersVisible = false;
            dgvEquipos.CellMouseClick += DgvEquipos_CellMouseClick;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblConteo);
            this.Controls.Add(dgvEquipos);

            ThemeHelper.AplicarTema(this);
        }

        private void FrmEquiposLaboratorio_Load(object? sender, EventArgs e)
        {
            CargarEquipos();
        }

        private void CargarEquipos()
        {
            Cursor = Cursors.WaitCursor;

            // Traemos los equipos usando el método nuevo
            var equipos = _resguardoService.GetEquiposPorLaboratorio(_laboratorioId);

            lblConteo.Text = $"Total de máquinas reales en sistema: {equipos.Count}";

            dgvEquipos.DataSource = equipos;

            // Ocultamos las columnas que no nos sirven visualmente
            foreach (DataGridViewColumn col in dgvEquipos.Columns)
                col.Visible = false;

            // Mostramos y renombramos las importantes
            MostrarColumna("CodigoInventario", "Código UPT", 150);
            MostrarColumna("FolioLote", "Folio Lote/Resguardo", 180);
            MostrarColumna("TipoEquipoNombre", "Tipo", 120);
            MostrarColumna("EquipoMarca", "Marca", 120);
            MostrarColumna("EquipoModelo", "Modelo", 120);
            MostrarColumna("EquipoNumeroSerie", "No. Serie", 150);
            MostrarColumna("EquipoDireccionIp", "Dir. IP", 100);

            Cursor = Cursors.Default;
        }

        private void MostrarColumna(string nombreOriginal, string nuevoTitulo, int ancho)
        {
            if (dgvEquipos.Columns[nombreOriginal] != null)
            {
                dgvEquipos.Columns[nombreOriginal].Visible = true;
                dgvEquipos.Columns[nombreOriginal].HeaderText = nuevoTitulo;
                dgvEquipos.Columns[nombreOriginal].Width = ancho;
            }
        }

        private void DgvEquipos_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            // Verificamos que sea clic DERECHO y en una fila válida
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvEquipos.CurrentCell = dgvEquipos.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // 1. Extraemos el ID exacto del Equipo y su Código UPT
                int equipoId = Convert.ToInt32(dgvEquipos.Rows[e.RowIndex].Cells["EquipoId"].Value);
                string codigoUpt = dgvEquipos.Rows[e.RowIndex].Cells["CodigoInventario"].Value?.ToString() ?? "Equipo";

                // 2. Creamos el menú flotante
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem itemEditar = new ToolStripMenuItem($"✏️ Editar datos de: {codigoUpt}");

                itemEditar.Click += (s, args) =>
                {
                    // 3. ABRIR FORMULARIO DE EDICIÓN
                    // (Nota: Si tu FrmEquipos normal no acepta un ID entre paréntesis, me avisas)
                    using (var frm = new FrmEquipos(equipoId))
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);

                        // 4. Refrescar la tabla mágicamente cuando se cierre la ventana de edición
                        CargarEquipos();
                    }
                };

                menu.Items.Add(itemEditar);
                menu.Show(Cursor.Position);
            }
        }
    }
}
