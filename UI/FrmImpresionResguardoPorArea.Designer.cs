namespace AppEscritorioUPT.UI
{
    partial class FrmImpresionResguardoPorArea
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
            cmbArea = new ComboBox();
            label1 = new Label();
            dgvResguardosArea = new DataGridView();
            btnGenerarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResguardosArea).BeginInit();
            SuspendLayout();
            // 
            // cmbArea
            // 
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(21, 52);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(378, 23);
            cmbArea.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 34);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Área";
            // 
            // dgvResguardosArea
            // 
            dgvResguardosArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResguardosArea.Location = new Point(21, 109);
            dgvResguardosArea.Name = "dgvResguardosArea";
            dgvResguardosArea.Size = new Size(767, 262);
            dgvResguardosArea.TabIndex = 2;
            // 
            // btnGenerarPdf
            // 
            btnGenerarPdf.Location = new Point(21, 394);
            btnGenerarPdf.Name = "btnGenerarPdf";
            btnGenerarPdf.Size = new Size(168, 44);
            btnGenerarPdf.TabIndex = 3;
            btnGenerarPdf.Text = "Generar PDF";
            btnGenerarPdf.UseVisualStyleBackColor = true;
            // 
            // FrmImpresionResguardoPorArea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGenerarPdf);
            Controls.Add(dgvResguardosArea);
            Controls.Add(label1);
            Controls.Add(cmbArea);
            Name = "FrmImpresionResguardoPorArea";
            Text = "FrmImpresionResguardoPorArea";
            ((System.ComponentModel.ISupportInitialize)dgvResguardosArea).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbArea;
        private Label label1;
        private DataGridView dgvResguardosArea;
        private Button btnGenerarPdf;
    }
}