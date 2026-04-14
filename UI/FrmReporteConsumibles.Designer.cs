namespace AppEscritorioUPT.UI
{
    partial class FrmReporteConsumibles
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
            dgvReporte = new DataGridView();
            btnImprimir = new Button();
            btnGenerarRequisicion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(12, 12);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(776, 342);
            dgvReporte.TabIndex = 0;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(12, 378);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(182, 60);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "Generar Pdf";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnGenerarRequisicion
            // 
            btnGenerarRequisicion.Location = new Point(217, 378);
            btnGenerarRequisicion.Name = "btnGenerarRequisicion";
            btnGenerarRequisicion.Size = new Size(182, 60);
            btnGenerarRequisicion.TabIndex = 2;
            btnGenerarRequisicion.Text = "Generar Requisicion";
            btnGenerarRequisicion.UseVisualStyleBackColor = true;
            btnGenerarRequisicion.Click += btnGenerarRequisicion_Click;
            // 
            // FrmReporteConsumibles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGenerarRequisicion);
            Controls.Add(btnImprimir);
            Controls.Add(dgvReporte);
            Name = "FrmReporteConsumibles";
            Text = "FrmReporteConsumibles";
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReporte;
        private Button btnImprimir;
        private Button btnGenerarRequisicion;
    }
}