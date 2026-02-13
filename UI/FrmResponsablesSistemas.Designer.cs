namespace AppEscritorioUPT.UI
{
    partial class FrmResponsablesSistemas
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
            dgvResponsables = new DataGridView();
            btnAgregar = new Button();
            btnEliminar = new Button();
            lbAdministrativo = new Label();
            cmbAdministrativo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvResponsables).BeginInit();
            SuspendLayout();
            // 
            // dgvResponsables
            // 
            dgvResponsables.AllowUserToAddRows = false;
            dgvResponsables.AllowUserToDeleteRows = false;
            dgvResponsables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResponsables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResponsables.Location = new Point(12, 215);
            dgvResponsables.MultiSelect = false;
            dgvResponsables.Name = "dgvResponsables";
            dgvResponsables.ReadOnly = true;
            dgvResponsables.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvResponsables.Size = new Size(505, 223);
            dgvResponsables.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 160);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(95, 30);
            btnAgregar.TabIndex = 14;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Location = new Point(422, 160);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(95, 30);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lbAdministrativo
            // 
            lbAdministrativo.AutoSize = true;
            lbAdministrativo.Location = new Point(12, 24);
            lbAdministrativo.Name = "lbAdministrativo";
            lbAdministrativo.Size = new Size(85, 15);
            lbAdministrativo.TabIndex = 17;
            lbAdministrativo.Text = "Administrativo";
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(12, 42);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(505, 23);
            cmbAdministrativo.TabIndex = 18;
            // 
            // FrmResponsablesSistemas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 450);
            Controls.Add(cmbAdministrativo);
            Controls.Add(lbAdministrativo);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvResponsables);
            Name = "FrmResponsablesSistemas";
            Text = "FrmResponsablesSistemas";
            ((System.ComponentModel.ISupportInitialize)dgvResponsables).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvResponsables;
        private Button btnAgregar;
        private Button btnEliminar;
        private Label lbAdministrativo;
        private ComboBox cmbAdministrativo;
    }
}