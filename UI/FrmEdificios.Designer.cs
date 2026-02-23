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
            label1.Location = new Point(14, 47);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 8;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(14, 71);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(231, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(14, 156);
            txtUbicacion.Margin = new Padding(3, 4, 3, 4);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(231, 27);
            txtUbicacion.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 132);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 9;
            label2.Text = "Ubicación";
            // 
            // nudCantidadAulas
            // 
            nudCantidadAulas.Location = new Point(14, 241);
            nudCantidadAulas.Margin = new Padding(3, 4, 3, 4);
            nudCantidadAulas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidadAulas.Name = "nudCantidadAulas";
            nudCantidadAulas.Size = new Size(137, 27);
            nudCantidadAulas.TabIndex = 2;
            nudCantidadAulas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 217);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 10;
            label3.Text = "Cantidad de Aulas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 299);
            label4.Name = "label4";
            label4.Size = new Size(176, 20);
            label4.TabIndex = 11;
            label4.Text = "Responsable de Sistemas";
            // 
            // cmbResponsable
            // 
            cmbResponsable.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResponsable.FormattingEnabled = true;
            cmbResponsable.Location = new Point(14, 323);
            cmbResponsable.Margin = new Padding(3, 4, 3, 4);
            cmbResponsable.Name = "cmbResponsable";
            cmbResponsable.Size = new Size(231, 28);
            cmbResponsable.TabIndex = 3;
            // 
            // dgvEdificios
            // 
            dgvEdificios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEdificios.Location = new Point(347, 47);
            dgvEdificios.Margin = new Padding(3, 4, 3, 4);
            dgvEdificios.Name = "dgvEdificios";
            dgvEdificios.RowHeadersWidth = 51;
            dgvEdificios.Size = new Size(553, 307);
            dgvEdificios.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(14, 416);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(99, 43);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(347, 416);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(99, 43);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(472, 416);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(99, 43);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmEdificios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
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
            Margin = new Padding(3, 4, 3, 4);
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