namespace AppEscritorioUPT.UI
{
    partial class FrmEntregaConsumible
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
            cmbEquipos = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cmbConsumibles = new ComboBox();
            label3 = new Label();
            cmbAdministrativo = new ComboBox();
            label4 = new Label();
            cmbResponsable = new ComboBox();
            nudCantidad = new NumericUpDown();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // cmbEquipos
            // 
            cmbEquipos.FormattingEnabled = true;
            cmbEquipos.Location = new Point(28, 51);
            cmbEquipos.Name = "cmbEquipos";
            cmbEquipos.Size = new Size(270, 23);
            cmbEquipos.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 33);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Equipo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 100);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "Concumibles";
            // 
            // cmbConsumibles
            // 
            cmbConsumibles.FormattingEnabled = true;
            cmbConsumibles.Location = new Point(28, 118);
            cmbConsumibles.Name = "cmbConsumibles";
            cmbConsumibles.Size = new Size(270, 23);
            cmbConsumibles.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 172);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 5;
            label3.Text = "Administrativo";
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(28, 190);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(270, 23);
            cmbAdministrativo.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 247);
            label4.Name = "label4";
            label4.Size = new Size(122, 15);
            label4.TabIndex = 7;
            label4.Text = "Responsable Sistemas";
            // 
            // cmbResponsable
            // 
            cmbResponsable.FormattingEnabled = true;
            cmbResponsable.Location = new Point(28, 265);
            cmbResponsable.Name = "cmbResponsable";
            cmbResponsable.Size = new Size(270, 23);
            cmbResponsable.TabIndex = 6;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(28, 322);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(120, 23);
            nudCantidad.TabIndex = 8;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(28, 380);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(270, 50);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmEntregaConsumible
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 508);
            Controls.Add(btnGuardar);
            Controls.Add(nudCantidad);
            Controls.Add(label4);
            Controls.Add(cmbResponsable);
            Controls.Add(label3);
            Controls.Add(cmbAdministrativo);
            Controls.Add(label2);
            Controls.Add(cmbConsumibles);
            Controls.Add(label1);
            Controls.Add(cmbEquipos);
            Name = "FrmEntregaConsumible";
            Text = "FrmEntregaConsumible";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbEquipos;
        private Label label1;
        private Label label2;
        private ComboBox cmbConsumibles;
        private Label label3;
        private ComboBox cmbAdministrativo;
        private Label label4;
        private ComboBox cmbResponsable;
        private NumericUpDown nudCantidad;
        private Button btnGuardar;
    }
}