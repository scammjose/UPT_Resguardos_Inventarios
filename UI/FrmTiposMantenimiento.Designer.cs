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
            label1.Location = new Point(24, 48);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(24, 72);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(274, 27);
            txtNombre.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(24, 132);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(274, 43);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dgvTiposMantenimiento
            // 
            dgvTiposMantenimiento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiposMantenimiento.Location = new Point(24, 199);
            dgvTiposMantenimiento.Margin = new Padding(3, 4, 3, 4);
            dgvTiposMantenimiento.Name = "dgvTiposMantenimiento";
            dgvTiposMantenimiento.RowHeadersWidth = 51;
            dgvTiposMantenimiento.Size = new Size(274, 200);
            dgvTiposMantenimiento.TabIndex = 2;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(24, 424);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 31);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FrmTiposMantenimiento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 491);
            Controls.Add(btnEliminar);
            Controls.Add(dgvTiposMantenimiento);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
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