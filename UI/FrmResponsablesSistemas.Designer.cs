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
            dgvResponsables.Location = new Point(14, 287);
            dgvResponsables.Margin = new Padding(3, 4, 3, 4);
            dgvResponsables.MultiSelect = false;
            dgvResponsables.Name = "dgvResponsables";
            dgvResponsables.ReadOnly = true;
            dgvResponsables.RowHeadersWidth = 51;
            dgvResponsables.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            dgvResponsables.Size = new Size(577, 297);
            dgvResponsables.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(14, 213);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(109, 40);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.Location = new Point(482, 213);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 40);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lbAdministrativo
            // 
            lbAdministrativo.AutoSize = true;
            lbAdministrativo.Location = new Point(14, 32);
            lbAdministrativo.Name = "lbAdministrativo";
            lbAdministrativo.Size = new Size(106, 20);
            lbAdministrativo.TabIndex = 4;
            lbAdministrativo.Text = "Administrativo";
            // 
            // cmbAdministrativo
            // 
            cmbAdministrativo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdministrativo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbAdministrativo.FormattingEnabled = true;
            cmbAdministrativo.Location = new Point(14, 56);
            cmbAdministrativo.Margin = new Padding(3, 4, 3, 4);
            cmbAdministrativo.Name = "cmbAdministrativo";
            cmbAdministrativo.Size = new Size(577, 28);
            cmbAdministrativo.TabIndex = 0;
            // 
            // FrmResponsablesSistemas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 600);
            Controls.Add(cmbAdministrativo);
            Controls.Add(lbAdministrativo);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvResponsables);
            Margin = new Padding(3, 4, 3, 4);
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