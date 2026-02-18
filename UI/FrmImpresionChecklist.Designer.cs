namespace AppEscritorioUPT.UI
{
    partial class FrmImpresionChecklist
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
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            btnImprimir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(148, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccionar Administrativo";
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(12, 61);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(248, 23);
            cmbAdministrativo.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(12, 113);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(139, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha de Mantenimiento";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(12, 142);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(248, 23);
            dtpFecha.TabIndex = 3;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(12, 198);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(89, 41);
            btnImprimir.TabIndex = 4;
            btnImprimir.Text = "Imprimir Checklist";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // FrmImpresionChecklist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 275);
            Controls.Add(btnImprimir);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(cmbAdministrativo);
            Controls.Add(label1);
            Name = "FrmImpresionChecklist";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmImpresionChecklist";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbAdministrativo;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Button btnImprimir;
    }
}