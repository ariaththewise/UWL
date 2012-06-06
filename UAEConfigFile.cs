using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


/// <summary>
/// [ORDENAR]
/// 
/// Esta clase representa un archivo de configuración UAE.
/// 
/// Estos archivos contienen la configuración del emulador de Amiga
/// UAE y todos sus ports (E-UAE, WinUAE, UAE4All, etc ...) .
/// </summary>
class UAEConfigFile
{
    #region Estructuras.
    /// <summary>
    /// Estructura para acceder a diversos campos de un archivo
    /// de configuración UAE.
    /// </summary>
    public struct CONFIG
    {
        public const String CHIPSET = "chipset";

        public const String FLOPPY_0__DISK = "floppy0";
        public const String FLOPPY_0__TYPE = "floppy0type";
        public const String FLOPPY_0__SOUND = "floppy0sound";

        public const String FLOPPY_1__DISK = "floppy1";
        public const String FLOPPY_1__TYPE = "floppy1type";
        public const String FLOPPY_1__SOUND = "floppy1sound";

        public const String FLOPPY_2__DISK = "floppy2";
        public const String FLOPPY_2__TYPE = "floppy2type";
        public const String FLOPPY_2__SOUND = "floppy2sound";

        public const String FLOPPY_3__DISK = "floppy3";
        public const String FLOPPY_3__TYPE = "floppy3type";
        public const String FLOPPY_3__SOUND = "floppy3sound";

        public const String FLOPPY_DRIVES = "nr_floppies";            

        
        public const String WINDOWED_WIDTH_RES = "gfx_width_windowed";
        public const String WINDOWED_HEIGHT_RES = "gfx_height_windowed";

        public const String FULLSCREEN_WIDTH_RES = "gfx_width_fullscreen";
        public const String FULLSCREEN_HEIGHT_RES = "gfx_height_fullscreen";

        public const String FULLSCREEN_VSYNC = "gfx_vsync";
        public const String FULLSCREEN_PICASSO_VSYNC = "gfx_vsync_picasso";
        public const String FULLSCREEN_COLOUR_MODE = "gfx_colour_mode";
        public const String FULLSCREEN = "gfx_fullscreen_amiga";


        public const String GAMEPORT_1 = "joyport0";
        public const String GAMEPORT_2 = "joyport1";

        public const String MAP_PC_DRIVES = "win32.map_drives";
        public const String MAP_PC_DRIVES_AUTO = "win32.map_drives_auto";
        public const String MAP_PC_CDROM = "win32.map_cd_drives";
        public const String MAP_PC_NETDRIVES = "win32.map_net_drives";
        public const String MAP_PC_USBDRIVES = "win32.map_removable_drives";

        public const String LEDS = "show_leds";
        public const String LEDS_RTG = "show_leds_rtg";

        public const String KICKSTART_ROM_FILE = "kickstart_rom_file";

        public const String USE_GUI = "use_gui";
    }


    /// <summary>
    /// Esta estructura contiene los posibles chipsets.
    /// </summary>
    public struct CHIPSET
    {
        public const String AGA = "aga";            
        public const String ECS = "ecs";
        public const String OCS = "ocs";
    }


    /// <summary>
    /// Esta estructura contiene los posibles modos de
    /// color.
    /// </summary>
    public struct COLOUR_MODE
    {
        public const String DEPTH_16BIT = "16bit";
        public const String DEPTH_32BIT = "32bit";
    }


    /// <summary>
    /// Esta estructura contiene las posibles opciones a usar
    /// al configurar una unidad de disquette (Floppy).
    /// </summary>
    public struct FLOPPY
    {
        public const String DEFAULT_DISK1 = "1.adf";
        public const String DEFAULT_DISK2 = "2.adf";
        public const String DEFAULT_DISK3 = "3.adf";
        public const String DEFAULT_DISK4 = "4.adf";

        public const String EMPTY_FLOPPY = "";


        public const String ENABLED_FLOPPY = "0";
        public const String DISABLED_FLOPPY = "-1";

        public const String ENABLED_SOUND = "0";
        public const String DISABLED_SOUND = "-1";
    }


    /// <summary>
    /// Esta estructura contiene las posibles resoluciones
    /// a usar en modo de pantalla completa.
    /// </summary>
    public struct FULLSCREEN_RESOLUTION
    {
        public const String W_640__H_480 = "640x480";
        public const String W_720__H_480 = "720x480";
        public const String W_720__H_576 = "720x576";
        public const String W_800__H_600 = "800x600";
        public const String W_1024__H_768 = "1024x768";
        public const String W_1152__H_864 = "1152x864";
        public const String W_1280__H_720 = "1280x720";
        public const String W_1280__H_768 = "1280x768";
        public const String W_1280__H_800 = "1280x800";
        public const String W_1280__H_960 = "1280x960";
        public const String W_1280__H_1024 = "1280x1024";
    }


    /// <summary>
    /// Esta estructura contiene las posibles opciones a usar
    /// en los gameports (puertos de juego) del Amiga.
    /// </summary>
    public struct GAMEPORT
    {
        public const String NONE = "none";
        public const String NUMKEYPAD__0_5_FIRES = "kbd1";
        public const String CURSOR__RCTRL_ALT_FIRES = "kbd2";
        public const String WASD__LALT_FIRES = "kbd3";
        public const String XARCADE_LEFT = "kbd4";
        public const String XARCADE_RIGHT = "kbd5";
        public const String MOUSE = "mouse";
        public const String JOYSTICK_0 = "joy0";
        public const String JOYSTICK_1 = "joy1";
    };
    #endregion



    #region Campos y propiedades.
    /// <summary>
    /// Buffer donde queda almacenado el contenido del
    /// archivo de configuración UAE cargado en el constructor.
    /// </summary>
    private String[] configData;


    /// <summary>
    /// Ruta donde reside el archivo de configuración
    /// UAE a cargar en el constructor.
    /// </summary>
    private String uaeConfigPath;
    #endregion



    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="uaeConfigPath">Ruta del archivo de configuración
    /// UAE a cargar.</param>
    public UAEConfigFile(String uaeConfigPath)
    {
        this.uaeConfigPath = uaeConfigPath;
        this.configData = File.ReadAllLines(uaeConfigPath);
    }



    #region Métodos.
    /// <summary>
    /// Comprueba si la disquettera indicada está habilitada.
    /// </summary>
    /// <param name="drive">Disquetera (1-4).</param>
    public bool IsFloppyDriveEnabled(int drive)
    {
        int driveState;

        switch (drive)
        {
            case 1:
                driveState = int.Parse(getOption(CONFIG.FLOPPY_0__TYPE));
                break;

            case 2:
                driveState = int.Parse(getOption(CONFIG.FLOPPY_1__TYPE));
                break;

            case 3:
                driveState = int.Parse(getOption(CONFIG.FLOPPY_2__TYPE));
                break;

            case 4:
                driveState = int.Parse(getOption(CONFIG.FLOPPY_3__TYPE));
                break;

            default:
                return false;
        }


        if (driveState == 0)
        {
            return true;
        }
        else if (driveState == -1)
        {
            return false;
        }

        return false;
    }


    /// <summary>
    /// Comprueba si la disquettera indicada está habilitada.
    /// </summary>
    /// <param name="drive">Disquetera (1-4).</param>
    public bool IsFloppyDriveSoundEnabled(int drive)
    {
        int driveState;

        switch (drive)
        {
            case 1:
                driveState = int.Parse(getOption(CONFIG.FLOPPY_0__SOUND));
                break;

            case 2:
                driveState = int.Parse(getOption(CONFIG.FLOPPY_1__SOUND));
                break;

            case 3:
                driveState = int.Parse(getOption(CONFIG.FLOPPY_2__SOUND));
                break;

            case 4:
                driveState = int.Parse(getOption(CONFIG.FLOPPY_3__SOUND));
                break;

            default:
                return false;
        }


        if (driveState == 0)
        {
            return true;
        }
        else if (driveState == -1)
        {
            return false;
        }

        return false;
    }


    /// <summary>
    /// Comprueba si está activo el modo de pantalla completa.
    /// </summary>
    /// <returns>Estado del modo de pantalla completa.</returns>
    public bool IsFullscreen()
    {
        return bool.Parse(getOption(CONFIG.FULLSCREEN));
    }


    /// <summary>
    /// Obtiene el estado actual de los LEDs de estado de la emulación.
    /// </summary>
    /// <returns>Estado de los LEDs.</returns>
    public bool AreLedsEnabled()
    {
        return bool.Parse(getOption(CONFIG.LEDS));
    }


    /// <summary>
    /// Obtiene la profundidad actual de color (bits).
    /// </summary>    
    public int ColourDepth()
    {
        switch (getOption(CONFIG.FULLSCREEN_COLOUR_MODE))
        {
            case COLOUR_MODE.DEPTH_16BIT:
                return 0;

            case COLOUR_MODE.DEPTH_32BIT:
                return 1;

            default:
                return -1;
        }
    }


    /// <summary>
    /// Obtiene el número de disqueteras actualmente
    /// en uso (conectadas).
    /// </summary>
    /// <returns></returns>
    public int FloppysInUse()
    {
        return int.Parse(getOption(CONFIG.FLOPPY_DRIVES));
    }


    /// <summary>
    /// Obtiene el dispositivo conectado al puerto indicado.
    /// </summary>
    /// <param name="port">Puerto.</param>
    /// <returns>Dispositivo conectado.</returns>
    public int Gameport(int port)
    {
        String gameport;

        if (port == 1)
        {
            gameport = CONFIG.GAMEPORT_1;
        }
        else
        {
            gameport = CONFIG.GAMEPORT_2;
        }

        switch (getOption(gameport))
        {
            case GAMEPORT.NONE:
                return 0;

            case GAMEPORT.NUMKEYPAD__0_5_FIRES:
                return 1;

            case GAMEPORT.CURSOR__RCTRL_ALT_FIRES:
                return 2;

            case GAMEPORT.WASD__LALT_FIRES:
                return 3;

            case GAMEPORT.XARCADE_LEFT:
                return 4;

            case GAMEPORT.XARCADE_RIGHT:
                return 5;

            case GAMEPORT.MOUSE:
                return 6;

            case GAMEPORT.JOYSTICK_0:
                return 7;

            case GAMEPORT.JOYSTICK_1:
                return 7;

            default:
                return -1;
        }
    }


    /// <summary>
    /// Obtiene el modo de inicio de la interfaz del
    /// emulador (activada o desactivada).
    /// </summary>        
    public bool IsGUIActivaded()
    {
        if (getOption(CONFIG.USE_GUI) == "yes")
        {
            return true;
        }

        return false;
    }


    /// <summary>
    /// Obtiene el disquette insertado en la disquettera indicada.
    /// </summary>
    /// <param name="drive">Disquetera (1-4).</param>
    public String GetInsertedFloppy(int drive)
    {
        switch (drive)
        {
            case 1:
                return getOption(CONFIG.FLOPPY_0__DISK);

            case 2:
                return getOption(CONFIG.FLOPPY_1__DISK);

            case 3:
                return getOption(CONFIG.FLOPPY_2__DISK);

            case 4:
                return getOption(CONFIG.FLOPPY_3__DISK);

            default:
                return FLOPPY.EMPTY_FLOPPY;
        }
    }


    /// <summary>
    /// Obtiene la Kickstart ROM en uso.
    /// </summary>        
    public String GetKickstartRomFile()
    {
        return getOption(CONFIG.KICKSTART_ROM_FILE);
    }


    /// <summary>
    /// Obtiene la resolución actual a pantalla completa.
    /// </summary>
    /// <returns></returns>
    public String GetFullscreenResolution()
    {
        return (getOption(CONFIG.FULLSCREEN_WIDTH_RES) + "x" +
                getOption(CONFIG.FULLSCREEN_HEIGHT_RES));
    }


    /// <summary>
    /// Comprueba si está activa la sincronización vertical en 
    /// el modo de pantalla completa.
    /// </summary>
    /// <returns>Estado de la sincronización vertical.</returns>
    public bool IsFullscreenVsyncEnabled()
    {
        if ((bool.Parse(getOption(CONFIG.FULLSCREEN_VSYNC))) &&
           (bool.Parse(getOption(CONFIG.FULLSCREEN_PICASSO_VSYNC))))
        {
            return true;
        }
        else
        {
            return false;
        }            
    }


    /// <summary>
    /// Obtiene el estado del mapeo de las unidades de Windows
    /// en el Amiga.
    /// </summary>        
    public bool AreWindowsDrivesEnabled()
    {
        return (bool.Parse(getOption(CONFIG.MAP_PC_DRIVES)) &&
                bool.Parse(getOption(CONFIG.MAP_PC_DRIVES_AUTO)) &&
                bool.Parse(getOption(CONFIG.MAP_PC_CDROM)) &&
                bool.Parse(getOption(CONFIG.MAP_PC_NETDRIVES)) &&
                bool.Parse(getOption(CONFIG.MAP_PC_USBDRIVES)));
    }


    /// <summary>
    /// Obtiene la resolución actual en modo ventana.
    /// </summary>
    /// <returns></returns>
    public String[] GetWindowedResolution()
    {
        String[] resolution = new String[2];

        resolution[0] = getOption(CONFIG.WINDOWED_WIDTH_RES);
        resolution[1] = getOption(CONFIG.WINDOWED_HEIGHT_RES);

        return resolution;
    }



    /// <summary>
    /// Establece el chipset a usar.
    /// </summary>
    /// <param name="chipset">Chipset.</param>
    public void SetChipset(String chipset)
    {
        setOption(CONFIG.CHIPSET, chipset);
    }


    /// <summary>
    /// Establece la profundidad de color.
    /// </summary>
    /// <param name="depth">Profundidad de color.</param>
    public void SetColourDepth(String depth)
    {
        setOption(CONFIG.FULLSCREEN_COLOUR_MODE, depth);
    }


    /// <summary>
    /// Inserta el disquette indicado en una de las 4 disquetteras.
    /// </summary>
    /// <param name="drive">Disquetera (1-4).</param>
    /// <param name="diskFile">Disquette.</param>
    public void SetFloppyDisk(int drive, String diskFile)
    {
        switch (drive)
        {
            case 1:
                setOption(CONFIG.FLOPPY_0__DISK, diskFile);
                setOption(CONFIG.FLOPPY_0__TYPE, FLOPPY.ENABLED_FLOPPY);
                setOption(CONFIG.FLOPPY_DRIVES, "1");
                break;

            case 2:
                setOption(CONFIG.FLOPPY_1__DISK, diskFile);
                setOption(CONFIG.FLOPPY_1__TYPE, FLOPPY.ENABLED_FLOPPY);
                setOption(CONFIG.FLOPPY_DRIVES, "2");
                break;

            case 3:
                setOption(CONFIG.FLOPPY_2__DISK, diskFile);
                setOption(CONFIG.FLOPPY_2__TYPE, FLOPPY.ENABLED_FLOPPY);
                setOption(CONFIG.FLOPPY_DRIVES, "3");
                break;

            case 4:
                setOption(CONFIG.FLOPPY_3__DISK, diskFile);
                setOption(CONFIG.FLOPPY_3__TYPE, FLOPPY.ENABLED_FLOPPY);
                setOption(CONFIG.FLOPPY_DRIVES, "4");
                break;

            default:
                break;
        }
    }


    /// <summary>
    /// Activa/Desactiva el modo de pantalla completa.
    /// </summary>
    /// <param name="fullscreen">Estado del modo de pantalla completa.</param>
    public void SetFullscreen(bool fullscreen)
    {
        setOption(CONFIG.FULLSCREEN, fullscreen.ToString().ToLower());
    }


    /// <summary>
    /// Establece la resolución del modo de pantalla completa.
    /// </summary>
    /// <param name="resolution">Resolución a establecer "AnchoxAlto".</param>
    public void SetFullscreenResolution(String resolution)
    {
        String[] fullscreenResolution = resolution.Split('x');

        setOption(CONFIG.FULLSCREEN_WIDTH_RES, fullscreenResolution[0]);
        setOption(CONFIG.FULLSCREEN_HEIGHT_RES, fullscreenResolution[1]);
    }


    /// <summary>
    /// Activa/Desactiva la sincronización vertical a pantalla completa.
    /// </summary>
    /// <param name="vsync">Estado de la sincronización vertical.</param>
    public void SetFullscreenVsync(bool vsync)
    {
        setOption(CONFIG.FULLSCREEN_VSYNC, vsync.ToString().ToLower());
        setOption(CONFIG.FULLSCREEN_PICASSO_VSYNC, vsync.ToString().ToLower());
    }


    /// <summary>
    /// Asigna un dispositivo al puerto indicado.
    /// 
    /// Indice Dispositivo
    /// ------ -----------
    /// 0      Nada
    /// 1      [JoystickVirtual] Cursor numérico (Fuegos: 0 y 5)
    /// 2      [JoystickVirtual] Cursor (Fuegos: Control y Alt)
    /// 3      [JoystickVirtual] WASD (Fuegos: Alt Izquierdo)
    /// 4      X-Arcade (Izquierdo)
    /// 5      X-Arcade (Derecho)
    /// 6      Ratón
    /// 7      USB Gamepad/Joystick
    /// 
    /// </summary>
    /// <param name="port">Numero de puerto (1-2).</param>
    /// <param name="item">Dispositivo.</param>
    public void SetGameport(int port, int item)
    {
        String gameport;

        if (port == 1)
        {
            gameport = CONFIG.GAMEPORT_1;
        }
        else
        {
            gameport = CONFIG.GAMEPORT_2;
        }

        switch (item)
        {
            case 0:
                setOption(gameport, GAMEPORT.NONE);
                break;

            case 1:
                setOption(gameport, GAMEPORT.NUMKEYPAD__0_5_FIRES);
                break;

            case 2:
                setOption(gameport, GAMEPORT.CURSOR__RCTRL_ALT_FIRES);
                break;

            case 3:
                setOption(gameport, GAMEPORT.WASD__LALT_FIRES);
                break;

            case 4:
                setOption(gameport, GAMEPORT.XARCADE_LEFT);
                break;

            case 5:
                setOption(gameport, GAMEPORT.XARCADE_RIGHT);
                break;

            case 6:
                setOption(gameport, GAMEPORT.MOUSE);
                break;

            case 7:
                if (gameport == GAMEPORT.JOYSTICK_0)
                {
                    setOption(gameport, GAMEPORT.JOYSTICK_0);
                }
                else if (gameport == GAMEPORT.JOYSTICK_1)
                {
                    setOption(gameport, GAMEPORT.JOYSTICK_1);
                }

                break;

            default:
                break;
        }
    }


    /// <summary>
    /// Activa o desactiva la interfaz del emulador
    /// al iniciarse el mismo.
    /// </summary>
    /// <param name="guiMode">GUI activada o desactivada.</param>
    public void ToggleGUI(bool gui)
    {
        if (gui)
        {
            setOption(CONFIG.USE_GUI, "yes");
        }
        else
        {
            setOption(CONFIG.USE_GUI, "no");
        }
    }


    /// <summary>
    /// Establece la Kickstart ROM a usar.
    /// </summary>
    /// <param name="kickstartROM">Kickstart ROM.</param>
    public void SetKickstartROMFile(String kickstartROM)
    {
        setOption(CONFIG.KICKSTART_ROM_FILE, kickstartROM);
    }


    /// <summary>
    /// Activa/Desactiva el mapeo de las unidades de Windows
    /// en el Amiga.
    /// </summary>
    /// <param name="enabled">Estado.</param>
    public void SetWindowsDrives(bool enabled)
    {
        setOption(CONFIG.MAP_PC_DRIVES, enabled.ToString().ToLower());
        setOption(CONFIG.MAP_PC_DRIVES_AUTO, enabled.ToString().ToLower());
        setOption(CONFIG.MAP_PC_CDROM, enabled.ToString().ToLower());
        setOption(CONFIG.MAP_PC_NETDRIVES, enabled.ToString().ToLower());
        setOption(CONFIG.MAP_PC_USBDRIVES, enabled.ToString().ToLower());
    }


    /// <summary>
    /// Establece el tamaño del modo ventana.
    /// </summary>
    /// <param name="resolution">Vector con la resolución [Ancho][Alto].</param>
    public void SetWindowedResolution(String[] resolution)
    {
        setOption(CONFIG.WINDOWED_WIDTH_RES, resolution[0]);
        setOption(CONFIG.WINDOWED_HEIGHT_RES, resolution[1]);
    }


    /// <summary>
    /// Activa/Desactiva los LEDs de estado de la emulación
    /// (actividad de los HDs, disqueteras, etc ... ).
    /// </summary>
    /// <param name="leds">Estado de los LEDs.</param>
    public void EnableLEDs(bool leds)
    {
        setOption(CONFIG.LEDS, leds.ToString().ToLower());
        setOption(CONFIG.LEDS_RTG, leds.ToString().ToLower());
    }



    /// <summary>
    /// Almacena la información actualizada en el buffer en el archivo
    /// de configuración UAE establecido en el constructor.
    /// </summary>
    public void Save()
    {
        File.WriteAllLines(this.uaeConfigPath, configData);
    }


    /// <summary>
    /// Obtiene el valor asignado a una opción.
    /// </summary>
    /// <param name="optionName">Nombre de la opción.</param>
    /// <returns>Valor de la opción.</returns>
    private String getOption(String optionName)
    {
        String[] option = new String[2];

        for (int l = 0; l <= (configData.Length - 1); l++)
        {
            option = configData[l].Split('=');

            if (option[0].Equals(optionName))
            {
                return configData[l].Split('=')[1];
            }
        }

        return null;
    }


    /// <summary>
    /// Asigna un valor a la opción indicada.
    /// </summary>
    /// <param name="optionName">Nombre de la opción.</param>
    /// <param name="value">Valor.</param>
    private void setOption(String optionName, String value)
    {
        String[] option = new String[2];

        for (int l = 0; l <= (configData.Length - 1); l++)
        {
            option = configData[l].Split('=');

            if (option[0].Equals(optionName))
            {
                configData[l] = (optionName + "=" + value);
            }
        }
    }
    #endregion
}