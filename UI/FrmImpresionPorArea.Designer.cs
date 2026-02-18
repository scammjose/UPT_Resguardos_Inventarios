namespace AppEscritorioUPT.UI
{
    partial class FrmImpresionPorArea
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
            btnImprimir = new Button();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            cmbAreas = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(27, 208);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(89, 41);
            btnImprimir.TabIndex = 9;
            btnImprimir.Text = "Imprimir Checklist";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(27, 152);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(248, 23);
            dtpFecha.TabIndex = 8;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(27, 123);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(139, 15);
            lblFecha.TabIndex = 7;
            lblFecha.Text = "Fecha de Mantenimiento";
            // 
            // cmbAreas
            // 
            cmbAreas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAreas.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAreas.FormattingEnabled = true;
            cmbAreas.Location = new Point(27, 71);
            cmbAreas.Name = "cmbAreas";
            cmbAreas.Size = new Size(248, 23);
            cmbAreas.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 42);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 5;
            label1.Text = "Seleccionar Área";
            // 
            // FrmImpresionPorArea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 304);
            Controls.Add(btnImprimir);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(cmbAreas);
            Controls.Add(label1);
            Name = "FrmImpresionPorArea";
            Text = "FrmImpresionPorArea";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImprimir;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private ComboBox cmbAreas;
        private Label label1;
    }
}