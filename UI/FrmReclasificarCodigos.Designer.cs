namespace AppEscritorioUPT.UI
{
    partial class FrmReclasificarCodigos
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
            label1 = new Label();
            cmbAdministrativo = new ComboBox();
            dgvResguardos = new DataGridView();
            cmbArea = new ComboBox();
            label2 = new Label();
            btnRegenerar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResguardos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 37);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Administrativo";
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(22, 55);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(289, 23);
            cmbAdministrativo.TabIndex = 1;
            // 
            // dgvResguardos
            // 
            dgvResguardos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResguardos.Location = new Point(22, 106);
            dgvResguardos.Name = "dgvResguardos";
            dgvResguardos.Size = new Size(766, 208);
            dgvResguardos.TabIndex = 2;
            // 
            // cmbArea
            // 
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(22, 365);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(289, 23);
            cmbArea.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 347);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 4;
            label2.Text = "Área perteneciente";
            // 
            // btnRegenerar
            // 
            btnRegenerar.Location = new Point(342, 348);
            btnRegenerar.Name = "btnRegenerar";
            btnRegenerar.Size = new Size(170, 40);
            btnRegenerar.TabIndex = 5;
            btnRegenerar.Text = "Regenerar Código de Inventario";
            btnRegenerar.UseVisualStyleBackColor = true;
            // 
            // FrmReclasificarCodigos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegenerar);
            Controls.Add(label2);
            Controls.Add(cmbArea);
            Controls.Add(dgvResguardos);
            Controls.Add(cmbAdministrativo);
            Controls.Add(label1);
            Name = "FrmReclasificarCodigos";
            Text = "FrmReclasificarCodigos";
            ((System.ComponentModel.ISupportInitialize)dgvResguardos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbAdministrativo;
        private DataGridView dgvResguardos;
        private ComboBox cmbArea;
        private Label label2;
        private Button btnRegenerar;
    }
}