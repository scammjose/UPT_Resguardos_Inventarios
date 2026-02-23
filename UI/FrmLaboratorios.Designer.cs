namespace AppEscritorioUPT.UI
{
    partial class FrmLaboratorios
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
            lblUbicacion = new Label();
            cmbUbicacion = new ComboBox();
            nudCantidadEquipos = new NumericUpDown();
            label2 = new Label();
            lblResponsableSistemas = new Label();
            cmbResponsableSistemas = new ComboBox();
            cmbAreaResponsable = new ComboBox();
            label3 = new Label();
            dgvLaboratorios = new DataGridView();
            btnGuardar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidadEquipos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 37);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 8;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(14, 61);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(319, 27);
            txtNombre.TabIndex = 0;
            // 
            // lblUbicacion
            // 
            lblUbicacion.AutoSize = true;
            lblUbicacion.Location = new Point(14, 121);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(75, 20);
            lblUbicacion.TabIndex = 9;
            lblUbicacion.Text = "Ubicación";
            // 
            // cmbUbicacion
            // 
            cmbUbicacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUbicacion.FormattingEnabled = true;
            cmbUbicacion.Location = new Point(14, 145);
            cmbUbicacion.Margin = new Padding(3, 4, 3, 4);
            cmbUbicacion.Name = "cmbUbicacion";
            cmbUbicacion.Size = new Size(319, 28);
            cmbUbicacion.TabIndex = 1;
            // 
            // nudCantidadEquipos
            // 
            nudCantidadEquipos.Location = new Point(14, 231);
            nudCantidadEquipos.Margin = new Padding(3, 4, 3, 4);
            nudCantidadEquipos.Name = "nudCantidadEquipos";
            nudCantidadEquipos.Size = new Size(320, 27);
            nudCantidadEquipos.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 207);
            label2.Name = "label2";
            label2.Size = new Size(147, 20);
            label2.TabIndex = 10;
            label2.Text = "Cantidad de Equipos";
            // 
            // lblResponsableSistemas
            // 
            lblResponsableSistemas.AutoSize = true;
            lblResponsableSistemas.Location = new Point(14, 293);
            lblResponsableSistemas.Name = "lblResponsableSistemas";
            lblResponsableSistemas.Size = new Size(176, 20);
            lblResponsableSistemas.TabIndex = 11;
            lblResponsableSistemas.Text = "Responsable de Sistemas";
            // 
            // cmbResponsableSistemas
            // 
            cmbResponsableSistemas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbResponsableSistemas.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbResponsableSistemas.FormattingEnabled = true;
            cmbResponsableSistemas.Location = new Point(14, 317);
            cmbResponsableSistemas.Margin = new Padding(3, 4, 3, 4);
            cmbResponsableSistemas.Name = "cmbResponsableSistemas";
            cmbResponsableSistemas.Size = new Size(319, 28);
            cmbResponsableSistemas.TabIndex = 3;
            // 
            // cmbAreaResponsable
            // 
            cmbAreaResponsable.FormattingEnabled = true;
            cmbAreaResponsable.Location = new Point(14, 403);
            cmbAreaResponsable.Margin = new Padding(3, 4, 3, 4);
            cmbAreaResponsable.Name = "cmbAreaResponsable";
            cmbAreaResponsable.Size = new Size(319, 28);
            cmbAreaResponsable.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 379);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 12;
            label3.Text = "Área Responsable";
            // 
            // dgvLaboratorios
            // 
            dgvLaboratorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLaboratorios.Location = new Point(376, 61);
            dgvLaboratorios.Margin = new Padding(3, 4, 3, 4);
            dgvLaboratorios.Name = "dgvLaboratorios";
            dgvLaboratorios.RowHeadersWidth = 51;
            dgvLaboratorios.Size = new Size(667, 372);
            dgvLaboratorios.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(14, 463);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(320, 65);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(958, 463);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmLaboratorios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 544);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvLaboratorios);
            Controls.Add(cmbAreaResponsable);
            Controls.Add(label3);
            Controls.Add(cmbResponsableSistemas);
            Controls.Add(lblResponsableSistemas);
            Controls.Add(label2);
            Controls.Add(nudCantidadEquipos);
            Controls.Add(cmbUbicacion);
            Controls.Add(lblUbicacion);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmLaboratorios";
            Text = "FrmLaboratorios";
            ((System.ComponentModel.ISupportInitialize)nudCantidadEquipos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label lblUbicacion;
        private ComboBox cmbUbicacion;
        private NumericUpDown nudCantidadEquipos;
        private Label label2;
        private Label lblResponsableSistemas;
        private ComboBox cmbResponsableSistemas;
        private ComboBox cmbAreaResponsable;
        private Label label3;
        private DataGridView dgvLaboratorios;
        private Button btnGuardar;
        private Button btnEliminar;
    }
}