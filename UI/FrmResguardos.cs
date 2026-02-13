using AppEscritorioUPT.Domain;
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
using AppEscritorioUPT.Helpers;
using System.Collections;
using System.Diagnostics;

namespace AppEscritorioUPT.UI
{
    public partial class FrmResguardos : Form
    {
        private readonly ResguardoService _resguardoService = new ResguardoService();
        private readonly ResguardoReportService _resguardoReportService = new ResguardoReportService();
        private readonly EquipoService _equipoService = new EquipoService();
        private readonly AdministrativoService _administrativoService = new AdministrativoService();
        private readonly ResponsableSistemasService _responsableService = new ResponsableSistemasService();

        private Resguardo? _resguardoSeleccionado;
        public FrmResguardos()
        {
            InitializeComponent();
            this.Load += FrmResguardos_Load;

            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            dgvResguardos.CellClick += DgvResguardos_CellClick;
            dgvResguardos.CellContentClick += DgvResguardos_CellContentClick;
        }
        // ===== LOAD =====
        private void FrmResguardos_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarCombos();
            CargarResguardos();
            LimpiarFormulario();
        }

        private void ConfigurarGrid()
        {
            dgvResguardos.ReadOnly = true;
            dgvResguardos.MultiSelect = false;
            dgvResguardos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResguardos.AllowUserToAddRows = false;
            dgvResguardos.AllowUserToDeleteRows = false;
            dgvResguardos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvResguardos.ScrollBars = ScrollBars.Both;

            AgregarColumnaBotonPdf();
        }

        private void AgregarColumnaBotonPdf()
        {
            if (dgvResguardos.Columns["colPdf"] != null)
                return; // evitar duplicados

            var btnColumn = new DataGridViewButtonColumn
            {
                Name = "colPdf",
                HeaderText = "PDF",
                Text = "Generar",
                UseColumnTextForButtonValue = true,
                Width = 90
            };

            dgvResguardos.Columns.Add(btnColumn);
        }

        private void CargarCombos()
        {
            // Equipos
            var equipos = _equipoService.ObtenerEquipos();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbEquipo,
                equipos,
                displayMember: "DescripcionCorta",
                valueMember: "Id",
                itemDefault: new Equipo
                {
                    Id = 0,
                    Marca = "",   // no importa, DescripcionCorta lo ignora
                    Modelo = "",
                    NumeroSerie = ""
                }
            );

            // Administrativos
            var admins = _administrativoService.ObtenerAdministrativos()
                .OrderBy(a => a.NombreCompleto);

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo,
                admins,
                displayMember: "NombreCompleto",
                valueMember: "Id",
                itemDefault: new Administrativo
                {
                    Id = 0,
                    NombreCompleto = "Selecciona una opción"
                }
            );

            // Responsables de sistemas
            var responsables = _responsableService.ObtenerResponsables()
                .OrderBy(r => r.AdministrativoNombre);

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbResponsableSistemas,
                responsables,
                displayMember: "AdministrativoNombre",
                valueMember: "Id",
                itemDefault: new ResponsableSistemas
                {
                    Id = 0,
                    AdministrativoNombre = "Selecciona una opción"
                }
            );
        }

        private void CargarResguardos()
        {
            var lista = _resguardoService.ObtenerResguardos().ToList();
            dgvResguardos.DataSource = lista;

            if (dgvResguardos.Columns["Id"] != null)
                dgvResguardos.Columns["Id"].Visible = false;

            if (dgvResguardos.Columns["EquipoId"] != null)
                dgvResguardos.Columns["EquipoId"].Visible = false;
            if (dgvResguardos.Columns["AdministrativoId"] != null)
                dgvResguardos.Columns["AdministrativoId"].Visible = false;
            if (dgvResguardos.Columns["ResponsableSistemasId"] != null)
                dgvResguardos.Columns["ResponsableSistemasId"].Visible = false;

            if (dgvResguardos.Columns["CodigoInventario"] != null)
                dgvResguardos.Columns["CodigoInventario"].HeaderText = "Inventario";

            if (dgvResguardos.Columns["FechaResguardo"] != null)
                dgvResguardos.Columns["FechaResguardo"].HeaderText = "Fecha";

            if (dgvResguardos.Columns["EquipoDescripcion"] != null)
                dgvResguardos.Columns["EquipoDescripcion"].HeaderText = "Equipo";

            if (dgvResguardos.Columns["AdministrativoNombre"] != null)
                dgvResguardos.Columns["AdministrativoNombre"].HeaderText = "Responsable";

            if (dgvResguardos.Columns["AreaNombre"] != null)
                dgvResguardos.Columns["AreaNombre"].HeaderText = "Área";

            if (dgvResguardos.Columns["ResponsableSistemasNombre"] != null)
                dgvResguardos.Columns["ResponsableSistemasNombre"].HeaderText = "Resp. Sistemas";

            foreach (DataGridViewColumn col in dgvResguardos.Columns)
            {
                if (!col.Visible) continue;

                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // opcional: darles un poquito más de aire
                col.Width += 20;
            }
        }

        private void LimpiarFormulario()
        {
            txtCodigoInventario.Text = string.Empty;
            txtNotas.Clear();
            dtpFechaResguardo.Value = DateTime.Today;

            _resguardoSeleccionado = null;
            dgvResguardos.ClearSelection();

            if (cmbEquipo.Items.Count > 0)
                cmbEquipo.SelectedIndex = 0;
            if (cmbAdministrativo.Items.Count > 0)
                cmbAdministrativo.SelectedIndex = 0;
            if (cmbResponsableSistemas.Items.Count > 0)
                cmbResponsableSistemas.SelectedIndex = 0;
        }

        private bool Validar()
        {
            if (cmbEquipo.SelectedValue is not int equipoId || equipoId <= 0)
            {
                MessageBox.Show("Seleccione un equipo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEquipo.Focus();
                return false;
            }

            if (cmbAdministrativo.SelectedValue is not int adminId || adminId <= 0)
            {
                MessageBox.Show("Seleccione un administrativo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAdministrativo.Focus();
                return false;
            }

            if (cmbResponsableSistemas.SelectedValue is not int respSisId || respSisId <= 0)
            {
                MessageBox.Show("Seleccione un responsable de sistemas.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbResponsableSistemas.Focus();
                return false;
            }

            // Si quisieras agregar alguna validación de fecha o notas, este es el lugar.

            return true;
        }

        // ===== BOTONES =====

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                var equipoId = (int)cmbEquipo.SelectedValue!;
                var adminId = (int)cmbAdministrativo.SelectedValue!;
                var respSisId = (int)cmbResponsableSistemas.SelectedValue!;

                _resguardoService.CrearResguardo(
                    equipoId,
                    adminId,
                    respSisId,
                    dtpFechaResguardo.Value,
                    txtNotas.Text
                );

                CargarResguardos();
                LimpiarFormulario();

                MessageBox.Show("Resguardo registrado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            if (_resguardoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un resguardo en la tabla.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Validar()) return;

            try
            {
                var equipoId = (int)cmbEquipo.SelectedValue!;
                var adminId = (int)cmbAdministrativo.SelectedValue!;
                var respSisId = (int)cmbResponsableSistemas.SelectedValue!;

                _resguardoSeleccionado.EquipoId = equipoId;
                _resguardoSeleccionado.AdministrativoId = adminId;
                _resguardoSeleccionado.ResponsableSistemasId = respSisId;
                _resguardoSeleccionado.Notas = txtNotas.Text;

                _resguardoService.ActualizarResguardo(
                    _resguardoSeleccionado,
                    dtpFechaResguardo.Value,
                    txtNotas.Text
                );

                CargarResguardos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_resguardoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un resguardo en la tabla.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Seguro que desea eliminar el resguardo '{_resguardoSeleccionado.CodigoInventario}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _resguardoService.EliminarResguardo(_resguardoSeleccionado.Id);
                    CargarResguardos();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ===== GRID =====

        private void DgvResguardos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                LimpiarFormulario();
                return;
            }

            var fila = dgvResguardos.Rows[e.RowIndex];

            if (fila.DataBoundItem is Resguardo r)
            {
                _resguardoSeleccionado = r;

                txtCodigoInventario.Text = r.CodigoInventario;
                txtNotas.Text = r.Notas ?? string.Empty;

                if (DateTime.TryParse(r.FechaResguardo, out var fecha))
                    dtpFechaResguardo.Value = fecha;
                else
                    dtpFechaResguardo.Value = DateTime.Today;

                cmbEquipo.SelectedValue = r.EquipoId;
                cmbAdministrativo.SelectedValue = r.AdministrativoId;
                cmbResponsableSistemas.SelectedValue = r.ResponsableSistemasId;
            }
        }

        private void DgvResguardos_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Verificamos que la columna clickeada sea la del botón PDF
            if (dgvResguardos.Columns[e.ColumnIndex].Name != "colPdf")
                return; // <-- cambia "colPdf" por el Name real de tu columna

            // Obtenemos el resguardo asociado a esa fila
            var fila = dgvResguardos.Rows[e.RowIndex];
            if (fila.DataBoundItem is not Resguardo resguardo)
                return;

            try
            {
                // 1. Generar el PDF
                var rutaPdf = _resguardoReportService.GenerarPdfResguardo(resguardo.Id);

                // 2. Verificar que exista
                if (!File.Exists(rutaPdf))
                {
                    MessageBox.Show("No se pudo generar el PDF del resguardo.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Abrir con el visor predeterminado de Windows
                var psi = new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el PDF:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
