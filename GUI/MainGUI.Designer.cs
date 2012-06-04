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
            this.menuItemUpdateEmulator = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgCover)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listConfigs
            // 
            this.listConfigs.FormattingEnabled = true;
            this.listConfigs.Location = new System.Drawing.Point(12, 75);
            this.listConfigs.Name = "listConfigs";
            this.listConfigs.Size = new System.Drawing.Size(232, 485);
            this.listConfigs.TabIndex = 0;
            this.listConfigs.SelectedIndexChanged += new System.EventHandler(this.listConfigs_SelectedIndexChanged);
            // 
            // imgCover
            // 
            this.imgCover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgCover.Location = new System.Drawing.Point(608, 75);
            this.imgCover.Name = "imgCover";
            this.imgCover.Size = new System.Drawing.Size(320, 485);
            this.imgCover.TabIndex = 1;
            this.imgCover.TabStop = false;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUpdateEmulator});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(940, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemUpdateEmulator
            // 
            this.menuItemUpdateEmulator.Name = "menuItemUpdateEmulator";
            this.menuItemUpdateEmulator.Size = new System.Drawing.Size(137, 20);
            this.menuItemUpdateEmulator.Text = "Actualizar el emulador";
            this.menuItemUpdateEmulator.Click += new System.EventHandler(this.menuItemUpdateEmulator_Click);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 572);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listConfigs;
        private System.Windows.Forms.PictureBox imgCover;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemUpdateEmulator;
    }
}

