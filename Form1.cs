using AppEscritorioUPT.Helpers;
using AppEscritorioUPT.UI;

namespace AppEscritorioUPT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // 1.Aplicamos el color de fondo a la barra para asegurarnos de que toda sea Guinda
            menuStrip1.BackColor = ColorTranslator.FromHtml("#A02142");

            // 2. Le asignamos nuestro renderizador mágico para los hovers y clics
            menuStrip1.Renderer = new MenuRendererHelper();

            // 3. Le damos una tipografía más grande y limpia
            menuStrip1.Font = new Font("Arial", 10F, FontStyle.Bold);

            // 4. Agregamos un poco de margen interior para que no se vea apretada la barra
            menuStrip1.Padding = new Padding(5, 5, 5, 5);

            ThemeHelper.AplicarTema(this);
        }

        private void menuAreas_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAreas())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this); // Modal, bloquea hasta que cierres FrmAreas
            }
        }

        private void menuTipos_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmTiposEquipos())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private void menuAdministrativos_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAdministrativos())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private void menuEquipos_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmEquipos())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private void menuResponsablesSistemas_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmResponsablesSistemas())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void menuRegistrarResguardo_Click(object sender, EventArgs e)
        {
            var frm = new FrmResguardos
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frm.Show(this);
        }

        private void menuPorAdministrativo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmResguardosPorPersona())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            };
        }

        private void menuEstadisticos_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmEstadisticas())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void asignarCheckListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmMantenimientos())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void asignarCheckListPorÁreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmMantenimientosPorArea())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void historialYEdiciónDeMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmHistorialMantenimientos())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void generarCheckListPorAdministrativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmImpresionChecklist())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void generarCheckListPorÁreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmImpresionPorArea())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void menuEdificios_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmEdificios())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void menuMantenimientosAulas_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmMantenimientoAulas())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void menuTiposMantenimiento_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmTiposMantenimiento())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void menuLaboratorios_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmLaboratorios())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }

        private void menuGenerarCheckListLaboratorios_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmMantenimientoLaboratorios())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
            ;
        }
    }
}
