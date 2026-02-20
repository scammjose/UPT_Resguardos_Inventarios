namespace AppEscritorioUPT.UI
{
    partial class FrmMantenimientoLaboratorios
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
            cmbLaboratorio = new ComboBox();
            cmbTipoMantenimiento = new ComboBox();
            label2 = new Label();
            dtpFecha = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            txtObservaciones = new TextBox();
            btnGuardar = new Button();
            dgvMantenimientos = new DataGridView();
            btnImprimir = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "Laboratorio";
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(12, 50);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(291, 23);
            cmbLaboratorio.TabIndex = 1;
            // 
            // cmbTipoMantenimiento
            // 
            cmbTipoMantenimiento.FormattingEnabled = true;
            cmbTipoMantenimiento.Location = new Point(12, 109);
            cmbTipoMantenimiento.Name = "cmbTipoMantenimiento";
            cmbTipoMantenimiento.Size = new Size(291, 23);
            cmbTipoMantenimiento.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 91);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de Mantenimiento";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(12, 172);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(291, 23);
            dtpFecha.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 154);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "Fecha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 225);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 6;
            label4.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(12, 243);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(291, 131);
            txtObservaciones.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 396);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(291, 42);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dgvMantenimientos
            // 
            dgvMantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMantenimientos.Location = new Point(335, 50);
            dgvMantenimientos.Name = "dgvMantenimientos";
            dgvMantenimientos.Size = new Size(453, 324);
            dgvMantenimientos.TabIndex = 9;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(335, 396);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(112, 23);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(676, 396);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 23);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmMantenimientoLaboratorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnImprimir);
            Controls.Add(dgvMantenimientos);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservaciones);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dtpFecha);
            Controls.Add(cmbTipoMantenimiento);
            Controls.Add(label2);
            Controls.Add(cmbLaboratorio);
            Controls.Add(label1);
            Name = "FrmMantenimientoLaboratorios";
            Text = "FrmMantenimientoLaboratorios";
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbLaboratorio;
        private ComboBox cmbTipoMantenimiento;
        private Label label2;
        private DateTimePicker dtpFecha;
        private Label label3;
        private Label label4;
        private TextBox txtObservaciones;
        private Button btnGuardar;
        private DataGridView dgvMantenimientos;
        private Button btnImprimir;
        private Button btnEliminar;
    }
}