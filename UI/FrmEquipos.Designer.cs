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
            btnEliminar.Location = new Point(1241, 459);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 40);
            btnEliminar.TabIndex = 29;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(1115, 459);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(109, 40);
            btnActualizar.TabIndex = 28;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(11, 459);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(109, 40);
            btnAgregar.TabIndex = 26;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(15, 212);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(339, 27);
            txtModelo.TabIndex = 2;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(15, 144);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(339, 27);
            txtMarca.TabIndex = 1;
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
            dgvEquipos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEquipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquipos.Location = new Point(11, 515);
            dgvEquipos.MultiSelect = false;
            dgvEquipos.Name = "dgvEquipos";
            dgvEquipos.ReadOnly = true;
            dgvEquipos.RowHeadersWidth = 51;
            dgvEquipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipos.Size = new Size(1338, 267);
            dgvEquipos.TabIndex = 27;
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
            cmbTipoEquipo.Size = new Size(335, 28);
            cmbTipoEquipo.TabIndex = 0;
            // 
            // txtNumeroSerie
            // 
            txtNumeroSerie.Location = new Point(15, 287);
            txtNumeroSerie.Name = "txtNumeroSerie";
            txtNumeroSerie.Size = new Size(339, 27);
            txtNumeroSerie.TabIndex = 3;
            // 
            // lnNumeroSerie
            // 
            lnNumeroSerie.AutoSize = true;
            lnNumeroSerie.Location = new Point(11, 264);
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
            txtDireccionIp.TabIndex = 4;
            // 
            // lbDireccionIp
            // 
            lbDireccionIp.AutoSize = true;
            lbDireccionIp.Location = new Point(11, 341);
            lbDireccionIp.Name = "lbDireccionIp";
            lbDireccionIp.Size = new Size(88, 20);
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
            pnlPc.Location = new Point(438, 53);
            pnlPc.Margin = new Padding(3, 4, 3, 4);
            pnlPc.Name = "pnlPc";
            pnlPc.Size = new Size(912, 342);
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
            pnlPerifericos.Location = new Point(3, 100);
            pnlPerifericos.Margin = new Padding(3, 4, 3, 4);
            pnlPerifericos.Name = "pnlPerifericos";
            pnlPerifericos.Size = new Size(903, 235);
            pnlPerifericos.TabIndex = 9;
            pnlPerifericos.Visible = false;
            // 
            // txtSerieWebcam
            // 
            txtSerieWebcam.Location = new Point(643, 185);
            txtSerieWebcam.Margin = new Padding(3, 4, 3, 4);
            txtSerieWebcam.Name = "txtSerieWebcam";
            txtSerieWebcam.Size = new Size(253, 27);
            txtSerieWebcam.TabIndex = 21;
            // 
            // txtModeloWebcam
            // 
            txtModeloWebcam.Location = new Point(363, 185);
            txtModeloWebcam.Margin = new Padding(3, 4, 3, 4);
            txtModeloWebcam.Name = "txtModeloWebcam";
            txtModeloWebcam.Size = new Size(253, 27);
            txtModeloWebcam.TabIndex = 20;
            // 
            // txtMarcaWebcam
            // 
            txtMarcaWebcam.Location = new Point(89, 185);
            txtMarcaWebcam.Margin = new Padding(3, 4, 3, 4);
            txtMarcaWebcam.Name = "txtMarcaWebcam";
            txtMarcaWebcam.Size = new Size(253, 27);
            txtMarcaWebcam.TabIndex = 19;
            // 
            // txtSerieMouse
            // 
            txtSerieMouse.Location = new Point(643, 141);
            txtSerieMouse.Margin = new Padding(3, 4, 3, 4);
            txtSerieMouse.Name = "txtSerieMouse";
            txtSerieMouse.Size = new Size(253, 27);
            txtSerieMouse.TabIndex = 18;
            // 
            // txtModeloMouse
            // 
            txtModeloMouse.Location = new Point(363, 141);
            txtModeloMouse.Margin = new Padding(3, 4, 3, 4);
            txtModeloMouse.Name = "txtModeloMouse";
            txtModeloMouse.Size = new Size(253, 27);
            txtModeloMouse.TabIndex = 17;
            // 
            // txtMarcaMouse
            // 
            txtMarcaMouse.Location = new Point(89, 141);
            txtMarcaMouse.Margin = new Padding(3, 4, 3, 4);
            txtMarcaMouse.Name = "txtMarcaMouse";
            txtMarcaMouse.Size = new Size(253, 27);
            txtMarcaMouse.TabIndex = 16;
            // 
            // txtSerieTeclado
            // 
            txtSerieTeclado.Location = new Point(643, 91);
            txtSerieTeclado.Margin = new Padding(3, 4, 3, 4);
            txtSerieTeclado.Name = "txtSerieTeclado";
            txtSerieTeclado.Size = new Size(253, 27);
            txtSerieTeclado.TabIndex = 15;
            // 
            // txtModeloTeclado
            // 
            txtModeloTeclado.Location = new Point(363, 91);
            txtModeloTeclado.Margin = new Padding(3, 4, 3, 4);
            txtModeloTeclado.Name = "txtModeloTeclado";
            txtModeloTeclado.Size = new Size(253, 27);
            txtModeloTeclado.TabIndex = 14;
            // 
            // txtMarcaTeclado
            // 
            txtMarcaTeclado.Location = new Point(89, 91);
            txtMarcaTeclado.Margin = new Padding(3, 4, 3, 4);
            txtMarcaTeclado.Name = "txtMarcaTeclado";
            txtMarcaTeclado.Size = new Size(253, 27);
            txtMarcaTeclado.TabIndex = 13;
            // 
            // txtSerieMonitor
            // 
            txtSerieMonitor.Location = new Point(643, 39);
            txtSerieMonitor.Margin = new Padding(3, 4, 3, 4);
            txtSerieMonitor.Name = "txtSerieMonitor";
            txtSerieMonitor.Size = new Size(253, 27);
            txtSerieMonitor.TabIndex = 12;
            // 
            // txtModeloMonitor
            // 
            txtModeloMonitor.Location = new Point(363, 39);
            txtModeloMonitor.Margin = new Padding(3, 4, 3, 4);
            txtModeloMonitor.Name = "txtModeloMonitor";
            txtModeloMonitor.Size = new Size(253, 27);
            txtModeloMonitor.TabIndex = 11;
            // 
            // txtMarcaMonitor
            // 
            txtMarcaMonitor.Location = new Point(89, 39);
            txtMarcaMonitor.Margin = new Padding(3, 4, 3, 4);
            txtMarcaMonitor.Name = "txtMarcaMonitor";
            txtMarcaMonitor.Size = new Size(253, 27);
            txtMarcaMonitor.TabIndex = 10;
            // 
            // lbWebcam
            // 
            lbWebcam.AutoSize = true;
            lbWebcam.Location = new Point(14, 189);
            lbWebcam.Name = "lbWebcam";
            lbWebcam.Size = new Size(73, 20);
            lbWebcam.TabIndex = 6;
            lbWebcam.Text = "Web Cam";
            // 
            // lbSerieTipoPc
            // 
            lbSerieTipoPc.AutoSize = true;
            lbSerieTipoPc.Location = new Point(729, 15);
            lbSerieTipoPc.Name = "lbSerieTipoPc";
            lbSerieTipoPc.Size = new Size(121, 20);
            lbSerieTipoPc.TabIndex = 5;
            lbSerieTipoPc.Text = "Número de Serie";
            // 
            // lbModeloTipoPc
            // 
            lbModeloTipoPc.AutoSize = true;
            lbModeloTipoPc.Location = new Point(462, 15);
            lbModeloTipoPc.Name = "lbModeloTipoPc";
            lbModeloTipoPc.Size = new Size(61, 20);
            lbModeloTipoPc.TabIndex = 4;
            lbModeloTipoPc.Text = "Modelo";
            // 
            // lbMouse
            // 
            lbMouse.AutoSize = true;
            lbMouse.Location = new Point(14, 145);
            lbMouse.Name = "lbMouse";
            lbMouse.Size = new Size(53, 20);
            lbMouse.TabIndex = 1;
            lbMouse.Text = "Mouse";
            // 
            // lbMarcaTipoPc
            // 
            lbMarcaTipoPc.AutoSize = true;
            lbMarcaTipoPc.Location = new Point(193, 15);
            lbMarcaTipoPc.Name = "lbMarcaTipoPc";
            lbMarcaTipoPc.Size = new Size(50, 20);
            lbMarcaTipoPc.TabIndex = 3;
            lbMarcaTipoPc.Text = "Marca";
            // 
            // lbTeclado
            // 
            lbTeclado.AutoSize = true;
            lbTeclado.Location = new Point(14, 95);
            lbTeclado.Name = "lbTeclado";
            lbTeclado.Size = new Size(61, 20);
            lbTeclado.TabIndex = 2;
            lbTeclado.Text = "Teclado";
            // 
            // lbMonitor
            // 
            lbMonitor.AutoSize = true;
            lbMonitor.Location = new Point(14, 43);
            lbMonitor.Name = "lbMonitor";
            lbMonitor.Size = new Size(62, 20);
            lbMonitor.TabIndex = 0;
            lbMonitor.Text = "Monitor";
            // 
            // gbTipoPc
            // 
            gbTipoPc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbTipoPc.Controls.Add(rbAllInOne);
            gbTipoPc.Controls.Add(rbPcEscritorio);
            gbTipoPc.Location = new Point(677, 4);
            gbTipoPc.Margin = new Padding(3, 4, 3, 4);
            gbTipoPc.Name = "gbTipoPc";
            gbTipoPc.Padding = new Padding(3, 4, 3, 4);
            gbTipoPc.Size = new Size(166, 88);
            gbTipoPc.TabIndex = 9;
            gbTipoPc.TabStop = false;
            gbTipoPc.Text = "Tipo de PC";
            // 
            // rbAllInOne
            // 
            rbAllInOne.AutoSize = true;
            rbAllInOne.Location = new Point(7, 55);
            rbAllInOne.Margin = new Padding(3, 4, 3, 4);
            rbAllInOne.Name = "rbAllInOne";
            rbAllInOne.Size = new Size(95, 24);
            rbAllInOne.TabIndex = 1;
            rbAllInOne.TabStop = true;
            rbAllInOne.Text = "All In One";
            rbAllInOne.UseVisualStyleBackColor = true;
            // 
            // rbPcEscritorio
            // 
            rbPcEscritorio.AutoSize = true;
            rbPcEscritorio.Location = new Point(7, 23);
            rbPcEscritorio.Margin = new Padding(3, 4, 3, 4);
            rbPcEscritorio.Name = "rbPcEscritorio";
            rbPcEscritorio.Size = new Size(134, 24);
            rbPcEscritorio.TabIndex = 0;
            rbPcEscritorio.TabStop = true;
            rbPcEscritorio.Text = "PC de Escritorio";
            rbPcEscritorio.UseVisualStyleBackColor = true;
            // 
            // chkTieneLectorCd
            // 
            chkTieneLectorCd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chkTieneLectorCd.AutoSize = true;
            chkTieneLectorCd.Location = new Point(486, 24);
            chkTieneLectorCd.Margin = new Padding(3, 4, 3, 4);
            chkTieneLectorCd.Name = "chkTieneLectorCd";
            chkTieneLectorCd.Size = new Size(150, 24);
            chkTieneLectorCd.TabIndex = 8;
            chkTieneLectorCd.Text = "¿Tiene Lector CD?";
            chkTieneLectorCd.UseVisualStyleBackColor = true;
            // 
            // txtDiscoDuro
            // 
            txtDiscoDuro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDiscoDuro.Location = new Point(334, 21);
            txtDiscoDuro.Margin = new Padding(3, 4, 3, 4);
            txtDiscoDuro.Name = "txtDiscoDuro";
            txtDiscoDuro.Size = new Size(102, 27);
            txtDiscoDuro.TabIndex = 7;
            // 
            // lbDiscoDuro
            // 
            lbDiscoDuro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbDiscoDuro.AutoSize = true;
            lbDiscoDuro.Location = new Point(334, 0);
            lbDiscoDuro.Name = "lbDiscoDuro";
            lbDiscoDuro.Size = new Size(83, 20);
            lbDiscoDuro.TabIndex = 5;
            lbDiscoDuro.Text = "Disco Duro";
            // 
            // txtProcesador
            // 
            txtProcesador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtProcesador.Location = new Point(168, 21);
            txtProcesador.Margin = new Padding(3, 4, 3, 4);
            txtProcesador.Name = "txtProcesador";
            txtProcesador.Size = new Size(102, 27);
            txtProcesador.TabIndex = 6;
            // 
            // lbProcesador
            // 
            lbProcesador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbProcesador.AutoSize = true;
            lbProcesador.Location = new Point(168, 0);
            lbProcesador.Name = "lbProcesador";
            lbProcesador.Size = new Size(83, 20);
            lbProcesador.TabIndex = 3;
            lbProcesador.Text = "Procesador";
            // 
            // txtMemoriaRam
            // 
            txtMemoriaRam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMemoriaRam.Location = new Point(3, 21);
            txtMemoriaRam.Margin = new Padding(3, 4, 3, 4);
            txtMemoriaRam.Name = "txtMemoriaRam";
            txtMemoriaRam.Size = new Size(102, 27);
            txtMemoriaRam.TabIndex = 5;
            // 
            // lbMemoriaRam
            // 
            lbMemoriaRam.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbMemoriaRam.AutoSize = true;
            lbMemoriaRam.Location = new Point(3, 0);
            lbMemoriaRam.Name = "lbMemoriaRam";
            lbMemoriaRam.Size = new Size(105, 20);
            lbMemoriaRam.TabIndex = 1;
            lbMemoriaRam.Text = "Memoria RAM";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // pnlImpresora
            // 
            pnlImpresora.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlImpresora.BorderStyle = BorderStyle.FixedSingle;
            pnlImpresora.Controls.Add(gbImpresora);
            pnlImpresora.Location = new Point(438, 53);
            pnlImpresora.Margin = new Padding(3, 4, 3, 4);
            pnlImpresora.Name = "pnlImpresora";
            pnlImpresora.Size = new Size(912, 342);
            pnlImpresora.TabIndex = 23;
            pnlImpresora.Visible = false;
            // 
            // gbImpresora
            // 
            gbImpresora.Controls.Add(cmbTipoImpresion);
            gbImpresora.Location = new Point(29, 24);
            gbImpresora.Margin = new Padding(3, 4, 3, 4);
            gbImpresora.Name = "gbImpresora";
            gbImpresora.Padding = new Padding(3, 4, 3, 4);
            gbImpresora.Size = new Size(229, 133);
            gbImpresora.TabIndex = 22;
            gbImpresora.TabStop = false;
            gbImpresora.Text = "Datos de Impresora / Escáner";
            // 
            // cmbTipoImpresion
            // 
            cmbTipoImpresion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoImpresion.FormattingEnabled = true;
            cmbTipoImpresion.Location = new Point(10, 31);
            cmbTipoImpresion.Margin = new Padding(3, 4, 3, 4);
            cmbTipoImpresion.Name = "cmbTipoImpresion";
            cmbTipoImpresion.Size = new Size(138, 28);
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
            pnlTelefono.Location = new Point(438, 53);
            pnlTelefono.Margin = new Padding(3, 4, 3, 4);
            pnlTelefono.Name = "pnlTelefono";
            pnlTelefono.Size = new Size(911, 342);
            pnlTelefono.TabIndex = 24;
            pnlTelefono.Visible = false;
            // 
            // txtPrivilegiosLlamadas
            // 
            txtPrivilegiosLlamadas.Location = new Point(18, 256);
            txtPrivilegiosLlamadas.Margin = new Padding(3, 4, 3, 4);
            txtPrivilegiosLlamadas.Name = "txtPrivilegiosLlamadas";
            txtPrivilegiosLlamadas.Size = new Size(308, 27);
            txtPrivilegiosLlamadas.TabIndex = 25;
            // 
            // lbPrivilegios
            // 
            lbPrivilegios.AutoSize = true;
            lbPrivilegios.Location = new Point(18, 231);
            lbPrivilegios.Name = "lbPrivilegios";
            lbPrivilegios.Size = new Size(77, 20);
            lbPrivilegios.TabIndex = 4;
            lbPrivilegios.Text = "Privilegios";
            // 
            // txtNumeroExtension
            // 
            txtNumeroExtension.Location = new Point(18, 153);
            txtNumeroExtension.Margin = new Padding(3, 4, 3, 4);
            txtNumeroExtension.Name = "txtNumeroExtension";
            txtNumeroExtension.Size = new Size(308, 27);
            txtNumeroExtension.TabIndex = 24;
            // 
            // lbNumeroExtension
            // 
            lbNumeroExtension.AutoSize = true;
            lbNumeroExtension.Location = new Point(18, 128);
            lbNumeroExtension.Name = "lbNumeroExtension";
            lbNumeroExtension.Size = new Size(151, 20);
            lbNumeroExtension.TabIndex = 2;
            lbNumeroExtension.Text = "Número de Extensión";
            // 
            // txtMacAddress
            // 
            txtMacAddress.Location = new Point(18, 45);
            txtMacAddress.Margin = new Padding(3, 4, 3, 4);
            txtMacAddress.Name = "txtMacAddress";
            txtMacAddress.Size = new Size(308, 27);
            txtMacAddress.TabIndex = 23;
            // 
            // lbMacAddress
            // 
            lbMacAddress.AutoSize = true;
            lbMacAddress.Location = new Point(18, 20);
            lbMacAddress.Name = "lbMacAddress";
            lbMacAddress.Size = new Size(94, 20);
            lbMacAddress.TabIndex = 0;
            lbMacAddress.Text = "Mac Address";
            // 
            // FrmEquipos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 793);
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
            MinimumSize = new Size(1378, 830);
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