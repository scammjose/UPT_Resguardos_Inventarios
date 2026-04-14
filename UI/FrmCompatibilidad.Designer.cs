namespace AppEscritorioUPT.UI
{
    partial class FrmCompatibilidad
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
            dgvConsumibles = new DataGridView();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvConsumibles).BeginInit();
            SuspendLayout();
            // 
            // cmbEquipos
            // 
            cmbEquipos.FormattingEnabled = true;
            cmbEquipos.Location = new Point(28, 54);
            cmbEquipos.Name = "cmbEquipos";
            cmbEquipos.Size = new Size(324, 23);
            cmbEquipos.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 36);
            label1.Name = "label1";
            label1.Size = new Size(199, 15);
            label1.TabIndex = 1;
            label1.Text = "Selección de Modelos de Impresoras";
            // 
            // dgvConsumibles
            // 
            dgvConsumibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsumibles.Location = new Point(28, 97);
            dgvConsumibles.Name = "dgvConsumibles";
            dgvConsumibles.Size = new Size(745, 260);
            dgvConsumibles.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(28, 373);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 48);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmCompatibilidad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(dgvConsumibles);
            Controls.Add(label1);
            Controls.Add(cmbEquipos);
            Name = "FrmCompatibilidad";
            Text = "FrmCompatibilidad";
            ((System.ComponentModel.ISupportInitialize)dgvConsumibles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbEquipos;
        private Label label1;
        private DataGridView dgvConsumibles;
        private Button btnGuardar;
    }
}