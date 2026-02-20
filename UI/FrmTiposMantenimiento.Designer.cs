namespace AppEscritorioUPT.UI
{
    partial class FrmTiposMantenimiento
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
            btnGuardar = new Button();
            dgvTiposMantenimiento = new DataGridView();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTiposMantenimiento).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 36);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(21, 54);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(240, 23);
            txtNombre.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(21, 99);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(240, 32);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dgvTiposMantenimiento
            // 
            dgvTiposMantenimiento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiposMantenimiento.Location = new Point(21, 149);
            dgvTiposMantenimiento.Name = "dgvTiposMantenimiento";
            dgvTiposMantenimiento.Size = new Size(240, 150);
            dgvTiposMantenimiento.TabIndex = 3;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(21, 318);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmTiposMantenimiento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 368);
            Controls.Add(btnEliminar);
            Controls.Add(dgvTiposMantenimiento);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FrmTiposMantenimiento";
            Text = "FrmTiposMantenimiento";
            ((System.ComponentModel.ISupportInitialize)dgvTiposMantenimiento).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Button btnGuardar;
        private DataGridView dgvTiposMantenimiento;
        private Button btnEliminar;
    }
}