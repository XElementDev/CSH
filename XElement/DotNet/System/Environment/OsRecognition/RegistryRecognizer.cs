using Microsoft.Win32;
using System;

namespace XElement.DotNet.System.Environment
{
    public class RegistryRecognizer : IOsRecognizer
    {
        public OsId? /*IOsRecognizer.*/GetOsId()
        {
            var version = (string)Registry.GetValue( CURRENT_OS_VERSION_KEY, 
                                                        "CurrentVersion", 
                                                        String.Empty );
            //if      ( version.Major == 6 && version.Minor == 0 )  return OsId.WinVista;
            //else if ( version.Minor == 6 && version.Minor == 1 )  return OsId.Win7;
            //else if ( version.Major == 6 && version.Minor == 2 )  return OsId.Win8;
            if ( version == "6.3" )  return OsId.Win81;
            //else if ( version.Major == 10 && version.Minor == 0 ) return OsId.Win10;
            else return null;
        }

        //  --> taken from: https://stackoverflow.com/questions/29194556/c-sharp-get-os-name-windows-8-1
        //  2015-09-21
        private const string CURRENT_OS_VERSION_KEY = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\";
    }
}
