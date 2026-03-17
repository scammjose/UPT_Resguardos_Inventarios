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
    public partial class FrmConsultaEquipos : Form
    {
        private readonly EquipoService _equipoService = new EquipoService();
        private readonly TipoEquipoService _tipoService = new TipoEquipoService();

        public FrmConsultaEquipos()
        {
            InitializeComponent();

            // Eventos
            this.Load += FrmConsultaEquipos_Load;
            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;

            // Opcional: Que al hacer doble clic en una fila, haga algo (lo programaremos después)
            dgvResultados.CellDoubleClick += DgvResultados_CellDoubleClick;

            // Integración de tus Helpers
            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmConsultaEquipos_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarCombos();
            RealizarBusqueda(); // Al abrir, que cargue todos por defecto
        }

        private void ConfigurarGrid()
        {
            dgvResultados.ReadOnly = true;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvResultados.AllowUserToAddRows = false;
        }

        private void CargarCombos()
        {
            var tipos = _tipoService.ObtenerTipos();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbFiltroTipo,
                tipos,
                displayMember: "Nombre",
                valueMember: "Id",
                itemDefault: new TipoEquipo { Id = 0, Nombre = "Todos los tipos..." }
            );

            // Hacer que se pueda escribir para buscar rápido
            cmbFiltroTipo.DropDownStyle = ComboBoxStyle.DropDown;
            cmbFiltroTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbFiltroTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // =========================
        // MOTOR DE BÚSQUEDA
        // =========================
        private void RealizarBusqueda()
        {
            try
            {
                // 1. Obtenemos todos los equipos base
                var query = _equipoService.ObtenerEquipos().AsQueryable();

                // 2. Aplicamos FILTRO POR TIPO (Si seleccionó algo distinto a "Todos")
                if (cmbFiltroTipo.SelectedValue is int idTipo && idTipo > 0)
                {
                    query = query.Where(e => e.TipoEquipoId == idTipo);
                }

                // 3. Aplicamos FILTRO POR NÚMERO DE SERIE (Ignora mayúsculas/minúsculas)
                if (!string.IsNullOrWhiteSpace(txtFiltroSerie.Text))
                {
                    string serieBuscada = txtFiltroSerie.Text.Trim().ToLower();
                    query = query.Where(e => e.NumeroSerie != null && e.NumeroSerie.ToLower().Contains(serieBuscada));
                }

                // 4. Aplicamos FILTRO POR IP
                if (!string.IsNullOrWhiteSpace(txtFiltroIp.Text))
                {
                    string ipBuscada = txtFiltroIp.Text.Trim();
                    query = query.Where(e => e.DireccionIp != null && e.DireccionIp.Contains(ipBuscada));
                }

                // 5. Ejecutamos la consulta y cruzamos con los nombres de los Tipos para mostrar
                var resultados = query.ToList();
                var tipos = _tipoService.ObtenerTipos().ToList();

                foreach (var eq in resultados)
                {
                    eq.TipoNombre = tipos.FirstOrDefault(t => t.Id == eq.TipoEquipoId)?.Nombre ?? "Desconocido";
                }

                // 6. Asignamos al Grid
                dgvResultados.DataSource = resultados;
                OcultarColumnasTecnicas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarColumnasTecnicas()
        {
            if (dgvResultados.Columns["Id"] != null) dgvResultados.Columns["Id"].Visible = false;
            if (dgvResultados.Columns["TipoEquipoId"] != null) dgvResultados.Columns["TipoEquipoId"].Visible = false;

            if (dgvResultados.Columns["TipoNombre"] != null) dgvResultados.Columns["TipoNombre"].HeaderText = "Tipo de equipo";
            if (dgvResultados.Columns["NumeroSerie"] != null) dgvResultados.Columns["NumeroSerie"].HeaderText = "Núm. serie";
            if (dgvResultados.Columns["DireccionIp"] != null) dgvResultados.Columns["DireccionIp"].HeaderText = "Dirección IP";
        }

        // =========================
        // EVENTOS DE BOTONES
        // =========================
        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            RealizarBusqueda();
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            txtFiltroSerie.Clear();
            txtFiltroIp.Clear();
            cmbFiltroTipo.SelectedIndex = 0;

            RealizarBusqueda(); // Recarga todo sin filtros
        }

        private void DgvResultados_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var equipo = dgvResultados.Rows[e.RowIndex].DataBoundItem as Equipo;
            if (equipo != null)
            {
                // Aquí en el futuro podemos abrir el FrmEquipos y pasarle este ID para que lo edite
                MessageBox.Show($"Seleccionaste el equipo: {equipo.Marca} {equipo.Modelo} - S/N: {equipo.NumeroSerie}", "Detalles");
            }
        }
    }
}
