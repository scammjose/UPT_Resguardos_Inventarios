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
            pnlPc = new Panel();
            pnlPerifericos = new Panel();
            txtSerieWebcam = new TextBox();
            txtModeloWebcam = new TextBox();
            txtMarcaWebcam = new TextBox();
            txtSerieMouse = new TextBox();
            txtModeloMouse = new TextBox();
            txtMarcaMouse = new TextBox();
            txtSerieTeclado = new TextBox();
            txtModeloTeclado = new TextBox();
            txtMarcaTeclado = new TextBox();
            txtSerieMonitor = new TextBox();
            txtModeloMonitor = new TextBox();
            txtMarcaMonitor = new TextBox();
            lbWebcam = new Label();
            lbSerieTipoPc = new Label();
            lbModeloTipoPc = new Label();
            lbMouse = new Label();
            lbMarcaTipoPc = new Label();
            lbTeclado = new Label();
            lbMonitor = new Label();
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
            label1 = new Label();
            pnlImpresora = new Panel();
            gbImpresora = new GroupBox();
            cmbTipoImpresion = new ComboBox();
            pnlTelefono = new Panel();
            txtPrivilegiosLlamadas = new TextBox();
            lbPrivilegios = new Label();
            txtNumeroExtension = new TextBox();
            lbNumeroExtension = new Label();
            txtMacAddress = new TextBox();
            lbMacAddress = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).BeginInit();
            pnlPc.SuspendLayout();
            pnlPerifericos.SuspendLayout();
            gbTipoPc.SuspendLayout();
            pnlImpresora.SuspendLayout();
            gbImpresora.SuspendLayout();
            pnlTelefono.SuspendLayout();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Location = new Point(1086, 344);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(95, 30);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(976, 344);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(95, 30);
            btnActualizar.TabIndex = 14;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(10, 344);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(95, 30);
            btnAgregar.TabIndex = 13;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(13, 159);
            txtModelo.Margin = new Padding(3, 2, 3, 2);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(297, 23);
            txtModelo.TabIndex = 12;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(13, 108);
            txtMarca.Margin = new Padding(3, 2, 3, 2);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(297, 23);
            txtMarca.TabIndex = 11;
            // 
            // lbModelo
            // 
            lbModelo.AutoSize = true;
            lbModelo.Location = new Point(13, 142);
            lbModelo.Name = "lbModelo";
            lbModelo.Size = new Size(48, 15);
            lbModelo.TabIndex = 10;
            lbModelo.Text = "Modelo";
            // 
            // lbMarca
            // 
            lbMarca.AutoSize = true;
            lbMarca.Location = new Point(13, 91);
            lbMarca.Name = "lbMarca";
            lbMarca.Size = new Size(40, 15);
            lbMarca.TabIndex = 9;
            lbMarca.Text = "Marca";
            // 
            // dgvEquipos
            // 
            dgvEquipos.AllowUserToAddRows = false;
            dgvEquipos.AllowUserToDeleteRows = false;
            dgvEquipos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(10, 386);
            dgvEquipos.Margin = new Padding(3, 2, 3, 2);
            dgvEquipos.MultiSelect = false;
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.ReadOnly = true;
            dgvEquipos.RowHeadersWidth = 51;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.Size = new Size(1171, 200);
            dgvEquipos.TabIndex = 8;
            // 
            // lbTipoEquipo
            // 
            lbTipoEquipo.AutoSize = true;
            lbTipoEquipo.Location = new Point(13, 40);
            lbTipoEquipo.Name = "lbTipoEquipo";
            lbTipoEquipo.Size = new Size(86, 15);
            lbTipoEquipo.TabIndex = 16;
            lbTipoEquipo.Text = "Tipo de Equipo";
            // 
            // cmbTipoEquipo
            // 
            cmbTipoEquipo.FormattingEnabled = true;
            cmbTipoEquipo.Location = new Point(13, 57);
            cmbTipoEquipo.Margin = new Padding(3, 2, 3, 2);
            cmbTipoEquipo.Name = "cmbTipoEquipo";
            cmbTipoEquipo.Size = new Size(294, 23);
            cmbTipoEquipo.TabIndex = 17;
            // 
            // txtNumeroSerie
            // 
            txtNumeroSerie.Location = new Point(13, 215);
            txtNumeroSerie.Margin = new Padding(3, 2, 3, 2);
            txtNumeroSerie.Name = "txtNumeroSerie";
            txtNumeroSerie.Size = new Size(297, 23);
            txtNumeroSerie.TabIndex = 19;
            // 
            // lnNumeroSerie
            // 
            lnNumeroSerie.AutoSize = true;
            lnNumeroSerie.Location = new Point(10, 198);
            lnNumeroSerie.Name = "lnNumeroSerie";
            lnNumeroSerie.Size = new Size(95, 15);
            lnNumeroSerie.TabIndex = 18;
            lnNumeroSerie.Text = "Número de Serie";
            // 
            // txtDireccionIp
            // 
            txtDireccionIp.Location = new Point(13, 274);
            txtDireccionIp.Margin = new Padding(3, 2, 3, 2);
            txtDireccionIp.Name = "txtDireccionIp";
            txtDireccionIp.Size = new Size(297, 23);
            txtDireccionIp.TabIndex = 21;
            // 
            // lbDireccionIp
            // 
            lbDireccionIp.AutoSize = true;
            lbDireccionIp.Location = new Point(10, 256);
            lbDireccionIp.Name = "lbDireccionIp";
            lbDireccionIp.Size = new Size(70, 15);
            lbDireccionIp.TabIndex = 20;
            lbDireccionIp.Text = "Dirección IP";
            // 
            // pnlPc
            // 
            pnlPc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPc.BorderStyle = BorderStyle.FixedSingle;
            pnlPc.Controls.Add(pnlPerifericos);
            pnlPc.Controls.Add(gbTipoPc);
            pnlPc.Controls.Add(chkTieneLectorCd);
            pnlPc.Controls.Add(txtDiscoDuro);
            pnlPc.Controls.Add(lbDiscoDuro);
            pnlPc.Controls.Add(txtProcesador);
            pnlPc.Controls.Add(lbProcesador);
            pnlPc.Controls.Add(txtMemoriaRam);
            pnlPc.Controls.Add(lbMemoriaRam);
            pnlPc.Controls.Add(label1);
            pnlPc.Location = new Point(383, 40);
            pnlPc.Name = "pnlPc";
            pnlPc.Size = new Size(798, 257);
            pnlPc.TabIndex = 22;
            pnlPc.Visible = false;
            // 
            // pnlPerifericos
            // 
            pnlPerifericos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPerifericos.BorderStyle = BorderStyle.FixedSingle;
            pnlPerifericos.Controls.Add(txtSerieWebcam);
            pnlPerifericos.Controls.Add(txtModeloWebcam);
            pnlPerifericos.Controls.Add(txtMarcaWebcam);
            pnlPerifericos.Controls.Add(txtSerieMouse);
            pnlPerifericos.Controls.Add(txtModeloMouse);
            pnlPerifericos.Controls.Add(txtMarcaMouse);
            pnlPerifericos.Controls.Add(txtSerieTeclado);
            pnlPerifericos.Controls.Add(txtModeloTeclado);
            pnlPerifericos.Controls.Add(txtMarcaTeclado);
            pnlPerifericos.Controls.Add(txtSerieMonitor);
            pnlPerifericos.Controls.Add(txtModeloMonitor);
            pnlPerifericos.Controls.Add(txtMarcaMonitor);
            pnlPerifericos.Controls.Add(lbWebcam);
            pnlPerifericos.Controls.Add(lbSerieTipoPc);
            pnlPerifericos.Controls.Add(lbModeloTipoPc);
            pnlPerifericos.Controls.Add(lbMouse);
            pnlPerifericos.Controls.Add(lbMarcaTipoPc);
            pnlPerifericos.Controls.Add(lbTeclado);
            pnlPerifericos.Controls.Add(lbMonitor);
            pnlPerifericos.Location = new Point(3, 75);
            pnlPerifericos.Name = "pnlPerifericos";
            pnlPerifericos.Size = new Size(790, 177);
            pnlPerifericos.TabIndex = 9;
            pnlPerifericos.Visible = false;
            // 
            // txtSerieWebcam
            // 
            txtSerieWebcam.Location = new Point(563, 139);
            txtSerieWebcam.Name = "txtSerieWebcam";
            txtSerieWebcam.Size = new Size(222, 23);
            txtSerieWebcam.TabIndex = 18;
            // 
            // txtModeloWebcam
            // 
            txtModeloWebcam.Location = new Point(318, 139);
            txtModeloWebcam.Name = "txtModeloWebcam";
            txtModeloWebcam.Size = new Size(222, 23);
            txtModeloWebcam.TabIndex = 17;
            // 
            // txtMarcaWebcam
            // 
            txtMarcaWebcam.Location = new Point(78, 139);
            txtMarcaWebcam.Name = "txtMarcaWebcam";
            txtMarcaWebcam.Size = new Size(222, 23);
            txtMarcaWebcam.TabIndex = 16;
            // 
            // txtSerieMouse
            // 
            txtSerieMouse.Location = new Point(563, 106);
            txtSerieMouse.Name = "txtSerieMouse";
            txtSerieMouse.Size = new Size(222, 23);
            txtSerieMouse.TabIndex = 15;
            // 
            // txtModeloMouse
            // 
            txtModeloMouse.Location = new Point(318, 106);
            txtModeloMouse.Name = "txtModeloMouse";
            txtModeloMouse.Size = new Size(222, 23);
            txtModeloMouse.TabIndex = 14;
            // 
            // txtMarcaMouse
            // 
            txtMarcaMouse.Location = new Point(78, 106);
            txtMarcaMouse.Name = "txtMarcaMouse";
            txtMarcaMouse.Size = new Size(222, 23);
            txtMarcaMouse.TabIndex = 13;
            // 
            // txtSerieTeclado
            // 
            txtSerieTeclado.Location = new Point(563, 68);
            txtSerieTeclado.Name = "txtSerieTeclado";
            txtSerieTeclado.Size = new Size(222, 23);
            txtSerieTeclado.TabIndex = 12;
            // 
            // txtModeloTeclado
            // 
            txtModeloTeclado.Location = new Point(318, 68);
            txtModeloTeclado.Name = "txtModeloTeclado";
            txtModeloTeclado.Size = new Size(222, 23);
            txtModeloTeclado.TabIndex = 11;
            // 
            // txtMarcaTeclado
            // 
            txtMarcaTeclado.Location = new Point(78, 68);
            txtMarcaTeclado.Name = "txtMarcaTeclado";
            txtMarcaTeclado.Size = new Size(222, 23);
            txtMarcaTeclado.TabIndex = 10;
            // 
            // txtSerieMonitor
            // 
            txtSerieMonitor.Location = new Point(563, 29);
            txtSerieMonitor.Name = "txtSerieMonitor";
            txtSerieMonitor.Size = new Size(222, 23);
            txtSerieMonitor.TabIndex = 9;
            // 
            // txtModeloMonitor
            // 
            txtModeloMonitor.Location = new Point(318, 29);
            txtModeloMonitor.Name = "txtModeloMonitor";
            txtModeloMonitor.Size = new Size(222, 23);
            txtModeloMonitor.TabIndex = 8;
            // 
            // txtMarcaMonitor
            // 
            txtMarcaMonitor.Location = new Point(78, 29);
            txtMarcaMonitor.Name = "txtMarcaMonitor";
            txtMarcaMonitor.Size = new Size(222, 23);
            txtMarcaMonitor.TabIndex = 7;
            // 
            // lbWebcam
            // 
            lbWebcam.AutoSize = true;
            lbWebcam.Location = new Point(12, 142);
            lbWebcam.Name = "lbWebcam";
            lbWebcam.Size = new Size(59, 15);
            lbWebcam.TabIndex = 6;
            lbWebcam.Text = "Web Cam";
            // 
            // lbSerieTipoPc
            // 
            lbSerieTipoPc.AutoSize = true;
            lbSerieTipoPc.Location = new Point(638, 11);
            lbSerieTipoPc.Name = "lbSerieTipoPc";
            lbSerieTipoPc.Size = new Size(95, 15);
            lbSerieTipoPc.TabIndex = 5;
            lbSerieTipoPc.Text = "Número de Serie";
            // 
            // lbModeloTipoPc
            // 
            lbModeloTipoPc.AutoSize = true;
            lbModeloTipoPc.Location = new Point(404, 11);
            lbModeloTipoPc.Name = "lbModeloTipoPc";
            lbModeloTipoPc.Size = new Size(48, 15);
            lbModeloTipoPc.TabIndex = 4;
            lbModeloTipoPc.Text = "Modelo";
            // 
            // lbMouse
            // 
            lbMouse.AutoSize = true;
            lbMouse.Location = new Point(12, 109);
            lbMouse.Name = "lbMouse";
            lbMouse.Size = new Size(43, 15);
            lbMouse.TabIndex = 1;
            lbMouse.Text = "Mouse";
            // 
            // lbMarcaTipoPc
            // 
            lbMarcaTipoPc.AutoSize = true;
            lbMarcaTipoPc.Location = new Point(169, 11);
            lbMarcaTipoPc.Name = "lbMarcaTipoPc";
            lbMarcaTipoPc.Size = new Size(40, 15);
            lbMarcaTipoPc.TabIndex = 3;
            lbMarcaTipoPc.Text = "Marca";
            // 
            // lbTeclado
            // 
            lbTeclado.AutoSize = true;
            lbTeclado.Location = new Point(12, 71);
            lbTeclado.Name = "lbTeclado";
            lbTeclado.Size = new Size(47, 15);
            lbTeclado.TabIndex = 2;
            lbTeclado.Text = "Teclado";
            // 
            // lbMonitor
            // 
            lbMonitor.AutoSize = true;
            lbMonitor.Location = new Point(12, 32);
            lbMonitor.Name = "lbMonitor";
            lbMonitor.Size = new Size(50, 15);
            lbMonitor.TabIndex = 0;
            lbMonitor.Text = "Monitor";
            // 
            // gbTipoPc
            // 
            gbTipoPc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbTipoPc.Controls.Add(rbAllInOne);
            gbTipoPc.Controls.Add(rbPcEscritorio);
            gbTipoPc.Location = new Point(592, 3);
            gbTipoPc.Name = "gbTipoPc";
            gbTipoPc.Size = new Size(145, 66);
            gbTipoPc.TabIndex = 8;
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
            chkTieneLectorCd.Location = new Point(425, 18);
            chkTieneLectorCd.Name = "chkTieneLectorCd";
            chkTieneLectorCd.Size = new Size(119, 19);
            chkTieneLectorCd.TabIndex = 7;
            chkTieneLectorCd.Text = "¿Tiene Lector CD?";
            chkTieneLectorCd.UseVisualStyleBackColor = true;
            // 
            // txtDiscoDuro
            // 
            txtDiscoDuro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDiscoDuro.Location = new Point(292, 16);
            txtDiscoDuro.Name = "txtDiscoDuro";
            txtDiscoDuro.Size = new Size(90, 23);
            txtDiscoDuro.TabIndex = 6;
            // 
            // lbDiscoDuro
            // 
            lbDiscoDuro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbDiscoDuro.AutoSize = true;
            lbDiscoDuro.Location = new Point(292, 0);
            lbDiscoDuro.Name = "lbDiscoDuro";
            lbDiscoDuro.Size = new Size(65, 15);
            lbDiscoDuro.TabIndex = 5;
            lbDiscoDuro.Text = "Disco Duro";
            // 
            // txtProcesador
            // 
            txtProcesador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProcesador.Location = new Point(147, 16);
            txtProcesador.Name = "txtProcesador";
            txtProcesador.Size = new Size(90, 23);
            txtProcesador.TabIndex = 4;
            // 
            // lbProcesador
            // 
            lbProcesador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbProcesador.AutoSize = true;
            lbProcesador.Location = new Point(147, 0);
            lbProcesador.Name = "lbProcesador";
            lbProcesador.Size = new Size(66, 15);
            lbProcesador.TabIndex = 3;
            lbProcesador.Text = "Procesador";
            // 
            // txtMemoriaRam
            // 
            txtMemoriaRam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMemoriaRam.Location = new Point(3, 16);
            txtMemoriaRam.Name = "txtMemoriaRam";
            txtMemoriaRam.Size = new Size(90, 23);
            txtMemoriaRam.TabIndex = 2;
            // 
            // lbMemoriaRam
            // 
            lbMemoriaRam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbMemoriaRam.AutoSize = true;
            lbMemoriaRam.Location = new Point(3, 0);
            lbMemoriaRam.Name = "lbMemoriaRam";
            lbMemoriaRam.Size = new Size(84, 15);
            lbMemoriaRam.TabIndex = 1;
            lbMemoriaRam.Text = "Memoria RAM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // pnlImpresora
            // 
            pnlImpresora.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlImpresora.BorderStyle = BorderStyle.FixedSingle;
            pnlImpresora.Controls.Add(gbImpresora);
            pnlImpresora.Location = new Point(383, 40);
            pnlImpresora.Name = "pnlImpresora";
            pnlImpresora.Size = new Size(798, 257);
            pnlImpresora.TabIndex = 23;
            pnlImpresora.Visible = false;
            // 
            // gbImpresora
            // 
            gbImpresora.Controls.Add(cmbTipoImpresion);
            gbImpresora.Location = new Point(25, 18);
            gbImpresora.Name = "gbImpresora";
            gbImpresora.Size = new Size(200, 100);
            gbImpresora.TabIndex = 0;
            gbImpresora.TabStop = false;
            gbImpresora.Text = "Datos de Impresora / Escáner";
            // 
            // cmbTipoImpresion
            // 
            cmbTipoImpresion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoImpresion.FormattingEnabled = true;
            cmbTipoImpresion.Location = new Point(9, 23);
            cmbTipoImpresion.Name = "cmbTipoImpresion";
            cmbTipoImpresion.Size = new Size(121, 23);
            cmbTipoImpresion.TabIndex = 0;
            // 
            // pnlTelefono
            // 
            pnlTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTelefono.BorderStyle = BorderStyle.FixedSingle;
            pnlTelefono.Controls.Add(txtPrivilegiosLlamadas);
            pnlTelefono.Controls.Add(lbPrivilegios);
            pnlTelefono.Controls.Add(txtNumeroExtension);
            pnlTelefono.Controls.Add(lbNumeroExtension);
            pnlTelefono.Controls.Add(txtMacAddress);
            pnlTelefono.Controls.Add(lbMacAddress);
            pnlTelefono.Location = new Point(383, 40);
            pnlTelefono.Name = "pnlTelefono";
            pnlTelefono.Size = new Size(797, 257);
            pnlTelefono.TabIndex = 24;
            pnlTelefono.Visible = false;
            // 
            // txtPrivilegiosLlamadas
            // 
            txtPrivilegiosLlamadas.Location = new Point(16, 192);
            txtPrivilegiosLlamadas.Name = "txtPrivilegiosLlamadas";
            txtPrivilegiosLlamadas.Size = new Size(270, 23);
            txtPrivilegiosLlamadas.TabIndex = 5;
            // 
            // lbPrivilegios
            // 
            lbPrivilegios.AutoSize = true;
            lbPrivilegios.Location = new Point(16, 173);
            lbPrivilegios.Name = "lbPrivilegios";
            lbPrivilegios.Size = new Size(61, 15);
            lbPrivilegios.TabIndex = 4;
            lbPrivilegios.Text = "Privilegios";
            // 
            // txtNumeroExtension
            // 
            txtNumeroExtension.Location = new Point(16, 115);
            txtNumeroExtension.Name = "txtNumeroExtension";
            txtNumeroExtension.Size = new Size(270, 23);
            txtNumeroExtension.TabIndex = 3;
            // 
            // lbNumeroExtension
            // 
            lbNumeroExtension.AutoSize = true;
            lbNumeroExtension.Location = new Point(16, 96);
            lbNumeroExtension.Name = "lbNumeroExtension";
            lbNumeroExtension.Size = new Size(121, 15);
            lbNumeroExtension.TabIndex = 2;
            lbNumeroExtension.Text = "Número de Extensión";
            // 
            // txtMacAddress
            // 
            txtMacAddress.Location = new Point(16, 34);
            txtMacAddress.Name = "txtMacAddress";
            txtMacAddress.Size = new Size(270, 23);
            txtMacAddress.TabIndex = 1;
            // 
            // lbMacAddress
            // 
            lbMacAddress.AutoSize = true;
            lbMacAddress.Location = new Point(16, 15);
            lbMacAddress.Name = "lbMacAddress";
            lbMacAddress.Size = new Size(75, 15);
            lbMacAddress.TabIndex = 0;
            lbMacAddress.Text = "Mac Address";
            // 
            // FrmEquipos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 595);
            Controls.Add(pnlTelefono);
            Controls.Add(pnlImpresora);
            Controls.Add(pnlPc);
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
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1208, 634);
            Name = "FrmEquipos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmEquipos";
            ((System.ComponentModel.ISupportInitialize)dgvEquipos).EndInit();
            pnlPc.ResumeLayout(false);
            pnlPc.PerformLayout();
            pnlPerifericos.ResumeLayout(false);
            pnlPerifericos.PerformLayout();
            gbTipoPc.ResumeLayout(false);
            gbTipoPc.PerformLayout();
            pnlImpresora.ResumeLayout(false);
            gbImpresora.ResumeLayout(false);
            pnlTelefono.ResumeLayout(false);
            pnlTelefono.PerformLayout();
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
        private Panel pnlPc;
        private Label label1;
        private TextBox txtMemoriaRam;
        private Label lbMemoriaRam;
        private TextBox txtProcesador;
        private Label lbProcesador;
        private CheckBox chkTieneLectorCd;
        private TextBox txtDiscoDuro;
        private Label lbDiscoDuro;
        private GroupBox gbTipoPc;
        private RadioButton rbAllInOne;
        private RadioButton rbPcEscritorio;
        private Panel pnlPerifericos;
        private Label lbMonitor;
        private Label lbMarcaTipoPc;
        private Label lbTeclado;
        private Label lbMouse;
        private TextBox txtSerieTeclado;
        private TextBox txtModeloTeclado;
        private TextBox txtMarcaTeclado;
        private TextBox txtSerieMonitor;
        private TextBox txtModeloMonitor;
        private TextBox txtMarcaMonitor;
        private Label lbWebcam;
        private Label lbSerieTipoPc;
        private Label lbModeloTipoPc;
        private TextBox txtSerieMouse;
        private TextBox txtModeloMouse;
        private TextBox txtMarcaMouse;
        private TextBox txtSerieWebcam;
        private TextBox txtModeloWebcam;
        private TextBox txtMarcaWebcam;
        private Panel pnlImpresora;
        private GroupBox gbImpresora;
        private ComboBox cmbTipoImpresion;
        private Panel pnlTelefono;
        private Label lbMacAddress;
        private TextBox txtPrivilegiosLlamadas;
        private Label lbPrivilegios;
        private TextBox txtNumeroExtension;
        private Label lbNumeroExtension;
        private TextBox txtMacAddress;
    }
}