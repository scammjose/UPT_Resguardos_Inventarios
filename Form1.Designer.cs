namespace AppEscritorioUPT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            catálogosToolStripMenuItem = new ToolStripMenuItem();
            menuAreas = new ToolStripMenuItem();
            menuTipos = new ToolStripMenuItem();
            menuAdministrativos = new ToolStripMenuItem();
            menuEquipos = new ToolStripMenuItem();
            tiposDeEquiposToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { catálogosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // catálogosToolStripMenuItem
            // 
            catálogosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuAreas, menuTipos, menuAdministrativos, menuEquipos });
            catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            catálogosToolStripMenuItem.Size = new Size(90, 24);
            catálogosToolStripMenuItem.Text = "Catálogos";
            // 
            // menuAreas
            // 
            menuAreas.Name = "menuAreas";
            menuAreas.Size = new Size(224, 26);
            menuAreas.Text = "Áreas";
            menuAreas.Click += menuAreas_Click;
            // 
            // menuTipos
            // 
            menuTipos.Name = "menuTipos";
            menuTipos.Size = new Size(224, 26);
            menuTipos.Text = "Tipos de Equipos";
            menuTipos.Click += menuTipos_Click;
            // 
            // menuAdministrativos
            // 
            menuAdministrativos.Name = "menuAdministrativos";
            menuAdministrativos.Size = new Size(224, 26);
            menuAdministrativos.Text = "Administrativos";
            menuAdministrativos.Click += menuAdministrativos_Click;
            // 
            // menuEquipos
            // 
            menuEquipos.Name = "menuEquipos";
            menuEquipos.Size = new Size(224, 26);
            menuEquipos.Text = "Equipos";
            menuEquipos.Click += menuEquipos_Click;
            // 
            // tiposDeEquiposToolStripMenuItem
            // 
            tiposDeEquiposToolStripMenuItem.Name = "tiposDeEquiposToolStripMenuItem";
            tiposDeEquiposToolStripMenuItem.Size = new Size(32, 19);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem catálogosToolStripMenuItem;
        private ToolStripMenuItem menuAreas;
        private ToolStripMenuItem tiposDeEquiposToolStripMenuItem;
        private ToolStripMenuItem menuTipos;
        private ToolStripMenuItem menuAdministrativos;
        private ToolStripMenuItem menuEquipos;
    }
}
