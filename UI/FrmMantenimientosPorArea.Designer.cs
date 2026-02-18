namespace AppEscritorioUPT.UI
{
    partial class FrmMantenimientosPorArea
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
            btnGenerar = new Button();
            dtpFecha = new DateTimePicker();
            label2 = new Label();
            cmbTipoEquipo = new ComboBox();
            label1 = new Label();
            cmbTipoMantenimiento = new ComboBox();
            lblTipoMantenimiento = new Label();
            cmbArea = new ComboBox();
            lblArea = new Label();
            SuspendLayout();
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(32, 348);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(162, 35);
            btnGenerar.TabIndex = 13;
            btnGenerar.Text = "Asignar Checklist";
            btnGenerar.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(32, 277);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(162, 23);
            dtpFecha.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 259);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 11;
            label2.Text = "Fecha a Realizar";
            // 
            // cmbTipoEquipo
            // 
            cmbTipoEquipo.FormattingEnabled = true;
            cmbTipoEquipo.Location = new Point(32, 204);
            cmbTipoEquipo.Name = "cmbTipoEquipo";
            cmbTipoEquipo.Size = new Size(162, 23);
            cmbTipoEquipo.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 186);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 9;
            label1.Text = "Tipo de Equipo";
            // 
            // cmbTipoMantenimiento
            // 
            cmbTipoMantenimiento.FormattingEnabled = true;
            cmbTipoMantenimiento.Location = new Point(32, 135);
            cmbTipoMantenimiento.Name = "cmbTipoMantenimiento";
            cmbTipoMantenimiento.Size = new Size(162, 23);
            cmbTipoMantenimiento.TabIndex = 8;
            // 
            // lblTipoMantenimiento
            // 
            lblTipoMantenimiento.AutoSize = true;
            lblTipoMantenimiento.Location = new Point(32, 117);
            lblTipoMantenimiento.Name = "lblTipoMantenimiento";
            lblTipoMantenimiento.Size = new Size(131, 15);
            lblTipoMantenimiento.TabIndex = 7;
            lblTipoMantenimiento.Text = "Tipo de Mantenimiento";
            // 
            // cmbArea
            // 
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(32, 62);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(162, 23);
            cmbArea.TabIndex = 15;
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Location = new Point(32, 44);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(31, 15);
            lblArea.TabIndex = 14;
            lblArea.Text = "Área";
            // 
            // FrmMantenimientosPorArea
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 450);
            Controls.Add(cmbArea);
            Controls.Add(lblArea);
            Controls.Add(btnGenerar);
            Controls.Add(dtpFecha);
            Controls.Add(label2);
            Controls.Add(cmbTipoEquipo);
            Controls.Add(label1);
            Controls.Add(cmbTipoMantenimiento);
            Controls.Add(lblTipoMantenimiento);
            Name = "FrmMantenimientosPorArea";
            Text = "FrmMantenimientosPorArea";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenerar;
        private DateTimePicker dtpFecha;
        private Label label2;
        private ComboBox cmbTipoEquipo;
        private Label label1;
        private ComboBox cmbTipoMantenimiento;
        private Label lblTipoMantenimiento;
        private ComboBox cmbArea;
        private Label lblArea;
    }
}