namespace AppEscritorioUPT.UI
{
    partial class FrmTiposUso
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
            txtNombre = new TextBox();
            dgvTipos = new DataGridView();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTipos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 37);
            label1.Name = "label1";
            label1.Size = new Size(135, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre del Tipo de Uso";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(24, 55);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(383, 23);
            txtNombre.TabIndex = 1;
            // 
            // dgvTipos
            // 
            dgvTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipos.Location = new Point(24, 121);
            dgvTipos.Name = "dgvTipos";
            dgvTipos.Size = new Size(383, 150);
            dgvTipos.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(24, 296);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(123, 41);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmTiposUso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 358);
            Controls.Add(btnGuardar);
            Controls.Add(dgvTipos);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FrmTiposUso";
            Text = "FrmTiposUso";
            ((System.ComponentModel.ISupportInitialize)dgvTipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private DataGridView dgvTipos;
        private Button btnGuardar;
    }
}