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
            btnGenerar.Location = new Point(37, 464);
            btnGenerar.Margin = new Padding(3, 4, 3, 4);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(185, 47);
            btnGenerar.TabIndex = 13;
            btnGenerar.Text = "Asignar Checklist";
            btnGenerar.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(37, 369);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(185, 27);
            dtpFecha.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 345);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 11;
            label2.Text = "Fecha a Realizar";
            // 
            // cmbTipoEquipo
            // 
            cmbTipoEquipo.FormattingEnabled = true;
            cmbTipoEquipo.Location = new Point(37, 272);
            cmbTipoEquipo.Margin = new Padding(3, 4, 3, 4);
            cmbTipoEquipo.Name = "cmbTipoEquipo";
            cmbTipoEquipo.Size = new Size(185, 28);
            cmbTipoEquipo.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 248);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 9;
            label1.Text = "Tipo de Equipo";
            // 
            // cmbTipoMantenimiento
            // 
            cmbTipoMantenimiento.FormattingEnabled = true;
            cmbTipoMantenimiento.Location = new Point(37, 180);
            cmbTipoMantenimiento.Margin = new Padding(3, 4, 3, 4);
            cmbTipoMantenimiento.Name = "cmbTipoMantenimiento";
            cmbTipoMantenimiento.Size = new Size(185, 28);
            cmbTipoMantenimiento.TabIndex = 8;
            // 
            // lblTipoMantenimiento
            // 
            lblTipoMantenimiento.AutoSize = true;
            lblTipoMantenimiento.Location = new Point(37, 156);
            lblTipoMantenimiento.Name = "lblTipoMantenimiento";
            lblTipoMantenimiento.Size = new Size(165, 20);
            lblTipoMantenimiento.TabIndex = 7;
            lblTipoMantenimiento.Text = "Tipo de Mantenimiento";
            // 
            // cmbArea
            // 
            cmbArea.DropDownWidth = 400;
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(37, 83);
            cmbArea.Margin = new Padding(3, 4, 3, 4);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(185, 28);
            cmbArea.TabIndex = 15;
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Location = new Point(37, 59);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(40, 20);
            lblArea.TabIndex = 14;
            lblArea.Text = "Área";
            // 
            // FrmMantenimientosPorArea
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 600);
            Controls.Add(cmbArea);
            Controls.Add(lblArea);
            Controls.Add(btnGenerar);
            Controls.Add(dtpFecha);
            Controls.Add(label2);
            Controls.Add(cmbTipoEquipo);
            Controls.Add(label1);
            Controls.Add(cmbTipoMantenimiento);
            Controls.Add(lblTipoMantenimiento);
            Margin = new Padding(3, 4, 3, 4);
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