namespace AppEscritorioUPT.UI
{
    partial class FrmEquiposPorLote
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
            cmbTipoEquipo = new ComboBox();
            lbTipoEquipo = new Label();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            lbModelo = new Label();
            lbMarca = new Label();
            pnlPc = new Panel();
            gbTipoPc = new GroupBox();
            rbAllInOne = new RadioButton();
            rbPcEscritorio = new RadioButton();
            chkTieneLectorCd = new CheckBox();
            txtDiscoDuro = new TextBox();
            lbDiscoDuro = new Label();
            txtProcesador = new TextBox();
            lbProcesador = new Label();
            txtMemoriaRam = new TextBox();
            lbMemoriaRam = new Label();
            nudCantidad = new NumericUpDown();
            label1 = new Label();
            dgvEquipos = new DataGridView();
            btnGuardar = new Button();
            label2 = new Label();
            cmbAdministrativo = new ComboBox();
            cmbResponsableSistemas = new ComboBox();
            label3 = new Label();
            cmbTipoUso = new ComboBox();
            label4 = new Label();
            chkMantenerLote = new CheckBox();
            cmbLaboratorio = new ComboBox();
            label5 = new Label();
            pnlPc.SuspendLayout();
            gbTipoPc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).BeginInit();
            SuspendLayout();
            // 
            // cmbTipoEquipo
            // 
            cmbTipoEquipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEquipo.FormattingEnabled = true;
            cmbTipoEquipo.Location = new Point(24, 50);
            cmbTipoEquipo.Margin = new Padding(3, 2, 3, 2);
            cmbTipoEquipo.Name = "cmbTipoEquipo";
            cmbTipoEquipo.Size = new Size(294, 23);
            cmbTipoEquipo.TabIndex = 17;
            // 
            // lbTipoEquipo
            // 
            lbTipoEquipo.AutoSize = true;
            lbTipoEquipo.Location = new Point(24, 33);
            lbTipoEquipo.Name = "lbTipoEquipo";
            lbTipoEquipo.Size = new Size(86, 15);
            lbTipoEquipo.TabIndex = 18;
            lbTipoEquipo.Text = "Tipo de Equipo";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(24, 169);
            txtModelo.Margin = new Padding(3, 2, 3, 2);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(297, 23);
            txtModelo.TabIndex = 20;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(24, 108);
            txtMarca.Margin = new Padding(3, 2, 3, 2);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(297, 23);
            txtMarca.TabIndex = 19;
            // 
            // lbModelo
            // 
            lbModelo.AutoSize = true;
            lbModelo.Location = new Point(24, 152);
            lbModelo.Name = "lbModelo";
            lbModelo.Size = new Size(48, 15);
            lbModelo.TabIndex = 22;
            lbModelo.Text = "Modelo";
            // 
            // lbMarca
            // 
            lbMarca.AutoSize = true;
            lbMarca.Location = new Point(24, 91);
            lbMarca.Name = "lbMarca";
            lbMarca.Size = new Size(40, 15);
            lbMarca.TabIndex = 21;
            lbMarca.Text = "Marca";
            // 
            // pnlPc
            // 
            pnlPc.Controls.Add(gbTipoPc);
            pnlPc.Controls.Add(chkTieneLectorCd);
            pnlPc.Controls.Add(txtDiscoDuro);
            pnlPc.Controls.Add(lbDiscoDuro);
            pnlPc.Controls.Add(txtProcesador);
            pnlPc.Controls.Add(lbProcesador);
            pnlPc.Controls.Add(txtMemoriaRam);
            pnlPc.Controls.Add(lbMemoriaRam);
            pnlPc.Location = new Point(363, 50);
            pnlPc.Name = "pnlPc";
            pnlPc.Size = new Size(857, 142);
            pnlPc.TabIndex = 23;
            // 
            // gbTipoPc
            // 
            gbTipoPc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbTipoPc.Controls.Add(rbAllInOne);
            gbTipoPc.Controls.Add(rbPcEscritorio);
            gbTipoPc.Location = new Point(604, 20);
            gbTipoPc.Name = "gbTipoPc";
            gbTipoPc.Size = new Size(145, 66);
            gbTipoPc.TabIndex = 17;
            gbTipoPc.TabStop = false;
            gbTipoPc.Text = "Tipo de PC";
            // 
            // rbAllInOne
            // 
            rbAllInOne.AutoSize = true;
            rbAllInOne.Location = new Point(6, 41);
            rbAllInOne.Name = "rbAllInOne";
            rbAllInOne.Size = new Size(77, 19);
            rbAllInOne.TabIndex = 1;
            rbAllInOne.TabStop = true;
            rbAllInOne.Text = "All In One";
            rbAllInOne.UseVisualStyleBackColor = true;
            // 
            // rbPcEscritorio
            // 
            rbPcEscritorio.AutoSize = true;
            rbPcEscritorio.Location = new Point(6, 17);
            rbPcEscritorio.Name = "rbPcEscritorio";
            rbPcEscritorio.Size = new Size(108, 19);
            rbPcEscritorio.TabIndex = 0;
            rbPcEscritorio.TabStop = true;
            rbPcEscritorio.Text = "PC de Escritorio";
            rbPcEscritorio.UseVisualStyleBackColor = true;
            // 
            // chkTieneLectorCd
            // 
            chkTieneLectorCd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chkTieneLectorCd.AutoSize = true;
            chkTieneLectorCd.Location = new Point(437, 35);
            chkTieneLectorCd.Name = "chkTieneLectorCd";
            chkTieneLectorCd.Size = new Size(119, 19);
            chkTieneLectorCd.TabIndex = 16;
            chkTieneLectorCd.Text = "¿Tiene Lector CD?";
            chkTieneLectorCd.UseVisualStyleBackColor = true;
            // 
            // txtDiscoDuro
            // 
            txtDiscoDuro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDiscoDuro.Location = new Point(304, 33);
            txtDiscoDuro.Name = "txtDiscoDuro";
            txtDiscoDuro.Size = new Size(90, 23);
            txtDiscoDuro.TabIndex = 15;
            // 
            // lbDiscoDuro
            // 
            lbDiscoDuro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbDiscoDuro.AutoSize = true;
            lbDiscoDuro.Location = new Point(304, 17);
            lbDiscoDuro.Name = "lbDiscoDuro";
            lbDiscoDuro.Size = new Size(65, 15);
            lbDiscoDuro.TabIndex = 12;
            lbDiscoDuro.Text = "Disco Duro";
            // 
            // txtProcesador
            // 
            txtProcesador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProcesador.Location = new Point(159, 33);
            txtProcesador.Name = "txtProcesador";
            txtProcesador.Size = new Size(90, 23);
            txtProcesador.TabIndex = 14;
            // 
            // lbProcesador
            // 
            lbProcesador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbProcesador.AutoSize = true;
            lbProcesador.Location = new Point(159, 17);
            lbProcesador.Name = "lbProcesador";
            lbProcesador.Size = new Size(66, 15);
            lbProcesador.TabIndex = 11;
            lbProcesador.Text = "Procesador";
            // 
            // txtMemoriaRam
            // 
            txtMemoriaRam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMemoriaRam.Location = new Point(15, 33);
            txtMemoriaRam.Name = "txtMemoriaRam";
            txtMemoriaRam.Size = new Size(90, 23);
            txtMemoriaRam.TabIndex = 13;
            // 
            // lbMemoriaRam
            // 
            lbMemoriaRam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbMemoriaRam.AutoSize = true;
            lbMemoriaRam.Location = new Point(15, 17);
            lbMemoriaRam.Name = "lbMemoriaRam";
            lbMemoriaRam.Size = new Size(84, 15);
            lbMemoriaRam.TabIndex = 10;
            lbMemoriaRam.Text = "Memoria RAM";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(24, 236);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(120, 23);
            nudCantidad.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 218);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 25;
            label1.Text = "Cantidad de Equipos";
            // 
            // dgvEquipos
            // 
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(24, 341);
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.Size = new Size(1196, 350);
            dgvEquipos.TabIndex = 26;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(24, 725);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(131, 40);
            btnGuardar.TabIndex = 27;
            btnGuardar.Text = "Guardar Lote";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(360, 218);
            label2.Name = "label2";
            label2.Size = new Size(138, 15);
            label2.TabIndex = 28;
            label2.Text = "Administrativo Asignado";
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(360, 235);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(250, 23);
            cmbAdministrativo.TabIndex = 29;
            // 
            // cmbResponsableSistemas
            // 
            cmbResponsableSistemas.FormattingEnabled = true;
            cmbResponsableSistemas.Location = new Point(664, 236);
            cmbResponsableSistemas.Name = "cmbResponsableSistemas";
            cmbResponsableSistemas.Size = new Size(250, 23);
            cmbResponsableSistemas.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(664, 219);
            label3.Name = "label3";
            label3.Size = new Size(138, 15);
            label3.TabIndex = 30;
            label3.Text = "Responsable de Sistemas";
            // 
            // cmbTipoUso
            // 
            cmbTipoUso.FormattingEnabled = true;
            cmbTipoUso.Location = new Point(973, 236);
            cmbTipoUso.Name = "cmbTipoUso";
            cmbTipoUso.Size = new Size(247, 23);
            cmbTipoUso.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(973, 219);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 32;
            label4.Text = "Tipo de Uso";
            // 
            // chkMantenerLote
            // 
            chkMantenerLote.AutoSize = true;
            chkMantenerLote.Location = new Point(172, 236);
            chkMantenerLote.Name = "chkMantenerLote";
            chkMantenerLote.Size = new Size(165, 19);
            chkMantenerLote.TabIndex = 34;
            chkMantenerLote.Text = "Mantener Lote de Registro";
            chkMantenerLote.UseVisualStyleBackColor = true;
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(360, 302);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(551, 23);
            cmbLaboratorio.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(363, 284);
            label5.Name = "label5";
            label5.Size = new Size(127, 15);
            label5.TabIndex = 36;
            label5.Text = "Laboratorio (Opcional)";
            // 
            // FrmEquiposPorLote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 808);
            Controls.Add(label5);
            Controls.Add(cmbLaboratorio);
            Controls.Add(chkMantenerLote);
            Controls.Add(cmbTipoUso);
            Controls.Add(label4);
            Controls.Add(cmbResponsableSistemas);
            Controls.Add(label3);
            Controls.Add(cmbAdministrativo);
            Controls.Add(label2);
            Controls.Add(btnGuardar);
            Controls.Add(dgvEquipos);
            Controls.Add(label1);
            Controls.Add(nudCantidad);
            Controls.Add(pnlPc);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(lbModelo);
            Controls.Add(lbMarca);
            Controls.Add(cmbTipoEquipo);
            Controls.Add(lbTipoEquipo);
            Name = "FrmEquiposPorLote";
            Text = "FrmEquiposPorLote";
            pnlPc.ResumeLayout(false);
            pnlPc.PerformLayout();
            gbTipoPc.ResumeLayout(false);
            gbTipoPc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTipoEquipo;
        private Label lbTipoEquipo;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private Label lbModelo;
        private Label lbMarca;
        private Panel pnlPc;
        private GroupBox gbTipoPc;
        private RadioButton rbAllInOne;
        private RadioButton rbPcEscritorio;
        private CheckBox chkTieneLectorCd;
        private TextBox txtDiscoDuro;
        private Label lbDiscoDuro;
        private TextBox txtProcesador;
        private Label lbProcesador;
        private TextBox txtMemoriaRam;
        private Label lbMemoriaRam;
        private NumericUpDown nudCantidad;
        private Label label1;
        private DataGridView dgvEquipos;
        private Button btnGuardar;
        private Label label2;
        private ComboBox cmbAdministrativo;
        private ComboBox cmbResponsableSistemas;
        private Label label3;
        private ComboBox cmbTipoUso;
        private Label label4;
        private CheckBox chkMantenerLote;
        private ComboBox cmbLaboratorio;
        private Label label5;
    }
}