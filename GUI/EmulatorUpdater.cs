using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UWL.GUI
{
    public partial class EmulatorUpdater : Form
    {
        public EmulatorUpdater()
        {
            InitializeComponent();

            labelCurrentEmulatorVersion.Text = Global.GetCurrentEmulatorVersion();
            labelLastEmulatorVersion.Text = Global.LastEmulatorVersion;
        }



        #region Eventos
        /// <summary>
        /// Evento: Se pulsa el botón de cancelar.
        /// </summary>        
        private void butCancelUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Evento: Se pulsa el botón de actualizar.
        /// </summary>
        private void butUpdateEmulator_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
