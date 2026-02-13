using AppEscritorioUPT.Data;
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

namespace AppEscritorioUPT.UI
{
    public partial class FrmEquipos : Form
    {
        private readonly EquipoService _equipoService = new EquipoService();
        private readonly TipoEquipoService _tipoService = new TipoEquipoService();

        private Equipo? _equipoSeleccionado;

        public FrmEquipos()
        {
            InitializeComponent();

            this.Load += FrmEquipos_Load;

            btnAgregar.Click += BtnAgregar_Click;
            btnActualizar.Click += BtnActualizar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            dgvEquipos.CellClick += DgvEquipos_CellClick;

            cmbTipoEquipo.SelectedIndexChanged += cmbTipoEquipo_SelectedIndexChanged;
            // NUEVO: cuando cambie el tipo de PC
            rbPcEscritorio.CheckedChanged += RbTipoPc_CheckedChanged;
            rbAllInOne.CheckedChanged += RbTipoPc_CheckedChanged;
        }

        // ========== LOAD ==========

        private void FrmEquipos_Load(object? sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarCombos();
            CargarEquipos();

            cmbTipoEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEquipo.DropDownWidth = 220;

            ActualizarSeccionesPorTipo(); // si ya la tienes
            ActualizarUiTipoPc();         // asegura que el panel arranque bien

            cmbTipoImpresion.Items.AddRange(new object[]
            {
                "Láser",
                "Inyección de tinta",
                "Tinta continua",
                "Multifuncional",
                "Escáner"
            });
        }

        // ========== CONFIGURACIÓN GRID ==========

        private void ConfigurarGrid()
        {
            dgvEquipos.ReadOnly = true;
            dgvEquipos.MultiSelect = false;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.AllowUserToAddRows = false;
            dgvEquipos.AllowUserToDeleteRows = false;
            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvEquipos.ScrollBars = ScrollBars.Both;
        }

        // ========== CARGA DE DATOS ==========

        private void CargarCombos()
        {
            var tipos = _tipoService.ObtenerTipos();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbTipoEquipo,
                tipos,
                displayMember: "Nombre",
                valueMember: "Id",
                itemDefault: new TipoEquipo
                {
                    Id = 0,
                    Nombre = "Selecciona una opción"
                }
            );
        }

        private void CargarEquipos()
        {
            var equipos = _equipoService.ObtenerEquipos().ToList();
            var tipos = _tipoService.ObtenerTipos().ToList();

            // Asignamos nombre de tipo al objeto para mostrarlo en el DataGridView
            foreach (var eq in equipos)
            {
                eq.TipoNombre = tipos.FirstOrDefault(t => t.Id == eq.TipoEquipoId)?.Nombre ?? string.Empty;
            }

            dgvEquipos.DataSource = equipos;

            if (dgvEquipos.Columns["Id"] != null)
                dgvEquipos.Columns["Id"].Visible = false;

            if (dgvEquipos.Columns["TipoEquipoId"] != null)
                dgvEquipos.Columns["TipoEquipoId"].Visible = false;

            if (dgvEquipos.Columns["TipoNombre"] != null)
                dgvEquipos.Columns["TipoNombre"].HeaderText = "Tipo de equipo";

            if (dgvEquipos.Columns["NumeroSerie"] != null)
                dgvEquipos.Columns["NumeroSerie"].HeaderText = "Núm. serie";

            if (dgvEquipos.Columns["DireccionIp"] != null)
                dgvEquipos.Columns["DireccionIp"].HeaderText = "Dirección IP";
        }

        // ========== UTILIDADES ==========

        private void LimpiarFormulario()
        {
            // ===== Campos comunes =====
            txtMarca.Clear();
            txtModelo.Clear();
            txtNumeroSerie.Clear();
            txtDireccionIp.Clear();

            // ===== Campos de PC =====
            txtMemoriaRam.Clear();
            txtProcesador.Clear();
            txtDiscoDuro.Clear();
            chkTieneLectorCd.Checked = false;

            rbPcEscritorio.Checked = false;
            rbAllInOne.Checked = false;

            // Periféricos
            txtMarcaMonitor.Clear();
            txtModeloMonitor.Clear();
            txtSerieMonitor.Clear();

            txtMarcaTeclado.Clear();
            txtModeloTeclado.Clear();
            txtSerieTeclado.Clear();

            txtMarcaMouse.Clear();
            txtModeloMouse.Clear();
            txtSerieMouse.Clear();

            txtMarcaWebcam.Clear();
            txtModeloWebcam.Clear();
            txtSerieWebcam.Clear();

            txtMacAddress.Clear();
            txtNumeroExtension.Clear();
            txtPrivilegiosLlamadas.Clear();

            // ===== Impresora / Escáner =====
            cmbTipoImpresion.SelectedIndex = -1;

            // ===== Estado del formulario =====
            _equipoSeleccionado = null;

            // Restablecer tipo de equipo (opcional)
            if (cmbTipoEquipo.Items.Count > 0)
                cmbTipoEquipo.SelectedIndex = 0;

            // Ocultar secciones dinámicas
            pnlPc.Visible = false;
            pnlImpresora.Visible = false;
            pnlTelefono.Visible = false;
        }

        private bool Validar()
        {
            // 1. Tipo de equipo obligatorio
            if (cmbTipoEquipo.SelectedValue is not int tipoId || tipoId <= 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de equipo.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoEquipo.Focus();
                return false;
            }

            // 2. Campos comunes
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("La marca es obligatoria.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMarca.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("El modelo es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModelo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroSerie.Text))
            {
                MessageBox.Show("El número de serie es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroSerie.Focus();
                return false;
            }

            // 3. Validaciones según panel visible (no amarramos a IDs de catálogo)
            // ===== PC / All in One =====
            if (pnlPc.Visible)
            {
                if (string.IsNullOrWhiteSpace(txtMemoriaRam.Text))
                {
                    MessageBox.Show("La memoria RAM es obligatoria para equipos de cómputo.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMemoriaRam.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtProcesador.Text))
                {
                    MessageBox.Show("El procesador es obligatorio para equipos de cómputo.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProcesador.Focus();
                    return false;
                }

                // Si es PC de escritorio y muestras periféricos, puedes exigir algunos:
                if (rbPcEscritorio.Checked && pnlPerifericos.Visible)
                {
                    if (string.IsNullOrWhiteSpace(txtMarcaMonitor.Text) ||
                        string.IsNullOrWhiteSpace(txtModeloMonitor.Text))
                    {
                        MessageBox.Show("Capture al menos la marca y modelo del monitor.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMarcaMonitor.Focus();
                        return false;
                    }
                }
            }

            // ===== Impresora / Escáner =====
            if (pnlImpresora.Visible)
            {
                if (cmbTipoImpresion.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar el tipo de impresión.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipoImpresion.Focus();
                    return false;
                }
            }

            // ===== Telefonía IP =====
            if (pnlTelefono.Visible)
            {
                if (string.IsNullOrWhiteSpace(txtMacAddress.Text))
                {
                    MessageBox.Show("La dirección MAC es obligatoria para teléfonos IP.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMacAddress.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtNumeroExtension.Text))
                {
                    MessageBox.Show("El número de extensión es obligatorio para teléfonos IP.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumeroExtension.Focus();
                    return false;
                }
            }

            return true;
        }

        // ========== BOTONES ==========

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                int tipoId = (int)cmbTipoEquipo.SelectedValue!;

                var marca = txtMarca.Text;
                var modelo = txtModelo.Text;
                var serie = txtNumeroSerie.Text;
                var ip = txtDireccionIp.Text;

                // Datos de PC
                var memoriaRam = txtMemoriaRam.Text;
                var procesador = txtProcesador.Text;
                var discoDuro = txtDiscoDuro.Text;
                bool tieneLectorCd = chkTieneLectorCd.Checked;

                // Tipo de PC
                bool esPcEscritorio = rbPcEscritorio.Checked;
                bool esAllInOne = rbAllInOne.Checked;

                // Periféricos (solo si el panel está visible)
                string? marcaMonitor = pnlPerifericos.Visible ? txtMarcaMonitor.Text : null;
                string? modeloMonitor = pnlPerifericos.Visible ? txtModeloMonitor.Text : null;
                string? serieMonitor = pnlPerifericos.Visible ? txtSerieMonitor.Text : null;

                string? marcaTeclado = pnlPerifericos.Visible ? txtMarcaTeclado.Text : null;
                string? modeloTeclado = pnlPerifericos.Visible ? txtModeloTeclado.Text : null;
                string? serieTeclado = pnlPerifericos.Visible ? txtSerieTeclado.Text : null;

                string? marcaMouse = pnlPerifericos.Visible ? txtMarcaMouse.Text : null;
                string? modeloMouse = pnlPerifericos.Visible ? txtModeloMouse.Text : null;
                string? serieMouse = pnlPerifericos.Visible ? txtSerieMouse.Text : null;

                string? marcaWebcam = pnlPerifericos.Visible ? txtMarcaWebcam.Text : null;
                string? modeloWebcam = pnlPerifericos.Visible ? txtModeloWebcam.Text : null;
                string? serieWebcam = pnlPerifericos.Visible ? txtSerieWebcam.Text : null;

                var nuevo = new Equipo
                {
                    TipoEquipoId = tipoId,
                    Marca = marca,
                    Modelo = modelo,
                    NumeroSerie = serie,
                    DireccionIp = ip,

                    MemoriaRam = memoriaRam,
                    Procesador = procesador,
                    DiscoDuro = discoDuro,
                    TieneLectorCd = tieneLectorCd,

                    EsPcEscritorio = esPcEscritorio,
                    EsAllInOne = esAllInOne,

                    MarcaMonitor = marcaMonitor,
                    ModeloMonitor = modeloMonitor,
                    SerieMonitor = serieMonitor,

                    MarcaTeclado = marcaTeclado,
                    ModeloTeclado = modeloTeclado,
                    SerieTeclado = serieTeclado,

                    MarcaMouse = marcaMouse,
                    ModeloMouse = modeloMouse,
                    SerieMouse = serieMouse,

                    MarcaWebcam = marcaWebcam,
                    ModeloWebcam = modeloWebcam,
                    SerieWebcam = serieWebcam,

                    // Impresora / Escáner
                    TipoImpresion = pnlImpresora.Visible
                        ? cmbTipoImpresion.SelectedItem?.ToString()
                        : null,

                    // Telefonía IP
                    MacAddress = pnlTelefono.Visible ? txtMacAddress.Text : null,
                    NumeroExtension = pnlTelefono.Visible ? txtNumeroExtension.Text : null,
                    PrivilegiosLlamadas = pnlTelefono.Visible ? txtPrivilegiosLlamadas.Text : null
                };

                _equipoService.CrearEquipo(nuevo);

                CargarEquipos();
                LimpiarFormulario();
                dgvEquipos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            if (_equipoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un equipo de la tabla para actualizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Validar()) return;

            try
            {
                _equipoSeleccionado.TipoEquipoId = (int)cmbTipoEquipo.SelectedValue!;

                _equipoSeleccionado.Marca = txtMarca.Text;
                _equipoSeleccionado.Modelo = txtModelo.Text;
                _equipoSeleccionado.NumeroSerie = txtNumeroSerie.Text;
                _equipoSeleccionado.DireccionIp = txtDireccionIp.Text;

                // Panel PC
                _equipoSeleccionado.MemoriaRam = txtMemoriaRam.Text;
                _equipoSeleccionado.Procesador = txtProcesador.Text;
                _equipoSeleccionado.DiscoDuro = txtDiscoDuro.Text;
                _equipoSeleccionado.TieneLectorCd = chkTieneLectorCd.Checked;

                _equipoSeleccionado.EsPcEscritorio = rbPcEscritorio.Checked;
                _equipoSeleccionado.EsAllInOne = rbAllInOne.Checked;

                if (pnlPerifericos.Visible)
                {
                    _equipoSeleccionado.MarcaMonitor = txtMarcaMonitor.Text;
                    _equipoSeleccionado.ModeloMonitor = txtModeloMonitor.Text;
                    _equipoSeleccionado.SerieMonitor = txtSerieMonitor.Text;

                    _equipoSeleccionado.MarcaTeclado = txtMarcaTeclado.Text;
                    _equipoSeleccionado.ModeloTeclado = txtModeloTeclado.Text;
                    _equipoSeleccionado.SerieTeclado = txtSerieTeclado.Text;

                    _equipoSeleccionado.MarcaMouse = txtMarcaMouse.Text;
                    _equipoSeleccionado.ModeloMouse = txtModeloMouse.Text;
                    _equipoSeleccionado.SerieMouse = txtSerieMouse.Text;

                    _equipoSeleccionado.MarcaWebcam = txtMarcaWebcam.Text;
                    _equipoSeleccionado.ModeloWebcam = txtModeloWebcam.Text;
                    _equipoSeleccionado.SerieWebcam = txtSerieWebcam.Text;
                }
                else
                {
                    // Si es All in One, limpiamos periféricos
                    _equipoSeleccionado.MarcaMonitor = null;
                    _equipoSeleccionado.ModeloMonitor = null;
                    _equipoSeleccionado.SerieMonitor = null;
                    _equipoSeleccionado.MarcaTeclado = null;
                    _equipoSeleccionado.ModeloTeclado = null;
                    _equipoSeleccionado.SerieTeclado = null;
                    _equipoSeleccionado.MarcaMouse = null;
                    _equipoSeleccionado.ModeloMouse = null;
                    _equipoSeleccionado.SerieMouse = null;
                    _equipoSeleccionado.MarcaWebcam = null;
                    _equipoSeleccionado.ModeloWebcam = null;
                    _equipoSeleccionado.SerieWebcam = null;
                }
                _equipoSeleccionado.TipoImpresion = pnlImpresora.Visible
                ? cmbTipoImpresion.SelectedItem?.ToString()
                : null;

                _equipoSeleccionado.MacAddress = pnlTelefono.Visible
                    ? txtMacAddress.Text
                    : null;

                _equipoSeleccionado.NumeroExtension = pnlTelefono.Visible
                    ? txtNumeroExtension.Text
                    : null;

                _equipoSeleccionado.PrivilegiosLlamadas = pnlTelefono.Visible
                    ? txtPrivilegiosLlamadas.Text
                    : null;

                _equipoService.ActualizarEquipo(_equipoSeleccionado);

                CargarEquipos();
                LimpiarFormulario();
                dgvEquipos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_equipoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un equipo para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Seguro que desea eliminar el equipo seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _equipoService.EliminarEquipo(_equipoSeleccionado.Id);

                    CargarEquipos();
                    LimpiarFormulario();
                    dgvEquipos.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========== SELECCIÓN EN GRID ==========

        private void DgvEquipos_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Si se hace clic en el encabezado o fuera de las filas
            if (e.RowIndex < 0)
            {
                dgvEquipos.ClearSelection(); // Quita cualquier selección
                LimpiarFormulario();       // Limpia los controles y _adminSeleccionado
                return;
            }

            var fila = dgvEquipos.Rows[e.RowIndex];

            if (fila.DataBoundItem is Equipo eq)
            {
                _equipoSeleccionado = eq;

                // Tipo de equipo primero, para decidir panel
                cmbTipoEquipo.SelectedValue = eq.TipoEquipoId;
                ActualizarSeccionesPorTipo();

                txtMarca.Text = eq.Marca;
                txtModelo.Text = eq.Modelo;
                txtNumeroSerie.Text = eq.NumeroSerie;
                txtDireccionIp.Text = eq.DireccionIp;

                // ===== PC / All in One =====
                if (pnlPc.Visible)
                {
                    txtMemoriaRam.Text = eq.MemoriaRam;
                    txtProcesador.Text = eq.Procesador;
                    txtDiscoDuro.Text = eq.DiscoDuro;
                    chkTieneLectorCd.Checked = eq.TieneLectorCd ?? false;

                    rbPcEscritorio.Checked = eq.EsPcEscritorio;
                    rbAllInOne.Checked = eq.EsAllInOne;

                    // Periféricos (solo si aplica)
                    if (rbPcEscritorio.Checked)
                    {
                        txtMarcaMonitor.Text = eq.MarcaMonitor;
                        txtModeloMonitor.Text = eq.ModeloMonitor;
                        txtSerieMonitor.Text = eq.SerieMonitor;

                        txtMarcaTeclado.Text = eq.MarcaTeclado;
                        txtModeloTeclado.Text = eq.ModeloTeclado;
                        txtSerieTeclado.Text = eq.SerieTeclado;

                        txtMarcaMouse.Text = eq.MarcaMouse;
                        txtModeloMouse.Text = eq.ModeloMouse;
                        txtSerieMouse.Text = eq.SerieMouse;

                        txtMarcaWebcam.Text = eq.MarcaWebcam;
                        txtModeloWebcam.Text = eq.ModeloWebcam;
                        txtSerieWebcam.Text = eq.SerieWebcam;
                    }

                    // Asegura que el panel de periféricos esté correcto
                    ActualizarUiTipoPc();
                }

                // ===== Impresora / Escáner =====
                if (pnlImpresora.Visible)
                {
                    cmbTipoImpresion.SelectedItem = eq.TipoImpresion;
                }
                else
                {
                    cmbTipoImpresion.SelectedIndex = -1;
                }

                // Telefonía IP
                if (pnlTelefono.Visible)
                {
                    txtMacAddress.Text = eq.MacAddress;
                    txtNumeroExtension.Text = eq.NumeroExtension;
                    txtPrivilegiosLlamadas.Text = eq.PrivilegiosLlamadas;
                }
                else
                {
                    txtMacAddress.Clear();
                    txtNumeroExtension.Clear();
                    txtPrivilegiosLlamadas.Clear();
                }
            }
        }

        private void RbTipoPc_CheckedChanged(object? sender, EventArgs e)
        {
            ActualizarUiTipoPc();
        }

        private void ActualizarUiTipoPc()
        {
            // Si es PC de escritorio → mostrar panel de periféricos
            if (rbPcEscritorio.Checked)
            {
                pnlPerifericos.Visible = true;
            }
            else
            {
                // All in One o ninguno → ocultamos periféricos
                pnlPerifericos.Visible = false;

                // Opcional: limpiar campos cuando se ocultan
                txtMarcaMonitor.Text = string.Empty;
                txtModeloMonitor.Text = string.Empty;
                txtSerieMonitor.Text = string.Empty;

                txtMarcaTeclado.Text = string.Empty;
                txtModeloTeclado.Text = string.Empty;
                txtSerieTeclado.Text = string.Empty;

                txtMarcaMouse.Text = string.Empty;
                txtModeloMouse.Text = string.Empty;
                txtSerieMouse.Text = string.Empty;

                txtMarcaWebcam.Text = string.Empty;
                txtModeloWebcam.Text = string.Empty;
                txtSerieWebcam.Text = string.Empty;
            }
        }

        private void cmbTipoEquipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Por ahora solo llamamos a ActualizarSeccionesPorTipo,
            // aunque sea un método "vacío" (lo definimos en el siguiente punto)
            ActualizarSeccionesPorTipo();
        }

        // Se llamará cada vez que cambies el "Tipo de Equipo" del combo.
        // Más adelante aquí decidiremos qué panel mostrar (PC, impresora, teléfono, etc.)
        private void ActualizarSeccionesPorTipo()
        {
            // 1) Ocultar todos los paneles
            pnlPc.Visible = false;
            pnlImpresora.Visible = false;
            pnlTelefono.Visible = false;

            // 2) Si está en "Selecciona una opción" (Id = 0) o algo inválido,
            //    NO debemos mostrar ningún panel.
            if (cmbTipoEquipo.SelectedValue is not int tipoId || tipoId <= 0)
            {
                // Además aseguramos que los periféricos no se muestren
                pnlPerifericos.Visible = false;
                return;
            }

            // 3) A partir de aquí, ya sabemos que es un tipo válido
            var tipoTexto = (cmbTipoEquipo.Text ?? string.Empty).ToLower();

            // Normalizamos acentos básicos
            tipoTexto = tipoTexto.Replace("á", "a").Replace("é", "e")
                                 .Replace("í", "i").Replace("ó", "o")
                                 .Replace("ú", "u");

            

            // ====== COMPUTADORAS ======
            if (tipoTexto.Contains("pc") ||
                tipoTexto.Contains("escritorio") ||
                tipoTexto.Contains("laptop") ||
                tipoTexto.Contains("all in one") ||
                tipoTexto.Contains("all-in-one"))
            {
                pnlPc.Visible = true;
                pnlPc.BringToFront();
                ActualizarUiTipoPc();
                return;
            }

            // ====== IMPRESORA / ESCÁNER ======
            if (tipoTexto.Contains("impresora") ||
                tipoTexto.Contains("escaner") ||
                tipoTexto.Contains("escáner"))
            {
                pnlImpresora.Visible = true;
                pnlImpresora.BringToFront();
                return;
            }

            // ====== TELEFONÍA IP ======
            if (tipoTexto.Contains("telefono") ||
                tipoTexto.Contains("teléfono") ||
                tipoTexto.Contains("ip"))
            {
                pnlTelefono.Visible = true;
                pnlTelefono.BringToFront();
                return;
            }

            // Además actualizamos la parte de radio buttons / periféricos
            ActualizarUiTipoPc();
        }

    }
}
