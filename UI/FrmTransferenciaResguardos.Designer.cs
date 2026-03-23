namespace AppEscritorioUPT.UI
{
    partial class FrmTransferenciaResguardos
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
            label1 = new Label();
            dtpFechaTransferencia = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            cmbOrigen = new ComboBox();
            cmbDestino = new ComboBox();
            btnPasarTodosIzquierda = new Button();
            btnPasarIzquierda = new Button();
            btnPasarTodosDerecha = new Button();
            btnPasarDerecha = new Button();
            lstDestino = new ListBox();
            lstOrigen = new ListBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 25);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 0;
            label1.Text = "Fecha de Resguardo";
            // 
            // dtpFechaTransferencia
            // 
            dtpFechaTransferencia.Location = new Point(27, 43);
            dtpFechaTransferencia.Name = "dtpFechaTransferencia";
            dtpFechaTransferencia.Size = new Size(200, 23);
            dtpFechaTransferencia.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 105);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 2;
            label2.Text = "Administrativo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(519, 105);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 3;
            label3.Text = "Administrativo";
            // 
            // cmbOrigen
            // 
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(27, 123);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(371, 23);
            cmbOrigen.TabIndex = 4;
            // 
            // cmbDestino
            // 
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(519, 123);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(371, 23);
            cmbDestino.TabIndex = 5;
            // 
            // btnPasarTodosIzquierda
            // 
            btnPasarTodosIzquierda.Location = new Point(426, 388);
            btnPasarTodosIzquierda.Name = "btnPasarTodosIzquierda";
            btnPasarTodosIzquierda.Size = new Size(75, 43);
            btnPasarTodosIzquierda.TabIndex = 26;
            btnPasarTodosIzquierda.Tag = "btn-secondary";
            btnPasarTodosIzquierda.Text = "<<";
            btnPasarTodosIzquierda.UseVisualStyleBackColor = true;
            // 
            // btnPasarIzquierda
            // 
            btnPasarIzquierda.Location = new Point(426, 359);
            btnPasarIzquierda.Name = "btnPasarIzquierda";
            btnPasarIzquierda.Size = new Size(75, 23);
            btnPasarIzquierda.TabIndex = 25;
            btnPasarIzquierda.Tag = "btn-secondary";
            btnPasarIzquierda.Text = "<";
            btnPasarIzquierda.UseVisualStyleBackColor = true;
            // 
            // btnPasarTodosDerecha
            // 
            btnPasarTodosDerecha.Location = new Point(426, 273);
            btnPasarTodosDerecha.Name = "btnPasarTodosDerecha";
            btnPasarTodosDerecha.Size = new Size(75, 43);
            btnPasarTodosDerecha.TabIndex = 24;
            btnPasarTodosDerecha.Text = ">>";
            btnPasarTodosDerecha.UseVisualStyleBackColor = true;
            // 
            // btnPasarDerecha
            // 
            btnPasarDerecha.Location = new Point(426, 244);
            btnPasarDerecha.Name = "btnPasarDerecha";
            btnPasarDerecha.Size = new Size(75, 23);
            btnPasarDerecha.TabIndex = 23;
            btnPasarDerecha.Text = ">";
            btnPasarDerecha.UseVisualStyleBackColor = true;
            // 
            // lstDestino
            // 
            lstDestino.FormattingEnabled = true;
            lstDestino.ItemHeight = 15;
            lstDestino.Location = new Point(519, 161);
            lstDestino.Name = "lstDestino";
            lstDestino.Size = new Size(371, 349);
            lstDestino.TabIndex = 22;
            // 
            // lstOrigen
            // 
            lstOrigen.FormattingEnabled = true;
            lstOrigen.ItemHeight = 15;
            lstOrigen.Location = new Point(27, 161);
            lstOrigen.Name = "lstOrigen";
            lstOrigen.Size = new Size(371, 349);
            lstOrigen.TabIndex = 21;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(761, 535);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(129, 38);
            btnGuardar.TabIndex = 27;
            btnGuardar.Tag = "btn-primary";
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmTransferenciaResguardos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 585);
            Controls.Add(btnGuardar);
            Controls.Add(btnPasarTodosIzquierda);
            Controls.Add(btnPasarIzquierda);
            Controls.Add(btnPasarTodosDerecha);
            Controls.Add(btnPasarDerecha);
            Controls.Add(lstDestino);
            Controls.Add(lstOrigen);
            Controls.Add(cmbDestino);
            Controls.Add(cmbOrigen);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpFechaTransferencia);
            Controls.Add(label1);
            Name = "FrmTransferenciaResguardos";
            Text = "FrmTransferenciaResguardos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFechaTransferencia;
        private Label label2;
        private Label label3;
        private ComboBox cmbOrigen;
        private ComboBox cmbDestino;
        private Button btnPasarTodosIzquierda;
        private Button btnPasarIzquierda;
        private Button btnPasarTodosDerecha;
        private Button btnPasarDerecha;
        private ListBox lstDestino;
        private ListBox lstOrigen;
        private Button btnGuardar;
    }
}