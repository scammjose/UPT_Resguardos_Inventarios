namespace AppEscritorioUPT.UI
{
    partial class FrmConsumibles
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
            txtModelo = new TextBox();
            lbModelo = new Label();
            cmbTipo = new ComboBox();
            label1 = new Label();
            nudStockActual = new NumericUpDown();
            nudStockMinimo = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            btnGuardar = new Button();
            dgvConsumibles = new DataGridView();
            cmbColor = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudStockActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvConsumibles).BeginInit();
            SuspendLayout();
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(23, 63);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(246, 23);
            txtModelo.TabIndex = 0;
            // 
            // lbModelo
            // 
            lbModelo.AutoSize = true;
            lbModelo.Location = new Point(23, 45);
            lbModelo.Name = "lbModelo";
            lbModelo.Size = new Size(48, 15);
            lbModelo.TabIndex = 1;
            lbModelo.Text = "Modelo";
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(23, 126);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(246, 23);
            cmbTipo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 108);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 3;
            label1.Text = "Tipo de Impresión";
            // 
            // nudStockActual
            // 
            nudStockActual.Location = new Point(23, 257);
            nudStockActual.Name = "nudStockActual";
            nudStockActual.Size = new Size(102, 23);
            nudStockActual.TabIndex = 4;
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.Location = new Point(167, 257);
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(102, 23);
            nudStockMinimo.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 239);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 6;
            label2.Text = "Stock";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 239);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 7;
            label3.Text = "Stock Minimo";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(23, 308);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(246, 52);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dgvConsumibles
            // 
            dgvConsumibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsumibles.Location = new Point(318, 63);
            dgvConsumibles.Name = "dgvConsumibles";
            dgvConsumibles.Size = new Size(470, 297);
            dgvConsumibles.TabIndex = 9;
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Location = new Point(23, 189);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(246, 23);
            cmbColor.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 171);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 11;
            label4.Text = "Color";
            // 
            // FrmConsumibles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 413);
            Controls.Add(label4);
            Controls.Add(cmbColor);
            Controls.Add(dgvConsumibles);
            Controls.Add(btnGuardar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nudStockMinimo);
            Controls.Add(nudStockActual);
            Controls.Add(label1);
            Controls.Add(cmbTipo);
            Controls.Add(lbModelo);
            Controls.Add(txtModelo);
            Name = "FrmConsumibles";
            Text = "FrmConsumibles";
            ((System.ComponentModel.ISupportInitialize)nudStockActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvConsumibles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtModelo;
        private Label lbModelo;
        private ComboBox cmbTipo;
        private Label label1;
        private NumericUpDown nudStockActual;
        private NumericUpDown nudStockMinimo;
        private Label label2;
        private Label label3;
        private Button btnGuardar;
        private DataGridView dgvConsumibles;
        private ComboBox cmbColor;
        private Label label4;
    }
}