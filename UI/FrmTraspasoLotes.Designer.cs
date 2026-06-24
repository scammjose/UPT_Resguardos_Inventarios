namespace AppEscritorioUPT.UI
{
    partial class FrmTraspasoLotes
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
            cmbLoteOrigen = new ComboBox();
            dgvEquipos = new DataGridView();
            cmbAdministrativoDestino = new ComboBox();
            cmbResponsableSistemas = new ComboBox();
            btnTransferir = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).BeginInit();
            SuspendLayout();
            // 
            // cmbLoteOrigen
            // 
            cmbLoteOrigen.FormattingEnabled = true;
            cmbLoteOrigen.Location = new Point(37, 70);
            cmbLoteOrigen.Name = "cmbLoteOrigen";
            cmbLoteOrigen.Size = new Size(552, 23);
            cmbLoteOrigen.TabIndex = 0;
            // 
            // dgvEquipos
            // 
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(37, 122);
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.Size = new Size(552, 383);
            dgvEquipos.TabIndex = 1;
            // 
            // cmbAdministrativoDestino
            // 
            cmbAdministrativoDestino.FormattingEnabled = true;
            cmbAdministrativoDestino.Location = new Point(676, 70);
            cmbAdministrativoDestino.Name = "cmbAdministrativoDestino";
            cmbAdministrativoDestino.Size = new Size(320, 23);
            cmbAdministrativoDestino.TabIndex = 2;
            // 
            // cmbResponsableSistemas
            // 
            cmbResponsableSistemas.FormattingEnabled = true;
            cmbResponsableSistemas.Location = new Point(676, 149);
            cmbResponsableSistemas.Name = "cmbResponsableSistemas";
            cmbResponsableSistemas.Size = new Size(320, 23);
            cmbResponsableSistemas.TabIndex = 3;
            // 
            // btnTransferir
            // 
            btnTransferir.Location = new Point(676, 209);
            btnTransferir.Name = "btnTransferir";
            btnTransferir.Size = new Size(311, 56);
            btnTransferir.TabIndex = 4;
            btnTransferir.Text = "Asignar Resguardo";
            btnTransferir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 41);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 5;
            label1.Text = "Resguardo (Origen)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(676, 41);
            label2.Name = "label2";
            label2.Size = new Size(136, 15);
            label2.TabIndex = 6;
            label2.Text = "Administrativo (Destino)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(676, 122);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 7;
            label3.Text = "Responsable Sistemas";
            // 
            // FrmTraspasoLotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 517);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnTransferir);
            Controls.Add(cmbResponsableSistemas);
            Controls.Add(cmbAdministrativoDestino);
            Controls.Add(dgvEquipos);
            Controls.Add(cmbLoteOrigen);
            Name = "FrmTraspasoLotes";
            Text = "FrmTraspasoLotes";
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbLoteOrigen;
        private DataGridView dgvEquipos;
        private ComboBox cmbAdministrativoDestino;
        private ComboBox cmbResponsableSistemas;
        private Button btnTransferir;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}