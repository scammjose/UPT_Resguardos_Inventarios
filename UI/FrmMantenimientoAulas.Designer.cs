namespace AppEscritorioUPT.UI
{
    partial class FrmMantenimientoAulas
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
            cmbEdificio = new ComboBox();
            cmbTipoMantenimiento = new ComboBox();
            label2 = new Label();
            dtpFecha = new DateTimePicker();
            label3 = new Label();
            txtObservaciones = new TextBox();
            label4 = new Label();
            dgvMantenimientos = new DataGridView();
            btnGuardar = new Button();
            btnImprimir = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 35);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Edificio";
            // 
            // cmbEdificio
            // 
            cmbEdificio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdificio.FormattingEnabled = true;
            cmbEdificio.Location = new Point(23, 53);
            cmbEdificio.Name = "cmbEdificio";
            cmbEdificio.Size = new Size(221, 23);
            cmbEdificio.TabIndex = 1;
            // 
            // cmbTipoMantenimiento
            // 
            cmbTipoMantenimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoMantenimiento.FormattingEnabled = true;
            cmbTipoMantenimiento.Location = new Point(23, 122);
            cmbTipoMantenimiento.Name = "cmbTipoMantenimiento";
            cmbTipoMantenimiento.Size = new Size(221, 23);
            cmbTipoMantenimiento.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 104);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de Mantenimiento";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(23, 192);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(221, 23);
            dtpFecha.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 174);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 5;
            label3.Text = "Fecha de mantenimiento";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(23, 263);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(221, 126);
            txtObservaciones.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 245);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 7;
            label4.Text = "Observaciones";
            // 
            // dgvMantenimientos
            // 
            dgvMantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMantenimientos.Location = new Point(296, 53);
            dgvMantenimientos.Name = "dgvMantenimientos";
            dgvMantenimientos.Size = new Size(470, 162);
            dgvMantenimientos.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(23, 408);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(221, 30);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(296, 237);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 10;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(599, 237);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 11;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(691, 237);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmMantenimientoAulas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnImprimir);
            Controls.Add(btnGuardar);
            Controls.Add(dgvMantenimientos);
            Controls.Add(label4);
            Controls.Add(txtObservaciones);
            Controls.Add(label3);
            Controls.Add(dtpFecha);
            Controls.Add(cmbTipoMantenimiento);
            Controls.Add(label2);
            Controls.Add(cmbEdificio);
            Controls.Add(label1);
            Name = "FrmMantenimientoAulas";
            Text = "FrmMantenimientoAulas";
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbEdificio;
        private ComboBox cmbTipoMantenimiento;
        private Label label2;
        private DateTimePicker dtpFecha;
        private Label label3;
        private TextBox txtObservaciones;
        private Label label4;
        private DataGridView dgvMantenimientos;
        private Button btnGuardar;
        private Button btnImprimir;
        private Button btnActualizar;
        private Button btnEliminar;
    }
}