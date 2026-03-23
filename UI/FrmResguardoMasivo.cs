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
    public partial class FrmResguardoMasivo : Form
    {
        private readonly AdministrativoService _adminService = new AdministrativoService();
        private readonly ResponsableSistemasService _responsableService = new ResponsableSistemasService();
        private readonly EquipoService _equipoService = new EquipoService();
        private readonly ResguardoService _resguardoService = new ResguardoService();

        // BindingLists para que los ListBox se actualicen mágicamente al mover elementos
        private BindingList<Equipo> _equiposDisponibles = new BindingList<Equipo>();
        private BindingList<Equipo> _equiposAsignados = new BindingList<Equipo>();

        public int? AdministrativoIdPreseleccionado { get; set; }

        public FrmResguardoMasivo()
        {
            InitializeComponent();

            // Eventos principales
            this.Load += FrmResguardoMasivo_Load;
            cmbAdministrativo.SelectedIndexChanged += CmbAdministrativo_SelectedIndexChanged;
            cmbResponsableSistemas.SelectedIndexChanged += CmbResponsableSistemas_SelectedIndexChanged;

            // Eventos de botones
            btnAgregar.Click += BtnAgregar_Click;
            btnQuitar.Click += BtnQuitar_Click;
            btnAgregarTodos.Click += BtnAgregarTodos_Click;
            btnQuitarTodos.Click += BtnQuitarTodos_Click;
            btnGuardar.Click += BtnGuardar_Click;

            // Formatear cómo se ven los equipos en las listas
            lstDisponibles.Format += FormatearEquipoEnLista;
            lstAsignados.Format += FormatearEquipoEnLista;

            // Helpers UI
            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmResguardoMasivo_Load(object? sender, EventArgs e)
        {
            ConfigurarListas();
            CargarCombos();

            if (AdministrativoIdPreseleccionado.HasValue)
            {
                cmbAdministrativo.SelectedValue = AdministrativoIdPreseleccionado.Value;
            }

            EvaluarBotonGuardar();
        }

        // ==========================================
        // CONFIGURACIÓN UI Y CARGAS
        // ==========================================
        private void ConfigurarListas()
        {
            lstDisponibles.DataSource = _equiposDisponibles;
            lstDisponibles.SelectionMode = SelectionMode.MultiExtended; // Permite seleccionar varios con Shift o Ctrl

            lstAsignados.DataSource = _equiposAsignados;
            lstAsignados.SelectionMode = SelectionMode.MultiExtended;
        }

        private void FormatearEquipoEnLista(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Equipo eq)
            {
                e.Value = $"{eq.Marca} {eq.Modelo} (S/N: {eq.NumeroSerie})";
            }
        }

        private void CargarCombos()
        {
            // Administrativos
            var admins = _adminService.ObtenerAdministrativos().OrderBy(a => a.NombreCompleto).ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo, admins, "NombreCompleto", "Id",
                new Administrativo { Id = 0, NombreCompleto = "Selecciona un Administrativo..." });

            // Técnicos / Responsables de Sistemas
            var responsables = _responsableService.ObtenerResponsables().OrderBy(r => r.AdministrativoNombre).ToList();
            ComboBoxHelper.CargarConSeleccionDefault(
                cmbResponsableSistemas, responsables, "AdministrativoNombre", "Id",
                new ResponsableSistemas { Id = 0, AdministrativoNombre = "Técnico que entrega..." });
        }

        // ==========================================
        // REACCIÓN A LOS COMBOBOX
        // ==========================================
        private void CmbAdministrativo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Limpiamos todo si cambia de administrativo
            _equiposDisponibles.Clear();
            _equiposAsignados.Clear();

            if (cmbAdministrativo.SelectedValue is int idAdmin && idAdmin > 0)
            {
                try
                {
                    // Llenamos la lista izquierda con los equipos que no tienen resguardo
                    var disponibles = _equipoService.ObtenerEquiposSinResguardo();
                    foreach (var eq in disponibles)
                    {
                        _equiposDisponibles.Add(eq);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los equipos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            EvaluarBotonGuardar();
        }

        private void CmbResponsableSistemas_SelectedIndexChanged(object? sender, EventArgs e)
        {
            EvaluarBotonGuardar();
        }

        // ==========================================
        // MOVIMIENTO ENTRE LISTAS (ESTILO DJANGO)
        // ==========================================
        private void BtnAgregar_Click(object? sender, EventArgs e) => MoverEquipos(lstDisponibles, _equiposDisponibles, _equiposAsignados);
        private void BtnQuitar_Click(object? sender, EventArgs e) => MoverEquipos(lstAsignados, _equiposAsignados, _equiposDisponibles);
        private void BtnAgregarTodos_Click(object? sender, EventArgs e) => MoverTodos(_equiposDisponibles, _equiposAsignados);
        private void BtnQuitarTodos_Click(object? sender, EventArgs e) => MoverTodos(_equiposAsignados, _equiposDisponibles);

        private void MoverEquipos(ListBox listaOrigen, BindingList<Equipo> origen, BindingList<Equipo> destino)
        {
            // Extraemos los que el usuario seleccionó
            var seleccionados = listaOrigen.SelectedItems.Cast<Equipo>().ToList();
            foreach (var eq in seleccionados)
            {
                origen.Remove(eq);
                destino.Add(eq);
            }
            EvaluarBotonGuardar();
        }

        private void MoverTodos(BindingList<Equipo> origen, BindingList<Equipo> destino)
        {
            foreach (var eq in origen.ToList()) // ToList() hace una copia para poder borrar sin error
            {
                origen.Remove(eq);
                destino.Add(eq);
            }
            EvaluarBotonGuardar();
        }

        // ==========================================
        // GUARDAR DATOS EN BASE DE DATOS
        // ==========================================
        private void EvaluarBotonGuardar()
        {
            // Solo se enciende si eligió un Admin, eligió un Técnico, y pasó al menos 1 equipo a la derecha
            btnGuardar.Enabled = (cmbAdministrativo.SelectedValue is int idAdmin && idAdmin > 0) &&
                                 (cmbResponsableSistemas.SelectedValue is int idTec && idTec > 0) &&
                                 _equiposAsignados.Count > 0;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"¿Estás seguro de que deseas asignar estos {_equiposAsignados.Count} equipos al administrativo seleccionado?",
                "Confirmar Asignación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;

                int idAdmin = (int)cmbAdministrativo.SelectedValue!;
                int idTecnico = (int)cmbResponsableSistemas.SelectedValue!;
                DateTime fecha = dtpFechaResguardo.Value;

                // Extraemos solo los IDs de los equipos que quedaron en la lista derecha
                var idsEquipos = _equiposAsignados.Select(eq => eq.Id).ToList();

                // Llamada al servicio que genera los códigos consecutivos y guarda
                _resguardoService.CrearResguardoMasivo(idsEquipos, idAdmin, idTecnico, fecha);

                MessageBox.Show($"¡Éxito! Se generaron {_equiposAsignados.Count} resguardos correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reiniciamos el formulario dejándolo listo para otra persona
                cmbAdministrativo.SelectedIndex = 0;
                cmbResponsableSistemas.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
