namespace AppEscritorioUPT.UI
{
    partial class FrmConsultaEquipos
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
            cmbFiltroTipo = new ComboBox();
            label1 = new Label();
            txtFiltroSerie = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtFiltroIp = new TextBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            dgvResultados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // cmbFiltroTipo
            // 
            cmbFiltroTipo.FormattingEnabled = true;
            cmbFiltroTipo.Location = new Point(25, 55);
            cmbFiltroTipo.Name = "cmbFiltroTipo";
            cmbFiltroTipo.Size = new Size(136, 23);
            cmbFiltroTipo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 37);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 1;
            label1.Text = "Tipo de equipo";
            // 
            // txtFiltroSerie
            // 
            txtFiltroSerie.Location = new Point(187, 55);
            txtFiltroSerie.Name = "txtFiltroSerie";
            txtFiltroSerie.Size = new Size(198, 23);
            txtFiltroSerie.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(187, 37);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 3;
            label2.Text = "Número de Serie";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 37);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 5;
            label3.Text = "Dirección IP";
            // 
            // txtFiltroIp
            // 
            txtFiltroIp.Location = new Point(408, 55);
            txtFiltroIp.Name = "txtFiltroIp";
            txtFiltroIp.Size = new Size(198, 23);
            txtFiltroIp.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(25, 102);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(136, 23);
            btnBuscar.TabIndex = 6;
            btnBuscar.Tag = "btn-primary";
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(470, 102);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(136, 23);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Tag = "btn-secondary";
            btnLimpiar.Text = "Limpiar Filtros";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // dgvResultados
            // 
            dgvResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(12, 164);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.Size = new Size(776, 274);
            dgvResultados.TabIndex = 8;
            // 
            // FrmConsultaEquipos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvResultados);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(label3);
            Controls.Add(txtFiltroIp);
            Controls.Add(label2);
            Controls.Add(txtFiltroSerie);
            Controls.Add(label1);
            Controls.Add(cmbFiltroTipo);
            Name = "FrmConsultaEquipos";
            Text = "FrmConsultaEquipos";
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFiltroTipo;
        private Label label1;
        private TextBox txtFiltroSerie;
        private Label label2;
        private Label label3;
        private TextBox txtFiltroIp;
        private Button btnBuscar;
        private Button btnLimpiar;
        private DataGridView dgvResultados;
    }
}