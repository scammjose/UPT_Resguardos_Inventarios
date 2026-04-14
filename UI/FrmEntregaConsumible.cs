using AppEscritorioUPT.Domain;
using AppEscritorioUPT.Helpers;
using AppEscritorioUPT.Services;
using System.Data;


namespace AppEscritorioUPT.UI
{
    public partial class FrmEntregaConsumible : Form
    {
        private readonly EntregaConsumibleService _entregaService;
        private readonly EquipoService _equipoService;
        private readonly TipoEquipoService _tipoService;
        private readonly EquipoConsumibleService _compatibilidadService;
        
        // ¡Descomentamos los servicios de personal!
        private readonly AdministrativoService _adminService;
        private readonly ResponsableSistemasService _responsableService;

        public FrmEntregaConsumible()
        {
            InitializeComponent();

            _entregaService = new EntregaConsumibleService();
            _equipoService = new EquipoService();
            _tipoService = new TipoEquipoService();
            _compatibilidadService = new EquipoConsumibleService();
            
            // ¡Inicializamos los servicios!
            _adminService = new AdministrativoService();
            _responsableService = new ResponsableSistemasService();

            this.Load += FrmEntregaConsumible_Load;
            cmbEquipos.SelectedIndexChanged += CmbEquipos_SelectedIndexChanged;
            btnGuardar.Click += BtnGuardar_Click;

            UIConfigHelper.ConfigurarControles(this);
            ThemeHelper.AplicarTema(this);
        }

        private void FrmEntregaConsumible_Load(object? sender, EventArgs e)
        {
            CargarImpresoras();
            
            // Ahora sí, estos métodos ya existen abajo
            CargarAdministrativos();
            CargarResponsables();

            nudCantidad.Value = 1; 
            cmbConsumibles.Enabled = false; 
        }

        // ===== CARGA DE COMBOS (CATÁLOGOS) =====

        private void CargarImpresoras()
        {
            var idsImpresoras = _tipoService.ObtenerTipos()
                .Where(t => t.Nombre.ToLower().Contains("impresora") || t.Nombre.ToLower().Contains("multifuncional"))
                .Select(t => t.Id).ToList();

            var impresoras = _equipoService.ObtenerEquipos()
                .Where(e => idsImpresoras.Contains(e.TipoEquipoId))
                .Select(e => new { Id = e.Id, Display = $"S/N: {e.NumeroSerie} - {e.Marca} {e.Modelo}" })
                .ToList();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbEquipos, impresoras, "Display", "Id",
                new { Id = 0, Display = "Seleccione una Impresora..." });
        }

        // ¡MÉTODO NUEVO 1 PARA QUITAR EL ERROR!
        private void CargarAdministrativos()
        {
            var administrativos = _adminService.ObtenerAdministrativos()
                .Select(a => new { Id = a.Id, Display = a.NombreCompleto })
                .ToList();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbAdministrativo, administrativos, "Display", "Id",
                new { Id = 0, Display = "Seleccione el Área/Persona que recibe..." });
        }

        // ¡MÉTODO NUEVO 2 PARA QUITAR EL ERROR!
        private void CargarResponsables()
        {
            // Nota: Si tu modelo ResponsableSistemas no tiene "NombreCompleto" directo, 
            // ajusta "r.Administrativo.NombreCompleto" según como lo tengas en tu código.
            var responsables = _responsableService.ObtenerResponsables()
                .Select(r => new { Id = r.Id, Display = r.AdministrativoNombre ?? "Técnico" })
                .ToList();

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbResponsable, responsables, "Display", "Id",
                new { Id = 0, Display = "Seleccione el Técnico de Sistemas..." });
        }

        // ===== LA CASCADA: IMPRESORA -> TÓNER =====

        private void CmbEquipos_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbEquipos.SelectedValue is not int equipoId || equipoId <= 0)
            {
                cmbConsumibles.DataSource = null;
                cmbConsumibles.Enabled = false;
                return;
            }

            var consumiblesCompatibles = _compatibilidadService.ObtenerConsumiblesCompatibles(equipoId)
                .Select(c => new
                {
                    Id = c.Id,
                    Display = $"{c.Modelo} ({c.Color}) - Disp: {c.StockActual} pzas"
                }).ToList();

            if (consumiblesCompatibles.Count == 0)
            {
                MessageBox.Show("Esta impresora no tiene consumibles asignados en el sistema. Vaya a la pantalla de Compatibilidad primero.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbConsumibles.DataSource = null;
                cmbConsumibles.Enabled = false;
                return;
            }

            ComboBoxHelper.CargarConSeleccionDefault(
                cmbConsumibles, consumiblesCompatibles, "Display", "Id",
                new { Id = 0, Display = "Seleccione Tóner/Tinta..." });

            cmbConsumibles.Enabled = true; 
        }

        // ===== GUARDAR Y DESCONTAR STOCK =====

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            // Validamos que hayan elegido todo
            if (cmbEquipos.SelectedIndex <= 0 || cmbConsumibles.SelectedIndex <= 0 || 
                cmbAdministrativo.SelectedIndex <= 0 || cmbResponsable.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar la impresora, el tóner, y el personal involucrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nuevaEntrega = new EntregaConsumible
                {
                    EquipoId = Convert.ToInt32(cmbEquipos.SelectedValue),
                    ConsumibleId = Convert.ToInt32(cmbConsumibles.SelectedValue),

                    // ¡AQUÍ ESTÁ LA SOLUCIÓN A TUS DOS ADVERTENCIAS! Usamos Convert.ToInt32
                    AdministrativoId = Convert.ToInt32(cmbAdministrativo.SelectedValue),
                    ResponsableSistemasId = Convert.ToInt32(cmbResponsable.SelectedValue),

                    Cantidad = (int)nudCantidad.Value
                };

                _entregaService.RegistrarEntrega(nuevaEntrega);

                MessageBox.Show("Entrega registrada con éxito. El stock ha sido descontado del almacén.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en entrega", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            cmbEquipos.SelectedIndex = 0;
            cmbConsumibles.DataSource = null;
            cmbConsumibles.Enabled = false;
            nudCantidad.Value = 1;
            
            // Regresamos los combos de personal a su posición default
            if (cmbAdministrativo.Items.Count > 0) cmbAdministrativo.SelectedIndex = 0;
            if (cmbResponsable.Items.Count > 0) cmbResponsable.SelectedIndex = 0;
        }
    }
}
