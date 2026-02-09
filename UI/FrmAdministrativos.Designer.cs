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
            btnEliminar.Location = new Point(1059, 105);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 40);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(933, 105);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(109, 40);
            btnActualizar.TabIndex = 14;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(530, 105);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(109, 40);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtPuesto
            // 
            txtPuesto.Location = new Point(12, 112);
            txtPuesto.Name = "txtPuesto";
            txtPuesto.Size = new Size(469, 27);
            txtPuesto.TabIndex = 12;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(12, 51);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(469, 27);
            txtNombreCompleto.TabIndex = 11;
            // 
            // lbPuesto
            // 
            lbPuesto.AutoSize = true;
            lbPuesto.Location = new Point(12, 89);
            lbPuesto.Name = "lbPuesto";
            lbPuesto.Size = new Size(53, 20);
            lbPuesto.TabIndex = 10;
            lbPuesto.Text = "Puesto";
            // 
            // lbNombreCompleto
            // 
            lbNombreCompleto.AutoSize = true;
            lbNombreCompleto.Location = new Point(12, 28);
            lbNombreCompleto.Name = "lbNombreCompleto";
            lbNombreCompleto.Size = new Size(134, 20);
            lbNombreCompleto.TabIndex = 9;
            lbNombreCompleto.Text = "Nombre Completo";
            // 
            // dgvAdministrativos
            // 
            dgvAdministrativos.AllowUserToAddRows = false;
            dgvAdministrativos.AllowUserToDeleteRows = false;
            dgvAdministrativos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdministrativos.Location = new Point(12, 155);
            dgvAdministrativos.MultiSelect = false;
            dgvAdministrativos.Name = "dgvAdministrativos";
            dgvAdministrativos.ReadOnly = true;
            dgvAdministrativos.RowHeadersWidth = 51;
            dgvAdministrativos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdministrativos.Size = new Size(1156, 283);
            dgvAdministrativos.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(530, 27);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 16;
            label1.Text = "Área";
            label1.Click += label1_Click;
            // 
            // cmbArea
            // 
            cmbArea.FormattingEnabled = true;
            cmbArea.Location = new Point(530, 50);
            cmbArea.Name = "cmbArea";
            cmbArea.Size = new Size(341, 28);
            cmbArea.TabIndex = 17;
            // 
            // FrmAdministrativos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 450);
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