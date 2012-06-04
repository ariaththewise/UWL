using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// Archivo de configuración de WinUAE.
/// </summary>
class UAEIniFile : INIFile
{
    /// <summary>
    /// Entradas del archivo.
    /// </summary>
    public struct WINUAE_ENTRIES
    {
        public const String PATHMODE = "PathMode";
        public const String FLOPPY_PATH = "FloppyPath";
        public const String KICKSTART_PATH = "KickstartPath";
        public const String HDF_PATH = "hdfPath";
        public const String CONFIGURATION_PATH = "ConfigurationPath";
        public const String SCREENSHOT_PATH = "ScreenshotPath";
        public const String STATEFILE_PATH = "StatefilePath";
        public const String SAVEIMAGE_PATH = "SaveimagePath";
        public const String VIDEO_PATH = "VideoPath";
        public const String INPUT_PATH = "InputPath";
        public const String MAINPOS_X = "MainPosX";
        public const String MAINPOS_Y = "MainPosY";
        public const String GUIPOS_X = "GUIPosX";
        public const String GUIPOS_Y = "GUIPosY";
        public const String VERSION = "Version";
        public const String ROM_CHECK_VERSION = "ROMCheckVersion";
        public const String SOUND_DRIVER_MASK = "SoundDriverMask";
        public const String CONFIGURATION_CACHE = "ConfigurationCache";
        public const String RELATIVE_PATHS = "RelativePaths";
        public const String QUICK_START_MODEL = "QuickStartModel";
        public const String QUICK_START_CONFIGURATION = "QuickStartConfiguration";
        public const String QUICK_START_COMPATIBILITY = "QuickStartCompatibility";
        public const String CONFIG_FILE = "ConfigFile";
        public const String FLOPPY_PATH_FILTER = "FloppyPath_Filter";
    }



    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="uaeINIPath">Ruta al archivo WinUAE.ini</param>
    public UAEIniFile(String uaeINIPath)
        : base(uaeINIPath)
    {

    }


    /// <summary>
    /// Obtiene el valor asociado a la entrada indicada.
    /// </summary>
    /// <param name="uaeINIEntry">Entrada.</param>    
    public String getEntry(String uaeINIEntry)
    {
        return this.readValue("WinUAE", uaeINIEntry);
    }


    /// <summary>
    /// Establece el valor a la entrada indicada.
    /// </summary>
    /// <param name="uaeINIEntry">Entrada.</param>
    /// <param name="value">Valor.</param>
    public void setEntry(String uaeINIEntry, String value)
    {
        this.writeValue("WinUAE", uaeINIEntry, value);
    }    
}