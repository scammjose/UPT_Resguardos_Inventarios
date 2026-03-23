using AppEscritorioUPT.Domain.Reports;
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
    public partial class FrmTransferenciaResguardos : Form
    {
        private readonly AdministrativoService _adminService = new AdministrativoService();
        private readonly ResguardoService _resguardoService = new ResguardoService();

        // Usaremos ResguardoReportModel porque ya trae el nombre del equipo y el AdministrativoId original
        private BindingList<ResguardoReportModel> _listaOrigen = new BindingList<ResguardoReportModel>();
        private BindingList<ResguardoReportModel> _listaDestino = new BindingList<ResguardoReportModel>();

        public FrmTransferenciaResguardos()
        {
            InitializeComponent();

            this.Load += FrmTransferenciaResguardos_Load;
            cmbOrigen.SelectedIndexChanged += CmbOrigen_SelectedIndexChanged;
            cmbDestino.SelectedIndexChanged += CmbDestino_SelectedIndexChanged;

            btnPasarDerecha.Click += BtnPasarDerecha_Click;
            btnPasarIzquierda.Click += BtnPasarIzquierda_Click;
            btnPasarTodosDerecha.Click += BtnPasarTodosDerecha_Click;
            btnPasarTodosIzquierda.Click += BtnPasarTodosIzquierda_Click;
            btnGuardar.Click += BtnGuardar_Click;

            // Formato para que se vea el Código + Descripción del equipo
            lstOrigen.Format += FormatearLista;
            lstDestino.Format += FormatearLista;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmTransferenciaResguardos_Load(object? sender, EventArgs e)
        {
            lstOrigen.DataSource = _listaOrigen;
            lstOrigen.SelectionMode = SelectionMode.MultiExtended;

            lstDestino.DataSource = _listaDestino;
            lstDestino.SelectionMode = SelectionMode.MultiExtended;

            CargarCombos();
            EvaluarBotonGuardar();
        }

        private void FormatearLista(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ResguardoReportModel r)
            {
                e.Value = $"[{r.CodigoInventario}] - {r.EquipoMarca} {r.EquipoModelo}";
            }
        }

        private void CargarCombos()
        {
            var admins = _adminService.ObtenerAdministrativos().OrderBy(a => a.NombreCompleto).ToList();

            // Llenamos ambos combos con la misma lista de personas
            ComboBoxHelper.CargarConSeleccionDefault(cmbOrigen, admins.ToList(), "NombreCompleto", "Id", new AppEscritorioUPT.Domain.Administrativo { Id = 0, NombreCompleto = "Selecciona Origen..." });
            ComboBoxHelper.CargarConSeleccionDefault(cmbDestino, admins.ToList(), "NombreCompleto", "Id", new AppEscritorioUPT.Domain.Administrativo { Id = 0, NombreCompleto = "Selecciona Destino..." });

            // Buscador Inteligente
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDown;
            cmbOrigen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbOrigen.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbDestino.DropDownStyle = ComboBoxStyle.DropDown;
            cmbDestino.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDestino.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // ==========================================
        // CARGA DE LISTAS
        // ==========================================
        private void CmbOrigen_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (EvitarDuplicidad()) return;
            CargarLista(cmbOrigen, _listaOrigen);
        }

        private void CmbDestino_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (EvitarDuplicidad()) return;
            CargarLista(cmbDestino, _listaDestino);
        }

        private bool EvitarDuplicidad()
        {
            // Evitamos que el usuario seleccione a la misma persona en ambos lados
            if (cmbOrigen.SelectedValue is int idO && cmbDestino.SelectedValue is int idD && idO > 0 && idO == idD)
            {
                MessageBox.Show("No puedes seleccionar al mismo administrativo en ambos lados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDestino.SelectedIndex = 0;
                return true;
            }
            return false;
        }

        private void CargarLista(ComboBox combo, BindingList<ResguardoReportModel> lista)
        {
            lista.Clear();
            if (combo.SelectedValue is int id && id > 0)
            {
                // NOTA: Usamos el método de reportes porque trae los nombres de las computadoras listos para mostrarse
                var resguardos = _resguardoService.ObtenerModelosReportePorAdministrativo(id);
                foreach (var r in resguardos)
                {
                    // Guardamos el AdministrativoId original en el modelo (muy importante para comparar después)
                    r.AdministrativoNombre = id.ToString(); // Usamos este campo de texto temporalmente para guardar el ID original
                    lista.Add(r);
                }
            }
            EvaluarBotonGuardar();
        }

        // ==========================================
        // MOVIMIENTO ENTRE LISTAS
        // ==========================================
        private void BtnPasarDerecha_Click(object? sender, EventArgs e) => MoverElementos(lstOrigen, _listaOrigen, _listaDestino);
        private void BtnPasarIzquierda_Click(object? sender, EventArgs e) => MoverElementos(lstDestino, _listaDestino, _listaOrigen);
        private void BtnPasarTodosDerecha_Click(object? sender, EventArgs e) => MoverTodos(_listaOrigen, _listaDestino);
        private void BtnPasarTodosIzquierda_Click(object? sender, EventArgs e) => MoverTodos(_listaDestino, _listaOrigen);

        private void MoverElementos(ListBox origenUI, BindingList<ResguardoReportModel> origenDatos, BindingList<ResguardoReportModel> destinoDatos)
        {
            var seleccionados = origenUI.SelectedItems.Cast<ResguardoReportModel>().ToList();
            foreach (var item in seleccionados)
            {
                origenDatos.Remove(item);
                destinoDatos.Add(item);
            }
            EvaluarBotonGuardar();
        }

        private void MoverTodos(BindingList<ResguardoReportModel> origenDatos, BindingList<ResguardoReportModel> destinoDatos)
        {
            var todos = origenDatos.ToList();
            foreach (var item in todos)
            {
                origenDatos.Remove(item);
                destinoDatos.Add(item);
            }
            EvaluarBotonGuardar();
        }

        // ==========================================
        // GUARDAR TRANSFERENCIAS
        // ==========================================
        private void EvaluarBotonGuardar()
        {
            btnGuardar.Enabled = (cmbOrigen.SelectedValue is int idO && idO > 0) &&
                                 (cmbDestino.SelectedValue is int idD && idD > 0);
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            int idOrigen = (int)cmbOrigen.SelectedValue!;
            int idDestino = (int)cmbDestino.SelectedValue!;
            DateTime fecha = dtpFechaTransferencia.Value;

            // 1. Detectar cuáles cruzaron de Origen a Destino
            // Buscamos en la lista DERECHA, los que originalmente decían ser de la IZQUIERDA
            var movidosADestino = _listaDestino
                .Where(r => r.AdministrativoNombre == idOrigen.ToString())
                .Select(r => r.Id).ToList();

            // 2. Detectar cuáles cruzaron de Destino a Origen (por si hubo intercambio mutuo)
            var movidosAOrigen = _listaOrigen
                .Where(r => r.AdministrativoNombre == idDestino.ToString())
                .Select(r => r.Id).ToList();

            if (!movidosADestino.Any() && !movidosAOrigen.Any())
            {
                MessageBox.Show("No se detectó ningún equipo movido para transferir.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // Transferimos hacia la derecha
                if (movidosADestino.Any())
                    _resguardoService.TransferirResguardosMasivo(movidosADestino, idDestino, fecha);

                // Transferimos hacia la izquierda (si es que hubo)
                if (movidosAOrigen.Any())
                    _resguardoService.TransferirResguardosMasivo(movidosAOrigen, idOrigen, fecha);

                MessageBox.Show($"Transferencia completada. Se reasignaron {movidosADestino.Count + movidosAOrigen.Count} equipos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar las listas para ver los cambios finales
                CargarLista(cmbOrigen, _listaOrigen);
                CargarLista(cmbDestino, _listaDestino);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
