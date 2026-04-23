namespace AppEscritorioUPT.UI
{
    partial class FrmResguardosColectivos
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
            cmbLotes = new ComboBox();
            label1 = new Label();
            dgvResguardosLote = new DataGridView();
            btnDescargarLote = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResguardosLote).BeginInit();
            SuspendLayout();
            // 
            // cmbLotes
            // 
            cmbLotes.FormattingEnabled = true;
            cmbLotes.Location = new Point(23, 47);
            cmbLotes.Name = "cmbLotes";
            cmbLotes.Size = new Size(473, 23);
            cmbLotes.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 29);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 1;
            label1.Text = "Resguardos Colectivos";
            // 
            // dgvResguardosLote
            // 
            dgvResguardosLote.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResguardosLote.Location = new Point(23, 102);
            dgvResguardosLote.Name = "dgvResguardosLote";
            dgvResguardosLote.Size = new Size(754, 263);
            dgvResguardosLote.TabIndex = 2;
            // 
            // btnDescargarLote
            // 
            btnDescargarLote.Location = new Point(23, 387);
            btnDescargarLote.Name = "btnDescargarLote";
            btnDescargarLote.Size = new Size(110, 51);
            btnDescargarLote.TabIndex = 3;
            btnDescargarLote.Text = "Generar PDF";
            btnDescargarLote.UseVisualStyleBackColor = true;
            // 
            // FrmResguardosColectivos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDescargarLote);
            Controls.Add(dgvResguardosLote);
            Controls.Add(label1);
            Controls.Add(cmbLotes);
            Name = "FrmResguardosColectivos";
            Text = "FrmResguardosColectivos";
            ((System.ComponentModel.ISupportInitialize)dgvResguardosLote).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbLotes;
        private Label label1;
        private DataGridView dgvResguardosLote;
        private Button btnDescargarLote;
    }
}