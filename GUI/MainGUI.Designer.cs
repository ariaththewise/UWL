namespace UWL.GUI
{
    partial class MainGUI
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listConfigs = new System.Windows.Forms.ListBox();
            this.imgCover = new System.Windows.Forms.PictureBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLaunchThisConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEditThisConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUpdateEmulator = new System.Windows.Forms.ToolStripMenuItem();
            this.verLaAyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressCheckingLastVersion = new System.Windows.Forms.ToolStripProgressBar();
            this.labelNewVersionAvailable = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imgCover)).BeginInit();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listConfigs
            // 
            this.listConfigs.FormattingEnabled = true;
            this.listConfigs.Location = new System.Drawing.Point(12, 47);
            this.listConfigs.Name = "listConfigs";
            this.listConfigs.Size = new System.Drawing.Size(232, 485);
            this.listConfigs.TabIndex = 0;
            this.listConfigs.SelectedIndexChanged += new System.EventHandler(this.listConfigs_SelectedIndexChanged);
            // 
            // imgCover
            // 
            this.imgCover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgCover.Location = new System.Drawing.Point(608, 47);
            this.imgCover.Name = "imgCover";
            this.imgCover.Size = new System.Drawing.Size(320, 485);
            this.imgCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCover.TabIndex = 1;
            this.imgCover.TabStop = false;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(940, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLaunchThisConfig,
            this.menuItemEditThisConfig,
            this.menuItemExit});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // menuItemLaunchThisConfig
            // 
            this.menuItemLaunchThisConfig.Name = "menuItemLaunchThisConfig";
            this.menuItemLaunchThisConfig.Size = new System.Drawing.Size(217, 22);
            this.menuItemLaunchThisConfig.Text = "Ejecutar esta configuración";
            this.menuItemLaunchThisConfig.Click += new System.EventHandler(this.menuItemLaunchThisConfig_Click);
            // 
            // menuItemEditThisConfig
            // 
            this.menuItemEditThisConfig.Name = "menuItemEditThisConfig";
            this.menuItemEditThisConfig.Size = new System.Drawing.Size(217, 22);
            this.menuItemEditThisConfig.Text = "Editar esta configuración";
            this.menuItemEditThisConfig.Click += new System.EventHandler(this.menuItemEditThisConfig_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(217, 22);
            this.menuItemExit.Text = "Salir";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUpdateEmulator,
            this.verLaAyudaToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // menuItemUpdateEmulator
            // 
            this.menuItemUpdateEmulator.Enabled = false;
            this.menuItemUpdateEmulator.Name = "menuItemUpdateEmulator";
            this.menuItemUpdateEmulator.Size = new System.Drawing.Size(192, 22);
            this.menuItemUpdateEmulator.Text = "Actualizar el emulador";
            this.menuItemUpdateEmulator.Click += new System.EventHandler(this.menuItemUpdateEmulator_Click);
            // 
            // verLaAyudaToolStripMenuItem
            // 
            this.verLaAyudaToolStripMenuItem.Name = "verLaAyudaToolStripMenuItem";
            this.verLaAyudaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.verLaAyudaToolStripMenuItem.Text = "Ver la ayuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.sobreToolStripMenuItem.Text = "Sobre ...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressCheckingLastVersion,
            this.labelNewVersionAvailable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(940, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressCheckingLastVersion
            // 
            this.progressCheckingLastVersion.Name = "progressCheckingLastVersion";
            this.progressCheckingLastVersion.Size = new System.Drawing.Size(100, 16);
            this.progressCheckingLastVersion.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // labelNewVersionAvailable
            // 
            this.labelNewVersionAvailable.Name = "labelNewVersionAvailable";
            this.labelNewVersionAvailable.Size = new System.Drawing.Size(279, 17);
            this.labelNewVersionAvailable.Text = "Comprobando si hay nueva versión del emulador... ";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 572);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.imgCover);
            this.Controls.Add(this.listConfigs);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menu;
            this.Name = "MainGUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultimate Winuae Launcher";
            ((System.ComponentModel.ISupportInitialize)(this.imgCover)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listConfigs;
        private System.Windows.Forms.PictureBox imgCover;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressCheckingLastVersion;
        private System.Windows.Forms.ToolStripStatusLabel labelNewVersionAvailable;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verLaAyudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemLaunchThisConfig;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditThisConfig;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemUpdateEmulator;
    }
}

