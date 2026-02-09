using AppEscritorioUPT.UI;

namespace AppEscritorioUPT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
