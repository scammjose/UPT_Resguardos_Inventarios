namespace AppEscritorioUPT.UI
{
    partial class FrmResguardoMasivo
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
            lstDisponibles = new ListBox();
            lstAsignados = new ListBox();
            label1 = new Label();
            cmbAdministrativo = new ComboBox();
            dtpFechaResguardo = new DateTimePicker();
            lnFechaResguardo = new Label();
            btnAgregar = new Button();
            btnAgregarTodos = new Button();
            btnQuitar = new Button();
            btnQuitarTodos = new Button();
            label2 = new Label();
            label3 = new Label();
            btnGuardar = new Button();
            cmbResponsableSistemas = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            cmbTipoUso = new ComboBox();
            SuspendLayout();
            // 
            // lstDisponibles
            // 
            lstDisponibles.FormattingEnabled = true;
            lstDisponibles.ItemHeight = 15;
            lstDisponibles.Location = new Point(84, 234);
            lstDisponibles.Name = "lstDisponibles";
            lstDisponibles.Size = new Size(371, 349);
            lstDisponibles.TabIndex = 0;
            // 
            // lstAsignados
            // 
            lstAsignados.FormattingEnabled = true;
            lstAsignados.ItemHeight = 15;
            lstAsignados.Location = new Point(576, 234);
            lstAsignados.Name = "lstAsignados";
            lstAsignados.Size = new Size(371, 349);
            lstAsignados.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 42);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 2;
            label1.Text = "Administrativo";
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(90, 60);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(365, 23);
            cmbAdministrativo.TabIndex = 3;
            // 
            // dtpFechaResguardo
            // 
            dtpFechaResguardo.Location = new Point(576, 60);
            dtpFechaResguardo.Name = "dtpFechaResguardo";
            dtpFechaResguardo.Size = new Size(365, 23);
            dtpFechaResguardo.TabIndex = 15;
            // 
            // lnFechaResguardo
            // 
            lnFechaResguardo.AutoSize = true;
            lnFechaResguardo.Location = new Point(576, 42);
            lnFechaResguardo.Name = "lnFechaResguardo";
            lnFechaResguardo.Size = new Size(113, 15);
            lnFechaResguardo.TabIndex = 16;
            lnFechaResguardo.Text = "Fecha de Resguardo";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(483, 317);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 17;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarTodos
            // 
            btnAgregarTodos.Location = new Point(483, 346);
            btnAgregarTodos.Name = "btnAgregarTodos";
            btnAgregarTodos.Size = new Size(75, 43);
            btnAgregarTodos.TabIndex = 18;
            btnAgregarTodos.Text = "Agregar Todos";
            btnAgregarTodos.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(483, 432);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(75, 23);
            btnQuitar.TabIndex = 19;
            btnQuitar.Tag = "btn-secondary";
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnQuitarTodos
            // 
            btnQuitarTodos.Location = new Point(483, 461);
            btnQuitarTodos.Name = "btnQuitarTodos";
            btnQuitarTodos.Size = new Size(75, 43);
            btnQuitarTodos.TabIndex = 20;
            btnQuitarTodos.Tag = "btn-secondary";
            btnQuitarTodos.Text = "Quitar Todos";
            btnQuitarTodos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 216);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 21;
            label2.Text = "Equipos sin Asignar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(576, 216);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 22;
            label3.Text = "Equipos Asignados";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(818, 605);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(129, 38);
            btnGuardar.TabIndex = 23;
            btnGuardar.Tag = "btn-primary";
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // cmbResponsableSistemas
            // 
            cmbResponsableSistemas.FormattingEnabled = true;
            cmbResponsableSistemas.Location = new Point(90, 143);
            cmbResponsableSistemas.Name = "cmbResponsableSistemas";
            cmbResponsableSistemas.Size = new Size(365, 23);
            cmbResponsableSistemas.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 125);
            label4.Name = "label4";
            label4.Size = new Size(138, 15);
            label4.TabIndex = 24;
            label4.Text = "Responsable de Sistemas";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(576, 125);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 26;
            label5.Text = "Tipo de Uso";
            // 
            // cmbTipoUso
            // 
            cmbTipoUso.FormattingEnabled = true;
            cmbTipoUso.Location = new Point(576, 143);
            cmbTipoUso.Name = "cmbTipoUso";
            cmbTipoUso.Size = new Size(365, 23);
            cmbTipoUso.TabIndex = 27;
            // 
            // FrmResguardoMasivo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 668);
            Controls.Add(cmbTipoUso);
            Controls.Add(label5);
            Controls.Add(cmbResponsableSistemas);
            Controls.Add(label4);
            Controls.Add(btnGuardar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnQuitarTodos);
            Controls.Add(btnQuitar);
            Controls.Add(btnAgregarTodos);
            Controls.Add(btnAgregar);
            Controls.Add(dtpFechaResguardo);
            Controls.Add(lnFechaResguardo);
            Controls.Add(cmbAdministrativo);
            Controls.Add(label1);
            Controls.Add(lstAsignados);
            Controls.Add(lstDisponibles);
            Name = "FrmResguardoMasivo";
            Text = "FrmResguardoMasivo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstDisponibles;
        private ListBox lstAsignados;
        private Label label1;
        private ComboBox cmbAdministrativo;
        private DateTimePicker dtpFechaResguardo;
        private Label lnFechaResguardo;
        private Button btnAgregar;
        private Button btnAgregarTodos;
        private Button btnQuitar;
        private Button btnQuitarTodos;
        private Label label2;
        private Label label3;
        private Button btnGuardar;
        private ComboBox cmbResponsableSistemas;
        private Label label4;
        private Label label5;
        private ComboBox cmbTipoUso;
    }
}