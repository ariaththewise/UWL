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
            this.butUpdateEmulator = new System.Windows.Forms.Button();
            this.butCancelUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarUpdate = new System.Windows.Forms.ProgressBar();
            this.labelUpdateStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Versión actual: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Última versión: ";
            // 
            // labelCurrentEmulatorVersion
            // 
            this.labelCurrentEmulatorVersion.AutoSize = true;
            this.labelCurrentEmulatorVersion.Location = new System.Drawing.Point(114, 19);
            this.labelCurrentEmulatorVersion.Name = "labelCurrentEmulatorVersion";
            this.labelCurrentEmulatorVersion.Size = new System.Drawing.Size(35, 13);
            this.labelCurrentEmulatorVersion.TabIndex = 1;
            this.labelCurrentEmulatorVersion.Text = "label3";
            // 
            // labelLastEmulatorVersion
            // 
            this.labelLastEmulatorVersion.AutoSize = true;
            this.labelLastEmulatorVersion.Location = new System.Drawing.Point(295, 19);
            this.labelLastEmulatorVersion.Name = "labelLastEmulatorVersion";
            this.labelLastEmulatorVersion.Size = new System.Drawing.Size(35, 13);
            this.labelLastEmulatorVersion.TabIndex = 2;
            this.labelLastEmulatorVersion.Text = "label4";
            // 
            // butUpdateEmulator
            // 
            this.butUpdateEmulator.Location = new System.Drawing.Point(12, 128);
            this.butUpdateEmulator.Name = "butUpdateEmulator";
            this.butUpdateEmulator.Size = new System.Drawing.Size(176, 23);
            this.butUpdateEmulator.TabIndex = 3;
            this.butUpdateEmulator.Text = "Actualizar";
            this.butUpdateEmulator.UseVisualStyleBackColor = true;
            this.butUpdateEmulator.Click += new System.EventHandler(this.butUpdateEmulator_Click);
            // 
            // butCancelUpdate
            // 
            this.butCancelUpdate.Location = new System.Drawing.Point(194, 128);
            this.butCancelUpdate.Name = "butCancelUpdate";
            this.butCancelUpdate.Size = new System.Drawing.Size(171, 23);
            this.butCancelUpdate.TabIndex = 3;
            this.butCancelUpdate.Text = "Cancelar";
            this.butCancelUpdate.UseVisualStyleBackColor = true;
            this.butCancelUpdate.Click += new System.EventHandler(this.butCancelUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado: ";
            // 
            // progressBarUpdate
            // 
            this.progressBarUpdate.Location = new System.Drawing.Point(12, 86);
            this.progressBarUpdate.Name = "progressBarUpdate";
            this.progressBarUpdate.Size = new System.Drawing.Size(353, 21);
            this.progressBarUpdate.TabIndex = 5;
            // 
            // labelUpdateStatus
            // 
            this.labelUpdateStatus.AutoSize = true;
            this.labelUpdateStatus.Location = new System.Drawing.Point(62, 51);
            this.labelUpdateStatus.Name = "labelUpdateStatus";
            this.labelUpdateStatus.Size = new System.Drawing.Size(55, 13);
            this.labelUpdateStatus.TabIndex = 6;
            this.labelUpdateStatus.Text = "En espera";
            // 
            // EmulatorUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 163);
            this.Controls.Add(this.labelUpdateStatus);
            this.Controls.Add(this.progressBarUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butCancelUpdate);
            this.Controls.Add(this.butUpdateEmulator);
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
        private System.Windows.Forms.Button butUpdateEmulator;
        private System.Windows.Forms.Button butCancelUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBarUpdate;
        private System.Windows.Forms.Label labelUpdateStatus;
    }
}