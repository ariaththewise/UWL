using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UWL.GUI
{
    /// <summary>
    /// Ventana principal del lanzador.
    /// </summary>
    public partial class MainGUI : Form
    {
        #region Campos
        private List<String> configList;
        private List<String> configListToShow;
        private String selectedConfigEntry;
        #endregion


        
        public MainGUI()
        {
            InitializeComponent();

            Global.EmulatorLastVersionInfoRetrieved += new EventHandler(EmulatorLastVersionInfoRetrieved);

            configList = new List<String>();
            configListToShow = new List<String>();

            loadConfigList();
            listConfigs.Items.AddRange(configListToShow.ToArray());

            Global.GetLastEmulatorVersion();
        }


        #region Eventos
        private void EmulatorLastVersionInfoRetrieved(object sender, EventArgs e)
        {
            Version currentEmulatorVersion = new Version(Global.GetCurrentEmulatorVersion());
            Version lastEmulatorVersion = new Version(Global.LastEmulatorVersion);

            if (currentEmulatorVersion.CompareTo(lastEmulatorVersion) < 0)
            {
                MessageBox.Show("Hay una versión más actual del emulador." +
                                 Global.NL +
                                "Puedes actualizarlo desde el menú del lanzador.");
            }
        }


        /// <summary>
        /// Evento: Se selecciona una entrada de la lista de configuraciones
        /// </summary>
        private void listConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedConfigEntry = configListToShow[listConfigs.SelectedIndex];
            imgCover.ImageLocation = getCover(selectedConfigEntry);
        }


        /// <summary>
        /// Evento: Se pulsa el menu item para actualizar el emulador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItemUpdateEmulator_Click(object sender, EventArgs e)
        {
            new EmulatorUpdater().Show();
        }
        #endregion


        /// <summary>
        /// Carga las listas de configuración.
        /// </summary>
        private void loadConfigList()
        {
            configList.AddRange(Directory.GetFiles((Global.UWLDir + Global.SEP + "Configurations"), "*.uae"));
            
            configListToShow.AddRange(configList);
            
            for (int e = 0; e < configList.Count; e ++)
            {
                configListToShow[e] = configListToShow[e].Substring(configListToShow[e].LastIndexOf("\\") + 1).Replace(".uae", "");
            }
        }


        /// <summary>
        /// Obtiene la carátula de la entrada seleccionada
        /// en la lista de configuraciones..
        /// </summary>
        /// <param name="configEntry">Nombre del elemento cuya
        /// carátula se busca</param>
        /// 
        /// <returns>La imagen de la carátula o una
        /// cadena vacía</returns>
        private String getCover(String configEntry)
        {
            if (File.Exists(Global.CoversDir + configEntry + ".gif"))
            {
                return Global.CoversDir + configEntry + ".gif";
            }
            else if (File.Exists(Global.CoversDir + configEntry + ".jpg"))
            {
                return Global.CoversDir + configEntry + ".jpg";
            }

            return String.Empty;
        }
    }
}
