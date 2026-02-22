namespace AppEscritorioUPT.UI
{
    partial class FrmAreas
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
            dgvAreas = new DataGridView();
            lbNombre = new Label();
            lbDescripcion = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            label1 = new Label();
            txtNomenclatura = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvAreas).BeginInit();
            SuspendLayout();
            // 
            // dgvAreas
            // 
            dgvAreas.AllowUserToAddRows = false;
            dgvAreas.AllowUserToDeleteRows = false;
            dgvAreas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAreas.Location = new Point(12, 171);
            dgvAreas.MultiSelect = false;
            dgvAreas.Name = "dgvAreas";
            dgvAreas.ReadOnly = true;
            dgvAreas.RowHeadersWidth = 51;
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAreas.Size = new Size(776, 267);
            dgvAreas.TabIndex = 4;
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.Location = new Point(12, 44);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(64, 20);
            lbNombre.TabIndex = 7;
            lbNombre.Text = "Nombre";
            // 
            // lbDescripcion
            // 
            lbDescripcion.AutoSize = true;
            lbDescripcion.Location = new Point(398, 44);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(87, 20);
            lbDescripcion.TabIndex = 8;
            lbDescripcion.Text = "Descripción";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(339, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(398, 67);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(339, 27);
            txtDescripcion.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(242, 121);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(109, 40);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(553, 115);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(109, 40);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(679, 115);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 40);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 105);
            label1.Name = "label1";
            label1.Size = new Size(173, 20);
            label1.TabIndex = 9;
            label1.Text = "Nomenclatura Inventario";
            // 
            // txtNomenclatura
            // 
            txtNomenclatura.Location = new Point(12, 128);
            txtNomenclatura.Name = "txtNomenclatura";
            txtNomenclatura.Size = new Size(186, 27);
            txtNomenclatura.TabIndex = 2;
            // 
            // FrmAreas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNomenclatura);
            Controls.Add(label1);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(lbDescripcion);
            Controls.Add(lbNombre);
            Controls.Add(dgvAreas);
            Name = "FrmAreas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administración de Areas";
            ((System.ComponentModel.ISupportInitialize)dgvAreas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAreas;
        private Label lbNombre;
        private Label lbDescripcion;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Label label1;
        private TextBox txtNomenclatura;
    }
}