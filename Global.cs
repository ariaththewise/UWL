using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace UWL
{
    /// <summary>
    /// Métodos globales del proyecto UWL.
    /// </summary>
    class Global
    {
        #region Campos
        /// <summary>
        /// Proceso del emulador WinUAE.
        /// </summary>
        private static Process emulator;


        /// <summary>
        /// Evento que se dispara cuando se recupera información sobre
        /// la última versión del emulador.
        /// </summary>
        public static event EventHandler EmulatorLastVersionInfoRetrieved;


        /// <summary>
        /// Indica si el emulador está siendo actualizado.
        /// </summary>
        private static bool emulatorIsUpdateInProgress;


        /// <summary>
        /// URL de descarga del emulador.
        /// </summary>
        private static String emulatorURL;


        /// <summary>
        /// Última versión del emulador.
        /// </summary>
        private static String lastEmulatorVersion;


        /// <summary>
        /// Hilo de descarga de la información de la última versión
        /// del emulador.
        /// </summary>
        private static Thread versionDownload = new Thread(versionDownloadThread);


        /// <summary>
        /// Fichero INI del emulador.
        /// </summary>
        private static UAEIniFile winuaeINIFile;


        /// <summary>
        /// Cliente web.
        /// </summary>
        private static WebClient www = new WebClient();
        #endregion


        #region Propiedades
        /// <summary>
        /// Directorio de carátulas.
        /// </summary>
        public static String CoversDir
        {
            get { return (UWLDir +  "Covers" + SEP); }
        }


        /// <summary>
        /// Versión actual del emulador.
        /// </summary>
        public static String CurrentEmulatorVersion
        {
            get { return FileVersionInfo.GetVersionInfo(Emulator).FileVersion; }
        }


        /// <summary>
        /// Emulador.
        /// </summary>
        public static String Emulator
        {
            get { return (UWLDir + "WinUAE.exe"); }
        }


        /// <summary>
        /// Comprueba si el emulador está siendo actualizado.
        /// </summary>
        public static bool EmulatorIsBeingUpdated
        {
            get { return emulatorIsUpdateInProgress; }
        }


        /// <summary>
        /// URL de descarga del emulador.
        /// </summary>
        public static String EmulatorURL
        {
            get { return emulatorURL; }
        }


        /// <summary>
        /// Última versión disponible del emulador.
        /// </summary>
        public static String LastEmulatorVersion
        {
            get { return lastEmulatorVersion; }
        }


        /// <summary>
        /// Caracter de nueva línea.
        /// </summary>
        public static String NL
        {
            get { return Environment.NewLine; }
        }


        /// <summary>
        /// Directorio de screenshots.
        /// </summary>
        public static String ScreenshotsDir
        {
            get { return (UWLDir + "Captures" + SEP); }
        }


        /// <summary>
        /// Separador de directorios multiplaforma.
        /// </summary>
        public static String SEP
        {
            get { return Path.DirectorySeparatorChar.ToString(); }
        }


        /// <summary>
        /// Directorio de UWL.
        /// </summary>
        public static String UWLDir
        {
            get { return Environment.CurrentDirectory + SEP; }
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Comprueba en Internet el último número de versión
        /// disponible del emulador.
        /// </summary> 
        public static void CheckLastEmulatorVersion()
        {
            versionDownload.Start();
        }


        /// <summary>
        /// Comprueba si el emulador existe.
        /// </summary>
        public static bool emulatorExists()
        {
            return File.Exists(UWLDir + "WinUAE.exe");
        }


        /// <summary>
        /// Mantiene las rutas del emulador relativas.
        /// </summary>
        private static void keepEmulatorINIRelative()
        {
            winuaeINIFile = new UAEIniFile(UWLDir + "WinUAE.ini");

            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.FLOPPY_PATH, @".\Disks\");
            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.KICKSTART_PATH, @".\Roms\");
            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.HDF_PATH, @".\HD\");
            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.CONFIGURATION_PATH, @".\Configurations\");
            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.SCREENSHOT_PATH, @".\Screenshots\");
            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.STATEFILE_PATH, @".\Savestates\");
            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.SAVEIMAGE_PATH, @".\SaveImages\");
            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.VIDEO_PATH, @".\Videos\");
            winuaeINIFile.setEntry(UAEIniFile.WINUAE_ENTRIES.INPUT_PATH, @".\InputRecordings\");
        }


        /// <summary>
        /// Inicia el emulador con la configuración indicada.
        /// </summary>
        public static void LaunchEmulator(String config)
        {
            keepEmulatorINIRelative();
            Process.Start(Emulator, ("-f " + "\"" + config + "\""));
        }


        /// <summary>
        /// Obtiene la lista de configuraciones.
        /// </summary>
        /// <returns></returns>
        public static String[] GetConfigList()
        {
            return Directory.GetFiles((UWLDir + "Configurations"), "*.uae");
        }


        /// <summary>
        /// Hilo de descarga del número de la última versión del emulador.
        /// </summary>
        private static void versionDownloadThread()
        {
            String htmlCode;
            String emulatorPreString = "<a class=\"download1\" href=\"../files/WinUAE";
            String filename;
            String fileVersion;

            int fileLOffset, fileROffset;
            int versionLOffset, versionROffset;

            try
            {
                htmlCode = www.DownloadString(new Uri("http://www.winuae.net/frames/download.html"));
            }
            catch (Exception)
            {
                htmlCode = String.Empty;
            }

            if (htmlCode.Equals(String.Empty))
            {
                lastEmulatorVersion = "N/A";
                emulatorURL = String.Empty;
                EmulatorLastVersionInfoRetrieved(null, null);
            }
            else
            {
                fileLOffset = ((htmlCode.IndexOf(emulatorPreString) + emulatorPreString.Length) - 6);
                fileROffset = htmlCode.IndexOf("\"", fileLOffset);

                filename = htmlCode.Substring(fileLOffset, (fileROffset - fileLOffset));

                versionLOffset = 6;
                versionROffset = filename.IndexOf(".");

                fileVersion = filename.Substring(versionLOffset, (versionROffset - versionLOffset));

                lastEmulatorVersion = (fileVersion[0] + "." + fileVersion[1] + "." + fileVersion[2] + "." + fileVersion[3]);
                emulatorURL = ("http://www.winuae.net/files/WinUAE" + lastEmulatorVersion);
                EmulatorLastVersionInfoRetrieved(null, null);
            }
        }
#endregion
    }
}
