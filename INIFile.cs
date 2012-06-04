using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Esta clase representa a un fichero .INI.
/// </summary>
class INIFile
{
    /// <summary>
    /// Ruta del fichero INI.
    /// </summary>
    private String iniPath;


    /// <summary>
    /// Buffer de lectura.
    /// </summary>
    private StringBuilder readBuffer;


    /// <summary>
    /// Método de DLL: Escribe una cadena en la sección
    /// indicada de un fichero INI.
    /// </summary>
    /// <param name="section">Sección.</param>
    /// <param name="key">Clave.</param>
    /// <param name="val">Valor.</param>
    /// <param name="filepath">Ruta del fichero INI.</param>
    /// <returns>0 si ha habido algún error, caso contrario
    /// distinto de 0.
    /// 
    /// Ver http://msdn.microsoft.com/en-us/library/aa368542(v=vs.85).aspx 
    /// para obtener más información sobre los códigos de error.</returns>
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section,
                                                         string key,
                                                         string val,
                                                         string filepath);


    /// <summary>
    /// Método de DLL: Lee una cadena de la sección
    /// indicada de un fichero INI.
    /// </summary>
    /// <param name="section">Sección.</param>
    /// <param name="key">Clave.</param>
    /// <param name="def">Clave por defecto si la solicitada
    /// no existe.</param>
    /// <param name="retVal">Buffer donde se almacena la
    /// cadena leída.</param>
    /// <param name="size">Tamaño del buffer en caracteres.</param>
    /// <param name="filePath">Ruta del fichero INI.</param>
    /// <returns>El número de caracteres leídos sin incluir
    /// el caracter de fín de línea.</returns>
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section,
                                                      string key, 
                                                      string def, 
                                                      StringBuilder retVal,
                                                      int size, 
                                                      string filePath);

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="path">Ruta del fichero INI
    /// con el que se va a trabajar.</param>
    public INIFile(String path)
    {
        this.iniPath = path;
        this.readBuffer = new StringBuilder(255);
    }


    /// <summary>
    /// Devuelve el valor asociado a una clave dada.
    /// </summary>
    /// <param name="section">Sección.</param>
    /// <param name="key">Clave.</param>
    /// <returns></returns>
    public String readValue(String section, String key)
    {
        GetPrivateProfileString(section, key, "", 
                                this.readBuffer, 
                                this.readBuffer.Capacity, 
                                this.iniPath);

        return this.readBuffer.ToString();
    }


    /// <summary>
    /// Escribe un valor en la sección y clave indicados.
    /// </summary>
    /// <param name="section">Sección.</param>
    /// <param name="key">Clave.</param>
    /// <param name="value">Valor.</param>
    public void writeValue(String section, String key, String value)
    {
        WritePrivateProfileString(section, key, value, this.iniPath);
    }
}