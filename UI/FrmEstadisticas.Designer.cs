namespace AppEscritorioUPT.UI
{
    partial class FrmEstadisticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTituloAdmin = new Label();
            lblTituloEquipos = new Label();
            lblTituloResguardos = new Label();
            dgvEquiposPorTipo = new DataGridView();
            dgvEquiposPorArea = new DataGridView();
            dgvAdministrativosPorArea = new DataGridView();
            panel1 = new Panel();
            btnActualizar = new Button();
            lblValTotalResguardos = new Label();
            lblValTotalEquipos = new Label();
            lblValTotalAdministrativos = new Label();
            pnlContenedor = new Panel();
            grpPersonal = new GroupBox();
            grpEquiposArea = new GroupBox();
            grpEquiposTipo = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvEquiposPorTipo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquiposPorArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdministrativosPorArea).BeginInit();
            panel1.SuspendLayout();
            pnlContenedor.SuspendLayout();
            grpPersonal.SuspendLayout();
            grpEquiposArea.SuspendLayout();
            grpEquiposTipo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTituloAdmin
            // 
            lblTituloAdmin.AutoSize = true;
            lblTituloAdmin.Location = new Point(13, 10);
            lblTituloAdmin.Name = "lblTituloAdmin";
            lblTituloAdmin.Size = new Size(173, 20);
            lblTituloAdmin.TabIndex = 0;
            lblTituloAdmin.Text = "Total de Administrativos:";
            // 
            // lblTituloEquipos
            // 
            lblTituloEquipos.AutoSize = true;
            lblTituloEquipos.Location = new Point(13, 47);
            lblTituloEquipos.Name = "lblTituloEquipos";
            lblTituloEquipos.Size = new Size(120, 20);
            lblTituloEquipos.TabIndex = 1;
            lblTituloEquipos.Text = "Total de Equipos";
            // 
            // lblTituloResguardos
            // 
            lblTituloResguardos.AutoSize = true;
            lblTituloResguardos.Location = new Point(13, 88);
            lblTituloResguardos.Name = "lblTituloResguardos";
            lblTituloResguardos.Size = new Size(144, 20);
            lblTituloResguardos.TabIndex = 2;
            lblTituloResguardos.Text = "Total de Resguardos";
            // 
            // dgvEquiposPorTipo
            // 
            dgvEquiposPorTipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquiposPorTipo.Dock = DockStyle.Fill;
            dgvEquiposPorTipo.Location = new Point(3, 23);
            dgvEquiposPorTipo.Name = "dgvEquiposPorTipo";
            dgvEquiposPorTipo.RowHeadersWidth = 51;
            dgvEquiposPorTipo.Size = new Size(803, 274);
            dgvEquiposPorTipo.TabIndex = 3;
            // 
            // dgvEquiposPorArea
            // 
            dgvEquiposPorArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquiposPorArea.Dock = DockStyle.Fill;
            dgvEquiposPorArea.Location = new Point(3, 23);
            dgvEquiposPorArea.Name = "dgvEquiposPorArea";
            dgvEquiposPorArea.RowHeadersWidth = 51;
            dgvEquiposPorArea.Size = new Size(803, 274);
            dgvEquiposPorArea.TabIndex = 4;
            // 
            // dgvAdministrativosPorArea
            // 
            dgvAdministrativosPorArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdministrativosPorArea.Dock = DockStyle.Fill;
            dgvAdministrativosPorArea.Location = new Point(3, 23);
            dgvAdministrativosPorArea.Name = "dgvAdministrativosPorArea";
            dgvAdministrativosPorArea.RowHeadersWidth = 51;
            dgvAdministrativosPorArea.Size = new Size(803, 274);
            dgvAdministrativosPorArea.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnActualizar);
            panel1.Controls.Add(lblValTotalResguardos);
            panel1.Controls.Add(lblValTotalEquipos);
            panel1.Controls.Add(lblValTotalAdministrativos);
            panel1.Controls.Add(lblTituloAdmin);
            panel1.Controls.Add(lblTituloEquipos);
            panel1.Controls.Add(lblTituloResguardos);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(830, 182);
            panel1.TabIndex = 7;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(13, 126);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(165, 39);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Refrescas Cambios";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // lblValTotalResguardos
            // 
            lblValTotalResguardos.AutoSize = true;
            lblValTotalResguardos.Location = new Point(204, 88);
            lblValTotalResguardos.Name = "lblValTotalResguardos";
            lblValTotalResguardos.Size = new Size(17, 20);
            lblValTotalResguardos.TabIndex = 3;
            lblValTotalResguardos.Text = "0";
            // 
            // lblValTotalEquipos
            // 
            lblValTotalEquipos.AutoSize = true;
            lblValTotalEquipos.Location = new Point(204, 47);
            lblValTotalEquipos.Name = "lblValTotalEquipos";
            lblValTotalEquipos.Size = new Size(17, 20);
            lblValTotalEquipos.TabIndex = 2;
            lblValTotalEquipos.Text = "0";
            // 
            // lblValTotalAdministrativos
            // 
            lblValTotalAdministrativos.AutoSize = true;
            lblValTotalAdministrativos.Location = new Point(204, 10);
            lblValTotalAdministrativos.Name = "lblValTotalAdministrativos";
            lblValTotalAdministrativos.Size = new Size(17, 20);
            lblValTotalAdministrativos.TabIndex = 1;
            lblValTotalAdministrativos.Text = "0";
            // 
            // pnlContenedor
            // 
            pnlContenedor.AutoScroll = true;
            pnlContenedor.Controls.Add(grpPersonal);
            pnlContenedor.Controls.Add(grpEquiposArea);
            pnlContenedor.Controls.Add(grpEquiposTipo);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(0, 182);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(830, 415);
            pnlContenedor.TabIndex = 8;
            // 
            // grpPersonal
            // 
            grpPersonal.Controls.Add(dgvAdministrativosPorArea);
            grpPersonal.Dock = DockStyle.Top;
            grpPersonal.Location = new Point(0, 600);
            grpPersonal.Name = "grpPersonal";
            grpPersonal.Size = new Size(809, 300);
            grpPersonal.TabIndex = 2;
            grpPersonal.TabStop = false;
            grpPersonal.Text = "Personal por Área";
            // 
            // grpEquiposArea
            // 
            grpEquiposArea.Controls.Add(dgvEquiposPorArea);
            grpEquiposArea.Dock = DockStyle.Top;
            grpEquiposArea.Location = new Point(0, 300);
            grpEquiposArea.Name = "grpEquiposArea";
            grpEquiposArea.Size = new Size(809, 300);
            grpEquiposArea.TabIndex = 1;
            grpEquiposArea.TabStop = false;
            grpEquiposArea.Text = "Distribución por Área";
            // 
            // grpEquiposTipo
            // 
            grpEquiposTipo.Controls.Add(dgvEquiposPorTipo);
            grpEquiposTipo.Dock = DockStyle.Top;
            grpEquiposTipo.Location = new Point(0, 0);
            grpEquiposTipo.Name = "grpEquiposTipo";
            grpEquiposTipo.Size = new Size(809, 300);
            grpEquiposTipo.TabIndex = 0;
            grpEquiposTipo.TabStop = false;
            grpEquiposTipo.Text = "Desglose de Equipos por Tipo";
            // 
            // FrmEstadisticas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 597);
            Controls.Add(pnlContenedor);
            Controls.Add(panel1);
            Name = "FrmEstadisticas";
            Text = "FrmEstadisticas";
            ((System.ComponentModel.ISupportInitialize)dgvEquiposPorTipo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquiposPorArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdministrativosPorArea).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlContenedor.ResumeLayout(false);
            grpPersonal.ResumeLayout(false);
            grpEquiposArea.ResumeLayout(false);
            grpEquiposTipo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTituloAdmin;
        private Label lblTituloEquipos;
        private Label lblTituloResguardos;
        private DataGridView dgvEquiposPorTipo;
        private DataGridView dgvEquiposPorArea;
        private DataGridView dgvAdministrativosPorArea;
        private Panel panel1;
        private Label lblValTotalResguardos;
        private Label lblValTotalEquipos;
        private Label lblValTotalAdministrativos;
        private Panel pnlContenedor;
        private GroupBox grpEquiposArea;
        private GroupBox grpPersonal;
        private GroupBox grpEquiposTipo;
        private Button btnActualizar;
    }
}