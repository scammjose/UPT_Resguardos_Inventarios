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
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 46);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(280, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblUbicacion
            // 
            lblUbicacion.AutoSize = true;
            lblUbicacion.Location = new Point(12, 91);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(60, 15);
            lblUbicacion.TabIndex = 2;
            lblUbicacion.Text = "Ubicación";
            // 
            // cmbUbicacion
            // 
            cmbUbicacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUbicacion.FormattingEnabled = true;
            cmbUbicacion.Location = new Point(12, 109);
            cmbUbicacion.Name = "cmbUbicacion";
            cmbUbicacion.Size = new Size(280, 23);
            cmbUbicacion.TabIndex = 3;
            // 
            // nudCantidadEquipos
            // 
            nudCantidadEquipos.Location = new Point(12, 173);
            nudCantidadEquipos.Name = "nudCantidadEquipos";
            nudCantidadEquipos.Size = new Size(280, 23);
            nudCantidadEquipos.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 155);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 5;
            label2.Text = "Cantidad de Equipos";
            // 
            // lblResponsableSistemas
            // 
            lblResponsableSistemas.AutoSize = true;
            lblResponsableSistemas.Location = new Point(12, 220);
            lblResponsableSistemas.Name = "lblResponsableSistemas";
            lblResponsableSistemas.Size = new Size(138, 15);
            lblResponsableSistemas.TabIndex = 6;
            lblResponsableSistemas.Text = "Responsable de Sistemas";
            // 
            // cmbResponsableSistemas
            // 
            cmbResponsableSistemas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbResponsableSistemas.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbResponsableSistemas.FormattingEnabled = true;
            cmbResponsableSistemas.Location = new Point(12, 238);
            cmbResponsableSistemas.Name = "cmbResponsableSistemas";
            cmbResponsableSistemas.Size = new Size(280, 23);
            cmbResponsableSistemas.TabIndex = 7;
            // 
            // cmbAreaResponsable
            // 
            cmbAreaResponsable.FormattingEnabled = true;
            cmbAreaResponsable.Location = new Point(12, 302);
            cmbAreaResponsable.Name = "cmbAreaResponsable";
            cmbAreaResponsable.Size = new Size(280, 23);
            cmbAreaResponsable.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 284);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 8;
            label3.Text = "Área Responsable";
            // 
            // dgvLaboratorios
            // 
            dgvLaboratorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLaboratorios.Location = new Point(329, 46);
            dgvLaboratorios.Name = "dgvLaboratorios";
            dgvLaboratorios.Size = new Size(584, 279);
            dgvLaboratorios.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 347);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(280, 49);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(838, 347);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmLaboratorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 408);
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