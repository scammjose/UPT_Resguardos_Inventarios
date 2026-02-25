namespace AppEscritorioUPT.UI
{
    partial class FrmAdministrativos
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
            txtPuesto = new TextBox();
            txtNombreCompleto = new TextBox();
            lbPuesto = new Label();
            lbNombreCompleto = new Label();
            dgvAdministrativos = new DataGridView();
            label1 = new Label();
            cmbArea = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvAdministrativos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(927, 79);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(95, 30);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(816, 79);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(95, 30);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(464, 79);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(95, 30);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtPuesto
            // 
            txtPuesto.Location = new Point(10, 84);
            txtPuesto.Margin = new Padding(3, 2, 3, 2);
            txtPuesto.Name = "txtPuesto";
            txtPuesto.Size = new Size(411, 23);
            txtPuesto.TabIndex = 2;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(10, 38);
            txtNombreCompleto.Margin = new Padding(3, 2, 3, 2);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(411, 23);
            txtNombreCompleto.TabIndex = 0;
            // 
            // lbPuesto
            // 
            lbPuesto.AutoSize = true;
            lbPuesto.Location = new Point(10, 67);
            lbPuesto.Name = "lbPuesto";
            lbPuesto.Size = new Size(43, 15);
            lbPuesto.TabIndex = 9;
            lbPuesto.Text = "Puesto";
            // 
            // lbNombreCompleto
            // 
            lbNombreCompleto.AutoSize = true;
            lbNombreCompleto.Location = new Point(10, 21);
            lbNombreCompleto.Name = "lbNombreCompleto";
            lbNombreCompleto.Size = new Size(107, 15);
            lbNombreCompleto.TabIndex = 7;
            lbNombreCompleto.Text = "Nombre Completo";
            // 
            // dgvAdministrativos
            // 
            dgvAdministrativos.AllowUserToAddRows = false;
            dgvAdministrativos.AllowUserToDeleteRows = false;
            dgvAdministrativos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAdministrativos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdministrativos.Location = new Point(10, 116);
            dgvAdministrativos.Margin = new Padding(3, 2, 3, 2);
            dgvAdministrativos.MultiSelect = false;
            dgvAdministrativos.Name = "dgvAdministrativos";
            dgvAdministrativos.ReadOnly = true;
            dgvAdministrativos.RowHeadersWidth = 51;
            dgvAdministrativos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdministrativos.Size = new Size(1012, 212);
            dgvAdministrativos.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(464, 20);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 8;
            label1.Text = "Área";
            // 
            // cmbArea
            // 
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(464, 38);
            cmbArea.Margin = new Padding(3, 2, 3, 2);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(299, 23);
            cmbArea.TabIndex = 1;
            // 
            // FrmAdministrativos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 338);
            Controls.Add(cmbArea);
            Controls.Add(label1);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(txtPuesto);
            Controls.Add(txtNombreCompleto);
            Controls.Add(lbPuesto);
            Controls.Add(lbNombreCompleto);
            Controls.Add(dgvAdministrativos);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmAdministrativos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmAdministrativos";
            ((System.ComponentModel.ISupportInitialize)dgvAdministrativos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnAgregar;
        private TextBox txtPuesto;
        private TextBox txtNombreCompleto;
        private Label lbPuesto;
        private Label lbNombreCompleto;
        private DataGridView dgvAdministrativos;
        private Label label1;
        private ComboBox cmbArea;
    }
}