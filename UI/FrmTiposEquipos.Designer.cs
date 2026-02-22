namespace AppEscritorioUPT.UI
{
    partial class FrmTiposEquipos
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
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnAgregar = new Button();
            txtNombre = new TextBox();
            lbNombre = new Label();
            dgvTipos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTipos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(679, 99);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 40);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(553, 99);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(109, 40);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 99);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(109, 40);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 51);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(339, 27);
            txtNombre.TabIndex = 0;
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.Location = new Point(12, 28);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(64, 20);
            lbNombre.TabIndex = 5;
            lbNombre.Text = "Nombre";
            // 
            // dgvTipos
            // 
            dgvTipos.AllowUserToAddRows = false;
            dgvTipos.AllowUserToDeleteRows = false;
            dgvTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipos.Location = new Point(12, 155);
            dgvTipos.MultiSelect = false;
            dgvTipos.Name = "dgvTipos";
            dgvTipos.ReadOnly = true;
            dgvTipos.RowHeadersWidth = 51;
            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipos.Size = new Size(776, 267);
            dgvTipos.TabIndex = 2;
            // 
            // FrmTiposEquipos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(txtNombre);
            Controls.Add(lbNombre);
            Controls.Add(dgvTipos);
            Name = "FrmTiposEquipos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmTiposEquipos";
            ((System.ComponentModel.ISupportInitialize)dgvTipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnAgregar;
        private TextBox txtNombre;
        private Label lbNombre;
        private DataGridView dgvTipos;
    }
}