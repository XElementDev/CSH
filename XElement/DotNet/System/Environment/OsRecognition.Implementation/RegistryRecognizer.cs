using Microsoft.Win32;
using System;

namespace XElement.DotNet.System.Environment
{
    public class RegistryRecognizer : IOsRecognizer
    {
        public OsId? /*IOsRecognizer.*/GetOsId()
        {
            var versionString = (string)Registry.GetValue( CURRENT_OS_VERSION_KEY, 
                                                        "CurrentVersion", 
                                                        String.Empty );
            return RecognitionHelper.GetOsIdByString( versionString );
        }

        //  --> taken from: https://stackoverflow.com/questions/29194556/c-sharp-get-os-name-windows-8-1
        //  2015-09-21
        private const string CURRENT_OS_VERSION_KEY = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\";
    }
}
