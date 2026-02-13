namespace AppEscritorioUPT.UI
{
    partial class FrmResguardos
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
            dgvResguardos = new DataGridView();
            lbEquipo = new Label();
            cmbEquipo = new ComboBox();
            cmbAdministrativo = new ComboBox();
            lbAdministrativo = new Label();
            cmbResponsableSistemas = new ComboBox();
            label1 = new Label();
            lbCodigoInventario = new Label();
            txtCodigoInventario = new TextBox();
            lnFechaResguardo = new Label();
            dtpFechaResguardo = new DateTimePicker();
            lnObservaciones = new Label();
            txtNotas = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvResguardos).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(693, 264);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(95, 30);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(583, 264);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(95, 30);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 264);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(95, 30);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // dgvResguardos
            // 
            dgvResguardos.AllowUserToAddRows = false;
            dgvResguardos.AllowUserToDeleteRows = false;
            dgvResguardos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResguardos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResguardos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResguardos.Location = new Point(12, 309);
            dgvResguardos.Margin = new Padding(3, 2, 3, 2);
            dgvResguardos.MultiSelect = false;
            dgvResguardos.Name = "dgvResguardos";
            dgvResguardos.ReadOnly = true;
            dgvResguardos.RowHeadersWidth = 51;
            dgvResguardos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResguardos.Size = new Size(776, 239);
            dgvResguardos.TabIndex = 8;
            // 
            // lbEquipo
            // 
            lbEquipo.AutoSize = true;
            lbEquipo.Location = new Point(12, 18);
            lbEquipo.Name = "lbEquipo";
            lbEquipo.Size = new Size(44, 15);
            lbEquipo.TabIndex = 12;
            lbEquipo.Text = "Equipo";
            // 
            // cmbEquipo
            // 
            cmbEquipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEquipo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbEquipo.FormattingEnabled = true;
            cmbEquipo.Location = new Point(12, 36);
            cmbEquipo.Name = "cmbEquipo";
            cmbEquipo.Size = new Size(298, 23);
            cmbEquipo.TabIndex = 13;
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(12, 92);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(298, 23);
            cmbAdministrativo.TabIndex = 15;
            // 
            // lbAdministrativo
            // 
            lbAdministrativo.AutoSize = true;
            lbAdministrativo.Location = new Point(12, 74);
            lbAdministrativo.Name = "lbAdministrativo";
            lbAdministrativo.Size = new Size(85, 15);
            lbAdministrativo.TabIndex = 14;
            lbAdministrativo.Text = "Administrativo";
            // 
            // cmbResponsableSistemas
            // 
            cmbResponsableSistemas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbResponsableSistemas.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbResponsableSistemas.FormattingEnabled = true;
            cmbResponsableSistemas.Location = new Point(12, 147);
            cmbResponsableSistemas.Name = "cmbResponsableSistemas";
            cmbResponsableSistemas.Size = new Size(298, 23);
            cmbResponsableSistemas.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 129);
            label1.Name = "label1";
            label1.Size = new Size(138, 15);
            label1.TabIndex = 16;
            label1.Text = "Responsable de Sistemas";
            // 
            // lbCodigoInventario
            // 
            lbCodigoInventario.AutoSize = true;
            lbCodigoInventario.Location = new Point(369, 18);
            lbCodigoInventario.Name = "lbCodigoInventario";
            lbCodigoInventario.Size = new Size(121, 15);
            lbCodigoInventario.TabIndex = 18;
            lbCodigoInventario.Text = "Código  de Inventario";
            // 
            // txtCodigoInventario
            // 
            txtCodigoInventario.Location = new Point(369, 36);
            txtCodigoInventario.Name = "txtCodigoInventario";
            txtCodigoInventario.ReadOnly = true;
            txtCodigoInventario.Size = new Size(298, 23);
            txtCodigoInventario.TabIndex = 19;
            // 
            // lnFechaResguardo
            // 
            lnFechaResguardo.AutoSize = true;
            lnFechaResguardo.Location = new Point(369, 74);
            lnFechaResguardo.Name = "lnFechaResguardo";
            lnFechaResguardo.Size = new Size(113, 15);
            lnFechaResguardo.TabIndex = 20;
            lnFechaResguardo.Text = "Fecha de Resguardo";
            // 
            // dtpFechaResguardo
            // 
            dtpFechaResguardo.Location = new Point(369, 92);
            dtpFechaResguardo.Name = "dtpFechaResguardo";
            dtpFechaResguardo.Size = new Size(298, 23);
            dtpFechaResguardo.TabIndex = 21;
            // 
            // lnObservaciones
            // 
            lnObservaciones.AutoSize = true;
            lnObservaciones.Location = new Point(369, 129);
            lnObservaciones.Name = "lnObservaciones";
            lnObservaciones.Size = new Size(84, 15);
            lnObservaciones.TabIndex = 22;
            lnObservaciones.Text = "Observaciones";
            // 
            // txtNotas
            // 
            txtNotas.Location = new Point(369, 147);
            txtNotas.Multiline = true;
            txtNotas.Name = "txtNotas";
            txtNotas.ScrollBars = ScrollBars.Vertical;
            txtNotas.Size = new Size(298, 94);
            txtNotas.TabIndex = 23;
            // 
            // FrmResguardos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 559);
            Controls.Add(txtNotas);
            Controls.Add(lnObservaciones);
            Controls.Add(dtpFechaResguardo);
            Controls.Add(lnFechaResguardo);
            Controls.Add(txtCodigoInventario);
            Controls.Add(lbCodigoInventario);
            Controls.Add(cmbResponsableSistemas);
            Controls.Add(label1);
            Controls.Add(cmbAdministrativo);
            Controls.Add(lbAdministrativo);
            Controls.Add(cmbEquipo);
            Controls.Add(lbEquipo);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvResguardos);
            Name = "FrmResguardos";
            Text = "FrmResguardos";
            ((System.ComponentModel.ISupportInitialize)dgvResguardos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnAgregar;
        private DataGridView dgvResguardos;
        private Label lbEquipo;
        private ComboBox cmbEquipo;
        private ComboBox cmbAdministrativo;
        private Label lbAdministrativo;
        private ComboBox cmbResponsableSistemas;
        private Label label1;
        private Label lbCodigoInventario;
        private TextBox txtCodigoInventario;
        private Label lnFechaResguardo;
        private DateTimePicker dtpFechaResguardo;
        private Label lnObservaciones;
        private TextBox txtNotas;
    }
}