namespace AppEscritorioUPT.UI
{
    partial class FrmResguardosPorPersona
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
            dgvResguardosPersona = new DataGridView();
            btnDescargarLote = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResguardosPersona).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 33);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Administrativo";
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(30, 51);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(508, 23);
            cmbAdministrativo.TabIndex = 1;
            // 
            // dgvResguardosPersona
            // 
            dgvResguardosPersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResguardosPersona.Location = new Point(30, 106);
            dgvResguardosPersona.Name = "dgvResguardosPersona";
            dgvResguardosPersona.Size = new Size(743, 261);
            dgvResguardosPersona.TabIndex = 2;
            // 
            // btnDescargarLote
            // 
            btnDescargarLote.Location = new Point(605, 393);
            btnDescargarLote.Name = "btnDescargarLote";
            btnDescargarLote.Size = new Size(168, 35);
            btnDescargarLote.TabIndex = 3;
            btnDescargarLote.Text = "Generar Resguardo por Lote";
            btnDescargarLote.UseVisualStyleBackColor = true;
            // 
            // FrmResguardosPorPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDescargarLote);
            Controls.Add(dgvResguardosPersona);
            Controls.Add(cmbAdministrativo);
            Controls.Add(label1);
            Name = "FrmResguardosPorPersona";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmResguardosPorPersona";
            ((System.ComponentModel.ISupportInitialize)dgvResguardosPersona).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbAdministrativo;
        private DataGridView dgvResguardosPersona;
        private Button btnDescargarLote;
    }
}