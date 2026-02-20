namespace AppEscritorioUPT.UI
{
    partial class FrmEdificios
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
            txtNombre = new TextBox();
            txtUbicacion = new TextBox();
            label2 = new Label();
            nudCantidadAulas = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            cmbResponsable = new ComboBox();
            dgvEdificios = new DataGridView();
            btnGuardar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidadAulas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEdificios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 53);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(203, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(12, 117);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(203, 23);
            txtUbicacion.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 99);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Ubicación";
            // 
            // nudCantidadAulas
            // 
            nudCantidadAulas.Location = new Point(12, 181);
            nudCantidadAulas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidadAulas.Name = "nudCantidadAulas";
            nudCantidadAulas.Size = new Size(120, 23);
            nudCantidadAulas.TabIndex = 4;
            nudCantidadAulas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 163);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 5;
            label3.Text = "Cantidad de Aulas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 224);
            label4.Name = "label4";
            label4.Size = new Size(138, 15);
            label4.TabIndex = 6;
            label4.Text = "Responsable de Sistemas";
            // 
            // cmbResponsable
            // 
            cmbResponsable.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResponsable.FormattingEnabled = true;
            cmbResponsable.Location = new Point(12, 242);
            cmbResponsable.Name = "cmbResponsable";
            cmbResponsable.Size = new Size(203, 23);
            cmbResponsable.TabIndex = 7;
            // 
            // dgvEdificios
            // 
            dgvEdificios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEdificios.Location = new Point(304, 35);
            dgvEdificios.Name = "dgvEdificios";
            dgvEdificios.Size = new Size(484, 230);
            dgvEdificios.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 312);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(87, 32);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(304, 312);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(87, 32);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(413, 312);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(87, 32);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmEdificios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvEdificios);
            Controls.Add(cmbResponsable);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nudCantidadAulas);
            Controls.Add(txtUbicacion);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FrmEdificios";
            Text = "FrmEdificios";
            ((System.ComponentModel.ISupportInitialize)nudCantidadAulas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEdificios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private TextBox txtUbicacion;
        private Label label2;
        private NumericUpDown nudCantidadAulas;
        private Label label3;
        private Label label4;
        private ComboBox cmbResponsable;
        private DataGridView dgvEdificios;
        private Button btnGuardar;
        private Button btnActualizar;
        private Button btnEliminar;
    }
}