namespace AppEscritorioUPT.UI
{
    partial class FrmHistorialMantenimientos
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
            dtpFiltro = new DateTimePicker();
            dgvMantenimientos = new DataGridView();
            groupBox1 = new GroupBox();
            btnGuardarCambios = new Button();
            txtEditarObservaciones = new TextBox();
            lblObservaciones = new Label();
            dtpEditarFecha = new DateTimePicker();
            lblFechaNueva = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Filtrar por Fecha";
            // 
            // dtpFiltro
            // 
            dtpFiltro.Location = new Point(12, 50);
            dtpFiltro.Name = "dtpFiltro";
            dtpFiltro.Size = new Size(200, 23);
            dtpFiltro.TabIndex = 1;
            // 
            // dgvMantenimientos
            // 
            dgvMantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMantenimientos.Location = new Point(12, 106);
            dgvMantenimientos.Name = "dgvMantenimientos";
            dgvMantenimientos.Size = new Size(776, 205);
            dgvMantenimientos.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGuardarCambios);
            groupBox1.Controls.Add(txtEditarObservaciones);
            groupBox1.Controls.Add(lblObservaciones);
            groupBox1.Controls.Add(dtpEditarFecha);
            groupBox1.Controls.Add(lblFechaNueva);
            groupBox1.Location = new Point(12, 348);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(470, 255);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Editar Registro Seleccionado";
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Location = new Point(336, 56);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(128, 23);
            btnGuardarCambios.TabIndex = 4;
            btnGuardarCambios.Text = "Guardar Cambios";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            // 
            // txtEditarObservaciones
            // 
            txtEditarObservaciones.Location = new Point(6, 118);
            txtEditarObservaciones.Multiline = true;
            txtEditarObservaciones.Name = "txtEditarObservaciones";
            txtEditarObservaciones.Size = new Size(458, 131);
            txtEditarObservaciones.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(6, 100);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(117, 15);
            lblObservaciones.TabIndex = 2;
            lblObservaciones.Text = "Editar Observaciones";
            // 
            // dtpEditarFecha
            // 
            dtpEditarFecha.Location = new Point(6, 56);
            dtpEditarFecha.Name = "dtpEditarFecha";
            dtpEditarFecha.Size = new Size(200, 23);
            dtpEditarFecha.TabIndex = 1;
            // 
            // lblFechaNueva
            // 
            lblFechaNueva.AutoSize = true;
            lblFechaNueva.Location = new Point(6, 38);
            lblFechaNueva.Name = "lblFechaNueva";
            lblFechaNueva.Size = new Size(75, 15);
            lblFechaNueva.TabIndex = 0;
            lblFechaNueva.Text = "Nueva Fecha";
            // 
            // FrmHistorialMantenimientos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 615);
            Controls.Add(groupBox1);
            Controls.Add(dgvMantenimientos);
            Controls.Add(dtpFiltro);
            Controls.Add(label1);
            Name = "FrmHistorialMantenimientos";
            Text = "FrmHistorialMantenimientos";
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFiltro;
        private DataGridView dgvMantenimientos;
        private GroupBox groupBox1;
        private TextBox txtEditarObservaciones;
        private Label lblObservaciones;
        private DateTimePicker dtpEditarFecha;
        private Label lblFechaNueva;
        private Button btnGuardarCambios;
    }
}