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
    public partial class FrmEquiposPorLote : Form
    {
        // Lista dinámica para el DataGrid
        private BindingList<DetalleEquipoLote> _detallesLote = new BindingList<DetalleEquipoLote>();

        // Servicios
        private readonly TipoEquipoService _tipoService = new TipoEquipoService();
        private readonly AdministrativoService _adminService = new AdministrativoService();
        private readonly ResponsableSistemasService _responsableService = new ResponsableSistemasService();
        private readonly TipoUsoService _tipoUsoService = new TipoUsoService();
        private readonly EquipoService _equipoService = new EquipoService();
        private readonly ResguardoService _resguardoService = new ResguardoService();

        public FrmEquiposPorLote()
        {
            InitializeComponent();

            // Eventos
            this.Load += FrmEquiposPorLote_Load;
            nudCantidad.ValueChanged += NudCantidad_ValueChanged;

            // Escuchamos a los RadioButtons
            rbPcEscritorio.CheckedChanged += RbTipoPc_CheckedChanged;
            rbAllInOne.CheckedChanged += RbTipoPc_CheckedChanged;

            // Evento del ComboBox
            cmbTipoEquipo.SelectedIndexChanged += CmbTipoEquipo_SelectedIndexChanged;

            btnGuardar.Click += BtnGuardar_Click;

            // 1. Cajas de texto (cada vez que teclean una letra)
            txtMarca.TextChanged += EvaluarEstadoBotonGuardar;
            txtModelo.TextChanged += EvaluarEstadoBotonGuardar;
            txtMemoriaRam.TextChanged += EvaluarEstadoBotonGuardar;
            txtProcesador.TextChanged += EvaluarEstadoBotonGuardar;
            txtDiscoDuro.TextChanged += EvaluarEstadoBotonGuardar;

            // 2. Comboboxes de Asignación (cada vez que eligen algo diferente)
            cmbAdministrativo.SelectedIndexChanged += EvaluarEstadoBotonGuardar;
            cmbResponsableSistemas.SelectedIndexChanged += EvaluarEstadoBotonGuardar;
            cmbTipoEquipo.SelectedIndexChanged += EvaluarEstadoBotonGuardar; // Este ya lo tenías, pero puedes conectarle los dos sin problema

            // 3. El DataGrid (cada vez que escriben números de serie)
            dgvEquipos.CurrentCellDirtyStateChanged += DgvEquipos_CurrentCellDirtyStateChanged;
            dgvEquipos.CellValueChanged += DgvEquipos_CellValueChanged;
            nudCantidad.ValueChanged += EvaluarEstadoBotonGuardar;

            // 4. Apagamos el botón por defecto al arrancar la pantalla
            btnGuardar.Enabled = false;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmEquiposPorLote_Load(object? sender, EventArgs e)
        {
            // 1. Enlazamos la lista al grid
            dgvEquipos.DataSource = _detallesLote;

            // 2. Usamos el Helper para ponerlo bonito
            LoteGridHelper.ConfigurarGridBase(dgvEquipos);

            // 3. Cargar datos de la base de datos
            CargarCombos();

            // 4. Ajustar la pantalla por defecto
            ActualizarSeccionesPorTipo();
        }

        private void CargarCombos()
        {
            // 1. Tipos de Equipo
            var tipos = _tipoService.ObtenerTipos().ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbTipoEquipo, tipos, "Nombre", "Id",
                new TipoEquipo { Id = 0, Nombre = "Selecciona una opción" }
            );

            // 2. Administrativos
            var admins = _adminService.ObtenerAdministrativos().OrderBy(a => a.NombreCompleto).ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo, admins, "NombreCompleto", "Id",
                new Administrativo { Id = 0, NombreCompleto = "Selecciona un Administrativo..." }
            );

            // 3. Responsables de Sistemas (Técnicos)
            var responsables = _responsableService.ObtenerResponsables().OrderBy(r => r.AdministrativoNombre).ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbResponsableSistemas, responsables, "AdministrativoNombre", "Id",
                new ResponsableSistemas { Id = 0, AdministrativoNombre = "Técnico que entrega..." }
            );

            // 4. Tipos de Uso (Etiquetas)
            var tiposUso = _tipoUsoService.ObtenerTiposUso().ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbTipoUso, tiposUso, "Nombre", "Id",
                new TipoUso { Id = 0, Nombre = "Seleccione el Tipo de Uso..." }
            );

            // Seleccionar "USO ADMINISTRATIVO" (Id = 1) por defecto si existe
            if (tiposUso.Any(t => t.Id == 1))
                cmbTipoUso.SelectedValue = 1;
        }

        // ===== LÓGICA DE PANELES (Basada en FrmEquipos) =====
        private void CmbTipoEquipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LimpiarDatosAlCambiarTipo();
            ActualizarSeccionesPorTipo();
        }

        private void ActualizarSeccionesPorTipo()
        {
            // 1) Ocultamos el ÚNICO panel dinámico de la pantalla
            pnlPc.Visible = false;

            // 2) Si está en "Selecciona una opción", apagamos las columnas del DataGrid
            if (cmbTipoEquipo.SelectedValue is not int tipoId || tipoId <= 0)
            {
                // Un pequeño truco para que el Helper oculte todo mandando un texto que no existe
                LoteGridHelper.AjustarColumnasPorTipo(dgvEquipos, "NINGUNO");
                return;
            }

            // 3) Normalizamos el texto del ComboBox
            var tipoTexto = (cmbTipoEquipo.Text ?? string.Empty).ToLower();
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
                // Aquí SÍ mostramos el panel porque comparten RAM, Procesador, etc.
                pnlPc.Visible = true;

                // Y le decimos al DataGrid qué columnas pintar
                if (rbPcEscritorio.Checked)
                    LoteGridHelper.AjustarColumnasPorTipo(dgvEquipos, "PC_ESCRITORIO");
                else
                    LoteGridHelper.AjustarColumnasPorTipo(dgvEquipos, "LAPTOP_AIO");

                return;
            }

            // ====== TELEFONÍA IP ======
            if (tipoTexto.Contains("telefono") || tipoTexto.Contains("ip"))
            {
                // NO hay panel. La pantalla se queda limpia arriba.
                // SOLO le decimos al DataGrid que se prepare para recibir teléfonos.
                LoteGridHelper.AjustarColumnasPorTipo(dgvEquipos, "TELEFONO");
                return;
            }

            // ====== IMPRESORA / ESCÁNER ======
            if (tipoTexto.Contains("impresora") ||
                tipoTexto.Contains("escaner") ||
                tipoTexto.Contains("escáner"))
            {
                pnlPc.Visible = false; // Sin panel arriba
                LoteGridHelper.AjustarColumnasPorTipo(dgvEquipos, "IMPRESORA");
                return;
            }

            LoteGridHelper.AjustarColumnasPorTipo(dgvEquipos, "BASICO");
        }

        private void LimpiarDatosAlCambiarTipo()
        {
            // 1. Limpiamos las cajas de texto de la cabecera
            txtMarca.Clear();
            txtModelo.Clear();

            // 2. Limpiamos el panel de PC (aunque se oculte, hay que vaciarlo)
            txtMemoriaRam.Clear();
            txtProcesador.Clear();
            txtDiscoDuro.Clear();
            chkTieneLectorCd.Checked = false;

            // Opcional: si tienes combos o cosas dentro de los otros paneles (Teléfono, etc), vacíalos aquí también.

            // 3. ¡EL TRUCO MAESTRO! Bajamos el contador a 0 y borramos la lista
            // Esto forzará al DataGrid a destruir todas las filas y dejarlo en blanco.
            nudCantidad.Value = 0;
            _detallesLote.Clear();
        }


        // ===== EVENTOS DE RADIO BUTTONS Y CANTIDAD =====
        private void RbTipoPc_CheckedChanged(object? sender, EventArgs e)
        {
            // Si está marcado el de Escritorio, mandamos la palabra clave de PC
            if (rbPcEscritorio.Checked)
            {
                LoteGridHelper.AjustarColumnasPorTipo(dgvEquipos, "PC_ESCRITORIO");
            }
            // Si no, asumimos que es Laptop / All in One
            else
            {
                LoteGridHelper.AjustarColumnasPorTipo(dgvEquipos, "LAPTOP_AIO");
            }
        }

        private void NudCantidad_ValueChanged(object? sender, EventArgs e)
        {
            int cantidadDeseada = (int)nudCantidad.Value;
            int cantidadActual = _detallesLote.Count;

            if (cantidadDeseada > cantidadActual)
            {
                for (int i = cantidadActual; i < cantidadDeseada; i++)
                    _detallesLote.Add(new DetalleEquipoLote { Fila = i + 1 });
            }
            else if (cantidadDeseada < cantidadActual)
            {
                for (int i = cantidadActual - 1; i >= cantidadDeseada; i--)
                    _detallesLote.RemoveAt(i);
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            // 1. Validaciones básicas del "Molde"
            if (cmbTipoEquipo.SelectedValue is not int tipoId || tipoId <= 0)
            {
                MessageBox.Show("Seleccione el Tipo de Equipo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("La Marca y el Modelo generales son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                var loteEquipos = new List<Equipo>();

                // 2. Fusionar "El Molde" con "La Cuadrícula"
                foreach (var fila in _detallesLote)
                {
                    // Ignoramos las filas donde no hayan escrito Número de Serie (ej. las que dejaron en blanco)
                    if (string.IsNullOrWhiteSpace(fila.NumeroSerie)) continue;

                    var nuevoEquipo = new Equipo
                    {
                        TipoEquipoId = tipoId,

                        // ===== DATOS COMUNES (Del formulario principal) =====
                        Marca = txtMarca.Text.Trim(),
                        Modelo = txtModelo.Text.Trim(),

                        // Solo leemos el panel de PC si está visible
                        MemoriaRam = pnlPc.Visible ? txtMemoriaRam.Text : null,
                        Procesador = pnlPc.Visible ? txtProcesador.Text : null,
                        DiscoDuro = pnlPc.Visible ? txtDiscoDuro.Text : null,
                        TieneLectorCd = pnlPc.Visible && chkTieneLectorCd.Checked,
                        EsPcEscritorio = pnlPc.Visible && rbPcEscritorio.Checked,
                        EsAllInOne = pnlPc.Visible && rbAllInOne.Checked,

                        // ===== DATOS ÚNICOS (De la Fila del DataGrid) =====
                        NumeroSerie = fila.NumeroSerie.Trim(),
                        DireccionIp = fila.DireccionIp,
                        MacAddress = fila.MacAddress,
                        NumeroExtension = fila.NumeroExtension,
                        PrivilegiosLlamadas = fila.PrivilegiosLlamadas,
                        TipoImpresion = fila.TipoImpresion,

                        // Periféricos
                        MarcaMonitor = fila.MonitorMarca,
                        ModeloMonitor = fila.MonitorModelo,
                        SerieMonitor = fila.MonitorSerie,
                        MarcaTeclado = fila.TecladoMarca,
                        ModeloTeclado = fila.TecladoModelo,
                        SerieTeclado = fila.TecladoSerie,
                        MarcaMouse = fila.MouseMarca,
                        ModeloMouse = fila.MouseModelo,
                        SerieMouse = fila.MouseSerie
                    };

                    loteEquipos.Add(nuevoEquipo);
                }

                if (loteEquipos.Count == 0)
                {
                    MessageBox.Show("No capturó ningún Número de Serie en la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Mandar a guardar al Servicio (Nos devolverá los IDs nuevos)
                var idsGenerados = _equipoService.CrearLote(loteEquipos);

                // 4. ¿Quiere asignarlos de una vez?
                int idAdmin = cmbAdministrativo.SelectedValue is int a && a > 0 ? a : 0;
                int idTec = cmbResponsableSistemas.SelectedValue is int t && t > 0 ? t : 0;
                int idUso = cmbTipoUso.SelectedValue is int u && u > 0 ? u : 1;

                if (idAdmin > 0 && idTec > 0 && idsGenerados.Any())
                {
                    // ¡Reutilizamos la magia masiva de resguardos que hicimos ayer!
                    _resguardoService.CrearResguardoMasivo(
                        idsGenerados, idAdmin, idTec, DateTime.Today, null,idUso);
                }

                MessageBox.Show($"¡Éxito! Se registraron {idsGenerados.Count} equipos.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar lote", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LimpiarTodo()
        {
            // 1. Llamamos al que ya vacía las cajas de texto y el DataGrid
            LimpiarDatosAlCambiarTipo();

            // 2. Regresamos los combos de asignación a su valor por defecto (Id = 0)
            if (cmbAdministrativo.Items.Count > 0) cmbAdministrativo.SelectedValue = 0;
            if (cmbResponsableSistemas.Items.Count > 0) cmbResponsableSistemas.SelectedValue = 0;

            // 3. El Tipo de Uso lo regresamos al ID 1 (Uso Administrativo, o el que prefieras)
            if (cmbTipoUso.Items.Count > 0) cmbTipoUso.SelectedValue = 1;

            // 4. IMPORTANTE: Al final, regresamos el Tipo de Equipo a 0.
            // Esto provocará automáticamente que se dispare tu evento CmbTipoEquipo_SelectedIndexChanged,
            // el cual ocultará los paneles y apagará las columnas del DataGrid.
            if (cmbTipoEquipo.Items.Count > 0) cmbTipoEquipo.SelectedValue = 0;
        }

        private void DgvEquipos_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            // Este truco fuerza a la tabla a guardar el valor de la celda en el mismo instante en que tecleas
            if (dgvEquipos.IsCurrentCellDirty)
            {
                dgvEquipos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvEquipos_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            // Cuando la celda cambia su valor (gracias al truco de arriba), mandamos llamar al evaluador
            EvaluarEstadoBotonGuardar();
        }

        private void EvaluarEstadoBotonGuardar(object? sender = null, EventArgs? e = null)
        {
            bool todoLleno = true;

            // 1. Validar Combos de Asignación y Tipo
            if (cmbTipoEquipo.SelectedValue is not int tId || tId <= 0) todoLleno = false;
            if (cmbAdministrativo.SelectedValue is not int aId || aId <= 0) todoLleno = false;
            if (cmbResponsableSistemas.SelectedValue is not int rId || rId <= 0) todoLleno = false;

            // 2. Validar Campos Comunes
            if (string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtModelo.Text))
                todoLleno = false;

            // 3. Validar Panel de PC (Solo si está visible)
            if (pnlPc.Visible)
            {
                if (string.IsNullOrWhiteSpace(txtMemoriaRam.Text) ||
                    string.IsNullOrWhiteSpace(txtProcesador.Text) ||
                    string.IsNullOrWhiteSpace(txtDiscoDuro.Text))
                {
                    todoLleno = false;
                }
            }

            // 4. Validar el DataGrid (Que haya filas y que tengan Número de Serie)
            if (_detallesLote.Count == 0)
            {
                todoLleno = false;
            }
            else
            {
                foreach (var fila in _detallesLote)
                {
                    // El Número de Serie es el dato rey. Si una sola fila no lo tiene, bloqueamos.
                    if (string.IsNullOrWhiteSpace(fila.NumeroSerie))
                    {
                        todoLleno = false;
                        break;
                    }
                }
            }

            // 5. Encender o apagar el botón
            btnGuardar.Enabled = todoLleno;
        }

    }
}
