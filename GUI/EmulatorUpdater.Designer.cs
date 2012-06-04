namespace UWL.GUI
{
    partial class EmulatorUpdater
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentEmulatorVersion = new System.Windows.Forms.Label();
            this.labelLastEmulatorVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Versión actual: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Última versión: ";
            // 
            // labelCurrentEmulatorVersion
            // 
            this.labelCurrentEmulatorVersion.AutoSize = true;
            this.labelCurrentEmulatorVersion.Location = new System.Drawing.Point(116, 9);
            this.labelCurrentEmulatorVersion.Name = "labelCurrentEmulatorVersion";
            this.labelCurrentEmulatorVersion.Size = new System.Drawing.Size(35, 13);
            this.labelCurrentEmulatorVersion.TabIndex = 1;
            this.labelCurrentEmulatorVersion.Text = "label3";
            // 
            // labelLastEmulatorVersion
            // 
            this.labelLastEmulatorVersion.AutoSize = true;
            this.labelLastEmulatorVersion.Location = new System.Drawing.Point(116, 39);
            this.labelLastEmulatorVersion.Name = "labelLastEmulatorVersion";
            this.labelLastEmulatorVersion.Size = new System.Drawing.Size(35, 13);
            this.labelLastEmulatorVersion.TabIndex = 2;
            this.labelLastEmulatorVersion.Text = "label4";
            // 
            // EmulatorUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 176);
            this.Controls.Add(this.labelLastEmulatorVersion);
            this.Controls.Add(this.labelCurrentEmulatorVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmulatorUpdater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizador de WinUAE";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentEmulatorVersion;
        private System.Windows.Forms.Label labelLastEmulatorVersion;
    }
}