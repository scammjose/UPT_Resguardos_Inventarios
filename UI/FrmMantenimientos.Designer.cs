namespace AppEscritorioUPT.UI
{
    partial class FrmMantenimientos
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
            lblTipoMantenimiento = new Label();
            cmbTipoMantenimiento = new ComboBox();
            label1 = new Label();
            cmbTipoEquipo = new ComboBox();
            label2 = new Label();
            dtpFecha = new DateTimePicker();
            btnGenerar = new Button();
            SuspendLayout();
            // 
            // lblTipoMantenimiento
            // 
            lblTipoMantenimiento.AutoSize = true;
            lblTipoMantenimiento.Location = new Point(23, 30);
            lblTipoMantenimiento.Name = "lblTipoMantenimiento";
            lblTipoMantenimiento.Size = new Size(131, 15);
            lblTipoMantenimiento.TabIndex = 0;
            lblTipoMantenimiento.Text = "Tipo de Mantenimiento";
            // 
            // cmbTipoMantenimiento
            // 
            cmbTipoMantenimiento.FormattingEnabled = true;
            cmbTipoMantenimiento.Location = new Point(23, 48);
            cmbTipoMantenimiento.Name = "cmbTipoMantenimiento";
            cmbTipoMantenimiento.Size = new Size(162, 23);
            cmbTipoMantenimiento.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 99);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 2;
            label1.Text = "Tipo de Equipo";
            // 
            // cmbTipoEquipo
            // 
            cmbTipoEquipo.FormattingEnabled = true;
            cmbTipoEquipo.Location = new Point(23, 117);
            cmbTipoEquipo.Name = "cmbTipoEquipo";
            cmbTipoEquipo.Size = new Size(162, 23);
            cmbTipoEquipo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 172);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 4;
            label2.Text = "Fecha a Realizar";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(23, 190);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(162, 23);
            dtpFecha.TabIndex = 5;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(23, 261);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(162, 35);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "Asignar Checklist";
            btnGenerar.UseVisualStyleBackColor = true;
            // 
            // FrmMantenimientos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(249, 335);
            Controls.Add(btnGenerar);
            Controls.Add(dtpFecha);
            Controls.Add(label2);
            Controls.Add(cmbTipoEquipo);
            Controls.Add(label1);
            Controls.Add(cmbTipoMantenimiento);
            Controls.Add(lblTipoMantenimiento);
            Name = "FrmMantenimientos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmMantenimientos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipoMantenimiento;
        private ComboBox cmbTipoMantenimiento;
        private Label label1;
        private ComboBox cmbTipoEquipo;
        private Label label2;
        private DateTimePicker dtpFecha;
        private Button btnGenerar;
    }
}