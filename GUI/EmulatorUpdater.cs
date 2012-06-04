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

            CheckForIllegalCrossThreadCalls = false;

            Global.EmulatorLastVersionInfoRetrieved += new EventHandler(Global_EmulatorLastVersionInfoRetrieved);

            labelCurrentEmulatorVersion.Text = Global.GetCurrentEmulatorVersion();
            labelLastEmulatorVersion.Text = "Comprobando ...";

            Global.GetLastEmulatorVersion();
        }


        private void Global_EmulatorLastVersionInfoRetrieved(object sender, EventArgs e)
        {
            labelLastEmulatorVersion.Text = Global.LastEmulatorVersion;
        }
    }
}
