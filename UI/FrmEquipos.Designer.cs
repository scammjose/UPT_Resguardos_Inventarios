namespace AppEscritorioUPT.UI
{
    partial class FrmEquipos
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
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            lbModelo = new Label();
            lbMarca = new Label();
            dgvEquipos = new DataGridView();
            lbTipoEquipo = new Label();
            cmbTipoEquipo = new ComboBox();
            txtNumeroSerie = new TextBox();
            lnNumeroSerie = new Label();
            txtDireccionIp = new TextBox();
            lbDireccionIp = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1241, 458);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 40);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(1115, 458);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(109, 40);
            btnActualizar.TabIndex = 14;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 458);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(109, 40);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(15, 212);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(339, 27);
            txtModelo.TabIndex = 12;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(15, 144);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(339, 27);
            txtMarca.TabIndex = 11;
            // 
            // lbModelo
            // 
            lbModelo.AutoSize = true;
            lbModelo.Location = new Point(15, 189);
            lbModelo.Name = "lbModelo";
            lbModelo.Size = new Size(61, 20);
            lbModelo.TabIndex = 10;
            lbModelo.Text = "Modelo";
            // 
            // lbMarca
            // 
            lbMarca.AutoSize = true;
            lbMarca.Location = new Point(15, 121);
            lbMarca.Name = "lbMarca";
            lbMarca.Size = new Size(50, 20);
            lbMarca.TabIndex = 9;
            lbMarca.Text = "Marca";
            // 
            // dgvEquipos
            // 
            dgvEquipos.AllowUserToAddRows = false;
            dgvEquipos.AllowUserToDeleteRows = false;
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(12, 514);
            dgvEquipos.MultiSelect = false;
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.ReadOnly = true;
            dgvEquipos.RowHeadersWidth = 51;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.Size = new Size(1338, 267);
            dgvEquipos.TabIndex = 8;
            // 
            // lbTipoEquipo
            // 
            lbTipoEquipo.AutoSize = true;
            lbTipoEquipo.Location = new Point(15, 53);
            lbTipoEquipo.Name = "lbTipoEquipo";
            lbTipoEquipo.Size = new Size(111, 20);
            lbTipoEquipo.TabIndex = 16;
            lbTipoEquipo.Text = "Tipo de Equipo";
            // 
            // cmbTipoEquipo
            // 
            cmbTipoEquipo.FormattingEnabled = true;
            cmbTipoEquipo.Location = new Point(15, 76);
            cmbTipoEquipo.Name = "cmbTipoEquipo";
            cmbTipoEquipo.Size = new Size(336, 28);
            cmbTipoEquipo.TabIndex = 17;
            // 
            // txtNumeroSerie
            // 
            txtNumeroSerie.Location = new Point(15, 287);
            txtNumeroSerie.Name = "txtNumeroSerie";
            txtNumeroSerie.Size = new Size(339, 27);
            txtNumeroSerie.TabIndex = 19;
            // 
            // lnNumeroSerie
            // 
            lnNumeroSerie.AutoSize = true;
            lnNumeroSerie.Location = new Point(12, 264);
            lnNumeroSerie.Name = "lnNumeroSerie";
            lnNumeroSerie.Size = new Size(121, 20);
            lnNumeroSerie.TabIndex = 18;
            lnNumeroSerie.Text = "Número de Serie";
            // 
            // txtDireccionIp
            // 
            txtDireccionIp.Location = new Point(15, 365);
            txtDireccionIp.Name = "txtDireccionIp";
            txtDireccionIp.Size = new Size(339, 27);
            txtDireccionIp.TabIndex = 21;
            // 
            // lbDireccionIp
            // 
            lbDireccionIp.AutoSize = true;
            lbDireccionIp.Location = new Point(12, 342);
            lbDireccionIp.Name = "lbDireccionIp";
            lbDireccionIp.Size = new Size(88, 20);
            lbDireccionIp.TabIndex = 20;
            lbDireccionIp.Text = "Dirección IP";
            // 
            // FrmEquipos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 793);
            Controls.Add(txtDireccionIp);
            Controls.Add(lbDireccionIp);
            Controls.Add(txtNumeroSerie);
            Controls.Add(lnNumeroSerie);
            Controls.Add(cmbTipoEquipo);
            Controls.Add(lbTipoEquipo);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(lbModelo);
            Controls.Add(lbMarca);
            Controls.Add(dgvEquipos);
            Name = "FrmEquipos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmEquipos";
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnAgregar;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private Label lbModelo;
        private Label lbMarca;
        private DataGridView dgvEquipos;
        private Label lbTipoEquipo;
        private ComboBox cmbTipoEquipo;
        private TextBox txtNumeroSerie;
        private Label lnNumeroSerie;
        private TextBox txtDireccionIp;
        private Label lbDireccionIp;
    }
}