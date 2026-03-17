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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            catálogosToolStripMenuItem = new ToolStripMenuItem();
            menuAreas = new ToolStripMenuItem();
            menuTipos = new ToolStripMenuItem();
            menuAdministrativos = new ToolStripMenuItem();
            menuEquipos = new ToolStripMenuItem();
            menuResponsablesSistemas = new ToolStripMenuItem();
            menuEdificios = new ToolStripMenuItem();
            menuTiposMantenimiento = new ToolStripMenuItem();
            menuLaboratorios = new ToolStripMenuItem();
            menuResguardos = new ToolStripMenuItem();
            menuRegistrarResguardo = new ToolStripMenuItem();
            menuPorAdministrativo = new ToolStripMenuItem();
            menuEstadisticos = new ToolStripMenuItem();
            mantenimientosToolStripMenuItem = new ToolStripMenuItem();
            menuAsignarCheckList = new ToolStripMenuItem();
            asignarCheckListPorÁreaToolStripMenuItem = new ToolStripMenuItem();
            historialYEdiciónDeMantenimientosToolStripMenuItem = new ToolStripMenuItem();
            checkLisDeMantenimientosToolStripMenuItem = new ToolStripMenuItem();
            generarCheckListPorAdministrativoToolStripMenuItem = new ToolStripMenuItem();
            generarCheckListPorÁreaToolStripMenuItem = new ToolStripMenuItem();
            menuMantenimientosAulas = new ToolStripMenuItem();
            menuGenerarCheckListLaboratorios = new ToolStripMenuItem();
            tiposDeEquiposToolStripMenuItem = new ToolStripMenuItem();
            consultarEquiposToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { catálogosToolStripMenuItem, menuResguardos, mantenimientosToolStripMenuItem, checkLisDeMantenimientosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(700, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // catálogosToolStripMenuItem
            // 
            catálogosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuAreas, menuTipos, menuAdministrativos, menuEquipos, menuResponsablesSistemas, menuEdificios, menuTiposMantenimiento, menuLaboratorios, consultarEquiposToolStripMenuItem });
            catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            catálogosToolStripMenuItem.Size = new Size(72, 20);
            catálogosToolStripMenuItem.Text = "Catálogos";
            // 
            // menuAreas
            // 
            menuAreas.Name = "menuAreas";
            menuAreas.Size = new Size(210, 22);
            menuAreas.Text = "Áreas";
            menuAreas.Click += menuAreas_Click;
            // 
            // menuTipos
            // 
            menuTipos.Name = "menuTipos";
            menuTipos.Size = new Size(210, 22);
            menuTipos.Text = "Tipos de Equipos";
            menuTipos.Click += menuTipos_Click;
            // 
            // menuAdministrativos
            // 
            menuAdministrativos.Name = "menuAdministrativos";
            menuAdministrativos.Size = new Size(210, 22);
            menuAdministrativos.Text = "Administrativos";
            menuAdministrativos.Click += menuAdministrativos_Click;
            // 
            // menuEquipos
            // 
            menuEquipos.Name = "menuEquipos";
            menuEquipos.Size = new Size(210, 22);
            menuEquipos.Text = "Equipos";
            menuEquipos.Click += menuEquipos_Click;
            // 
            // menuResponsablesSistemas
            // 
            menuResponsablesSistemas.Name = "menuResponsablesSistemas";
            menuResponsablesSistemas.Size = new Size(210, 22);
            menuResponsablesSistemas.Text = "Responsables de Sistemas";
            menuResponsablesSistemas.Click += menuResponsablesSistemas_Click;
            // 
            // menuEdificios
            // 
            menuEdificios.Name = "menuEdificios";
            menuEdificios.Size = new Size(210, 22);
            menuEdificios.Text = "Edificios";
            menuEdificios.Click += menuEdificios_Click;
            // 
            // menuTiposMantenimiento
            // 
            menuTiposMantenimiento.Name = "menuTiposMantenimiento";
            menuTiposMantenimiento.Size = new Size(210, 22);
            menuTiposMantenimiento.Text = "Tipos de Mantenimientos";
            menuTiposMantenimiento.Click += menuTiposMantenimiento_Click;
            // 
            // menuLaboratorios
            // 
            menuLaboratorios.Name = "menuLaboratorios";
            menuLaboratorios.Size = new Size(210, 22);
            menuLaboratorios.Text = "Laboratorios";
            menuLaboratorios.Click += menuLaboratorios_Click;
            // 
            // menuResguardos
            // 
            menuResguardos.DropDownItems.AddRange(new ToolStripItem[] { menuRegistrarResguardo, menuPorAdministrativo, menuEstadisticos });
            menuResguardos.Name = "menuResguardos";
            menuResguardos.Size = new Size(80, 20);
            menuResguardos.Text = "Resguardos";
            // 
            // menuRegistrarResguardo
            // 
            menuRegistrarResguardo.Name = "menuRegistrarResguardo";
            menuRegistrarResguardo.Size = new Size(196, 22);
            menuRegistrarResguardo.Text = "Registrar un Resguardo";
            menuRegistrarResguardo.Click += menuRegistrarResguardo_Click;
            // 
            // menuPorAdministrativo
            // 
            menuPorAdministrativo.Name = "menuPorAdministrativo";
            menuPorAdministrativo.Size = new Size(196, 22);
            menuPorAdministrativo.Text = "Por Administrativo";
            menuPorAdministrativo.Click += menuPorAdministrativo_Click;
            // 
            // menuEstadisticos
            // 
            menuEstadisticos.Name = "menuEstadisticos";
            menuEstadisticos.Size = new Size(196, 22);
            menuEstadisticos.Text = "Estadísticos";
            menuEstadisticos.Click += menuEstadisticos_Click;
            // 
            // mantenimientosToolStripMenuItem
            // 
            mantenimientosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuAsignarCheckList, asignarCheckListPorÁreaToolStripMenuItem, historialYEdiciónDeMantenimientosToolStripMenuItem });
            mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            mantenimientosToolStripMenuItem.Size = new Size(106, 20);
            mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            // 
            // menuAsignarCheckList
            // 
            menuAsignarCheckList.Name = "menuAsignarCheckList";
            menuAsignarCheckList.Size = new Size(275, 22);
            menuAsignarCheckList.Text = "Asignar Mantenimiento Por Lote";
            menuAsignarCheckList.Click += asignarCheckListToolStripMenuItem_Click;
            // 
            // asignarCheckListPorÁreaToolStripMenuItem
            // 
            asignarCheckListPorÁreaToolStripMenuItem.Name = "asignarCheckListPorÁreaToolStripMenuItem";
            asignarCheckListPorÁreaToolStripMenuItem.Size = new Size(275, 22);
            asignarCheckListPorÁreaToolStripMenuItem.Text = "Asignar Mantenimiento Por Área";
            asignarCheckListPorÁreaToolStripMenuItem.Click += asignarCheckListPorÁreaToolStripMenuItem_Click;
            // 
            // historialYEdiciónDeMantenimientosToolStripMenuItem
            // 
            historialYEdiciónDeMantenimientosToolStripMenuItem.Name = "historialYEdiciónDeMantenimientosToolStripMenuItem";
            historialYEdiciónDeMantenimientosToolStripMenuItem.Size = new Size(275, 22);
            historialYEdiciónDeMantenimientosToolStripMenuItem.Text = "Historial y Edición de Mantenimientos";
            historialYEdiciónDeMantenimientosToolStripMenuItem.Click += historialYEdiciónDeMantenimientosToolStripMenuItem_Click;
            // 
            // checkLisDeMantenimientosToolStripMenuItem
            // 
            checkLisDeMantenimientosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarCheckListPorAdministrativoToolStripMenuItem, generarCheckListPorÁreaToolStripMenuItem, menuMantenimientosAulas, menuGenerarCheckListLaboratorios });
            checkLisDeMantenimientosToolStripMenuItem.Name = "checkLisDeMantenimientosToolStripMenuItem";
            checkLisDeMantenimientosToolStripMenuItem.Size = new Size(176, 20);
            checkLisDeMantenimientosToolStripMenuItem.Text = "CheckList de Mantenimientos";
            // 
            // generarCheckListPorAdministrativoToolStripMenuItem
            // 
            generarCheckListPorAdministrativoToolStripMenuItem.Name = "generarCheckListPorAdministrativoToolStripMenuItem";
            generarCheckListPorAdministrativoToolStripMenuItem.Size = new Size(344, 22);
            generarCheckListPorAdministrativoToolStripMenuItem.Text = "Generar CheckList por Administrativo";
            generarCheckListPorAdministrativoToolStripMenuItem.Click += generarCheckListPorAdministrativoToolStripMenuItem_Click;
            // 
            // generarCheckListPorÁreaToolStripMenuItem
            // 
            generarCheckListPorÁreaToolStripMenuItem.Name = "generarCheckListPorÁreaToolStripMenuItem";
            generarCheckListPorÁreaToolStripMenuItem.Size = new Size(344, 22);
            generarCheckListPorÁreaToolStripMenuItem.Text = "Generar CheckList por Área";
            generarCheckListPorÁreaToolStripMenuItem.Click += generarCheckListPorÁreaToolStripMenuItem_Click;
            // 
            // menuMantenimientosAulas
            // 
            menuMantenimientosAulas.Name = "menuMantenimientosAulas";
            menuMantenimientosAulas.Size = new Size(344, 22);
            menuMantenimientosAulas.Text = "Generar CheckList Mantenimientos de Aulas";
            menuMantenimientosAulas.Click += menuMantenimientosAulas_Click;
            // 
            // menuGenerarCheckListLaboratorios
            // 
            menuGenerarCheckListLaboratorios.Name = "menuGenerarCheckListLaboratorios";
            menuGenerarCheckListLaboratorios.Size = new Size(344, 22);
            menuGenerarCheckListLaboratorios.Text = "Generar CheckList Mantenimientos de Laboratorios";
            menuGenerarCheckListLaboratorios.Click += menuGenerarCheckListLaboratorios_Click;
            // 
            // tiposDeEquiposToolStripMenuItem
            // 
            tiposDeEquiposToolStripMenuItem.Name = "tiposDeEquiposToolStripMenuItem";
            tiposDeEquiposToolStripMenuItem.Size = new Size(32, 19);
            // 
            // consultarEquiposToolStripMenuItem
            // 
            consultarEquiposToolStripMenuItem.Name = "consultarEquiposToolStripMenuItem";
            consultarEquiposToolStripMenuItem.Size = new Size(210, 22);
            consultarEquiposToolStripMenuItem.Text = "Consultar Equipos";
            consultarEquiposToolStripMenuItem.Click += consultarEquiposToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
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
        private ToolStripMenuItem menuResguardos;
        private ToolStripMenuItem menuResponsablesSistemas;
        private ToolStripMenuItem menuRegistrarResguardo;
        private ToolStripMenuItem menuPorAdministrativo;
        private ToolStripMenuItem menuEstadisticos;
        private ToolStripMenuItem mantenimientosToolStripMenuItem;
        private ToolStripMenuItem menuAsignarCheckList;
        private ToolStripMenuItem asignarCheckListPorÁreaToolStripMenuItem;
        private ToolStripMenuItem historialYEdiciónDeMantenimientosToolStripMenuItem;
        private ToolStripMenuItem checkLisDeMantenimientosToolStripMenuItem;
        private ToolStripMenuItem generarCheckListPorAdministrativoToolStripMenuItem;
        private ToolStripMenuItem generarCheckListPorÁreaToolStripMenuItem;
        private ToolStripMenuItem menuEdificios;
        private ToolStripMenuItem menuMantenimientosAulas;
        private ToolStripMenuItem menuTiposMantenimiento;
        private ToolStripMenuItem menuLaboratorios;
        private ToolStripMenuItem menuGenerarCheckListLaboratorios;
        private ToolStripMenuItem consultarEquiposToolStripMenuItem;
    }
}
