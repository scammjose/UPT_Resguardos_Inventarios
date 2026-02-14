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
            lblTotalAdministrativos = new Label();
            lblTotalEquipos = new Label();
            lblTotalResguardos = new Label();
            dgvEquiposPorTipo = new DataGridView();
            dgvEquiposPorArea = new DataGridView();
            dgvAdministrativosPorArea = new DataGridView();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEquiposPorTipo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquiposPorArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdministrativosPorArea).BeginInit();
            SuspendLayout();
            // 
            // lblTotalAdministrativos
            // 
            lblTotalAdministrativos.AutoSize = true;
            lblTotalAdministrativos.Location = new Point(12, 21);
            lblTotalAdministrativos.Name = "lblTotalAdministrativos";
            lblTotalAdministrativos.Size = new Size(170, 20);
            lblTotalAdministrativos.TabIndex = 0;
            lblTotalAdministrativos.Text = "Total de Administrativos";
            // 
            // lblTotalEquipos
            // 
            lblTotalEquipos.AutoSize = true;
            lblTotalEquipos.Location = new Point(12, 76);
            lblTotalEquipos.Name = "lblTotalEquipos";
            lblTotalEquipos.Size = new Size(120, 20);
            lblTotalEquipos.TabIndex = 1;
            lblTotalEquipos.Text = "Total de Equipos";
            // 
            // lblTotalResguardos
            // 
            lblTotalResguardos.AutoSize = true;
            lblTotalResguardos.Location = new Point(12, 135);
            lblTotalResguardos.Name = "lblTotalResguardos";
            lblTotalResguardos.Size = new Size(144, 20);
            lblTotalResguardos.TabIndex = 2;
            lblTotalResguardos.Text = "Total de Resguardos";
            // 
            // dgvEquiposPorTipo
            // 
            dgvEquiposPorTipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquiposPorTipo.Location = new Point(12, 195);
            dgvEquiposPorTipo.Name = "dgvEquiposPorTipo";
            dgvEquiposPorTipo.RowHeadersWidth = 51;
            dgvEquiposPorTipo.Size = new Size(214, 126);
            dgvEquiposPorTipo.TabIndex = 3;
            // 
            // dgvEquiposPorArea
            // 
            dgvEquiposPorArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquiposPorArea.Location = new Point(276, 195);
            dgvEquiposPorArea.Name = "dgvEquiposPorArea";
            dgvEquiposPorArea.RowHeadersWidth = 51;
            dgvEquiposPorArea.Size = new Size(214, 126);
            dgvEquiposPorArea.TabIndex = 4;
            // 
            // dgvAdministrativosPorArea
            // 
            dgvAdministrativosPorArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdministrativosPorArea.Location = new Point(537, 195);
            dgvAdministrativosPorArea.Name = "dgvAdministrativosPorArea";
            dgvAdministrativosPorArea.RowHeadersWidth = 51;
            dgvAdministrativosPorArea.Size = new Size(214, 126);
            dgvAdministrativosPorArea.TabIndex = 5;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(598, 397);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(153, 41);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Refrescar Cambios";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // FrmEstadisticas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnActualizar);
            Controls.Add(dgvAdministrativosPorArea);
            Controls.Add(dgvEquiposPorArea);
            Controls.Add(dgvEquiposPorTipo);
            Controls.Add(lblTotalResguardos);
            Controls.Add(lblTotalEquipos);
            Controls.Add(lblTotalAdministrativos);
            Name = "FrmEstadisticas";
            Text = "FrmEstadisticas";
            ((System.ComponentModel.ISupportInitialize)dgvEquiposPorTipo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquiposPorArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdministrativosPorArea).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalAdministrativos;
        private Label lblTotalEquipos;
        private Label lblTotalResguardos;
        private DataGridView dgvEquiposPorTipo;
        private DataGridView dgvEquiposPorArea;
        private DataGridView dgvAdministrativosPorArea;
        private Button btnActualizar;
    }
}