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
    public partial class FrmCompatibilidad : Form
    {
        private readonly EquipoService _equipoService;
        private readonly ConsumibleService _consumibleService;
        private readonly EquipoConsumibleService _compatibilidadService;
        private readonly TipoEquipoService _tipoService;

        private List<Consumible> _todosLosConsumibles = new();

        public FrmCompatibilidad()
        {
            InitializeComponent();
            _equipoService = new EquipoService();
            _consumibleService = new ConsumibleService();
            _compatibilidadService = new EquipoConsumibleService();
            _tipoService = new TipoEquipoService();

            this.Load += FrmCompatibilidad_Load;
            cmbEquipos.SelectedIndexChanged += CmbEquipos_SelectedIndexChanged;
            btnGuardar.Click += BtnGuardar_Click;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmCompatibilidad_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarEquipos();
            CargarConsumiblesEnGrid();
        }

        // ===== 1. CONFIGURACIONES INICIALES =====

        private void ConfigurarGrid()
        {
            dgvConsumibles.AutoGenerateColumns = false;
            dgvConsumibles.AllowUserToAddRows = false;
            dgvConsumibles.RowHeadersVisible = false;
            dgvConsumibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // IMPORTANTE: Permitimos editar para que puedan darle clic a las palomitas
            dgvConsumibles.ReadOnly = false;

            dgvConsumibles.Columns.Clear();

            // Columna 1: La Palomita (Checkbox)
            var chkCol = new DataGridViewCheckBoxColumn
            {
                Name = "Compatible",
                HeaderText = "¿Compatible?",
                Width = 90,
                ReadOnly = false // Solo esta columna se puede editar
            };
            dgvConsumibles.Columns.Add(chkCol);

            // Columnas de datos (Solo lectura)
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { Name = "Modelo", DataPropertyName = "Modelo", HeaderText = "Modelo / Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, ReadOnly = true });
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { Name = "Color", DataPropertyName = "Color", HeaderText = "Color", Width = 150, ReadOnly = true });
            dgvConsumibles.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tipo", DataPropertyName = "Tipo", HeaderText = "Tipo", Width = 150, ReadOnly = true });
        }

        private void CargarEquipos()
        {
            // 1. Buscamos inteligentemente los IDs de las categorías que sean Impresoras
            var idsImpresoras = _tipoService.ObtenerTipos()
                .Where(t => t.Nombre.ToLower().Contains("impresora") ||
                            t.Nombre.ToLower().Contains("escaner") ||
                            t.Nombre.ToLower().Contains("escáner") ||
                            t.Nombre.ToLower().Contains("multifuncional"))
                .Select(t => t.Id)
                .ToList();

            // 2. Traemos los equipos, pero los FILTRAMOS usando los IDs que encontramos
            var impresorasFiltradas = _equipoService.ObtenerEquipos()
                .Where(e => idsImpresoras.Contains(e.TipoEquipoId))
                .Select(e => new
                {
                    Id = e.Id,
                    Display = $"S/N: {e.NumeroSerie} - {e.Marca} {e.Modelo}"
                }).ToList();

            // 3. Llenamos el ComboBox solo con las impresoras
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbEquipos,
                impresorasFiltradas,
                "Display",
                "Id",
                new { Id = 0, Display = "Selecciona una Impresora..." }
            );

            cmbEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarConsumiblesEnGrid()
        {
            // Guardamos la lista en memoria y la pintamos en el Grid
            _todosLosConsumibles = _consumibleService.ObtenerTodos().ToList();
            dgvConsumibles.DataSource = _todosLosConsumibles;
        }

        // ===== 2. LA MAGIA VISUAL =====

        private void CmbEquipos_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // 1. Limpiamos todas las palomitas primero
            foreach (DataGridViewRow row in dgvConsumibles.Rows)
            {
                row.Cells["Compatible"].Value = false;
            }

            // 2. Verificamos si seleccionaron un equipo válido
            if (cmbEquipos.SelectedValue is not int equipoId || equipoId <= 0)
            {
                btnGuardar.Enabled = false;
                return;
            }

            btnGuardar.Enabled = true;

            // 3. Vamos a la BD a preguntar qué consumibles ya tiene asignados este equipo
            var consumiblesAsignados = _compatibilidadService.ObtenerConsumiblesCompatibles(equipoId)
                                                             .Select(c => c.Id)
                                                             .ToList();

            // 4. Ponemos la palomita en los que coincidan
            foreach (DataGridViewRow row in dgvConsumibles.Rows)
            {
                int consumibleId = Convert.ToInt32(row.Cells["Id"].Value);

                if (consumiblesAsignados.Contains(consumibleId))
                {
                    row.Cells["Compatible"].Value = true;
                }
            }
        }

        // ===== 3. GUARDAR LOS CAMBIOS =====

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (cmbEquipos.SelectedValue is not int equipoId || equipoId <= 0) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                dgvConsumibles.EndEdit(); // Forzamos al grid a guardar la última palomita que tocaron

                // Obtenemos lo que la base de datos tiene AHORITA (antes de guardar)
                var compatiblesActuales = _compatibilidadService.ObtenerConsumiblesCompatibles(equipoId)
                                                                .Select(c => c.Id)
                                                                .ToList();

                int agregados = 0;
                int removidos = 0;

                foreach (DataGridViewRow row in dgvConsumibles.Rows)
                {
                    int consumibleId = Convert.ToInt32(row.Cells["Id"].Value);
                    bool estaMarcado = Convert.ToBoolean(row.Cells["Compatible"].Value);
                    bool yaExistiaEnBD = compatiblesActuales.Contains(consumibleId);

                    // Si le pusieron palomita y no existía -> Lo agregamos
                    if (estaMarcado && !yaExistiaEnBD)
                    {
                        _compatibilidadService.AsignarTonerAImpresora(equipoId, consumibleId);
                        agregados++;
                    }
                    // Si le quitaron la palomita y sí existía -> Lo borramos
                    else if (!estaMarcado && yaExistiaEnBD)
                    {
                        _compatibilidadService.QuitarRelacion(equipoId, consumibleId);
                        removidos++;
                    }
                }

                MessageBox.Show($"¡Compatibilidad actualizada con éxito!\n\nSe agregaron {agregados} y se removieron {removidos} consumibles para este equipo.",
                                "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
