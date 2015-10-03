using Microsoft.Win32;
using System.Collections.Generic;

namespace XElement.CloudSyncHelper.InstalledPrograms
{
#region not unit-tested
    //  --> Based on: https://stackoverflow.com/questions/25307650/getting-list-of-installed-programs-on-64bit-windows
    //      Last visited: 2015-10-02
    public class RegistryScanner : IScanner
    {
        public IEnumerable<IInstalledProgram> /*IScanner.*/GetInstalledPrograms()
        {
            var result = new List<IInstalledProgram>();

            result.AddRange( this.GetInstalledPrograms( openIn64BitMode: false ) );
            result.AddRange( this.GetInstalledPrograms( openIn64BitMode: true ) );

            return result;
        }

        private IEnumerable<IInstalledProgram> GetInstalledPrograms( bool openIn64BitMode )
        {
            var result = new List<IInstalledProgram>();

            var mode = openIn64BitMode ? RegistryView.Registry64 : RegistryView.Registry32;
            using ( var baseKey = RegistryKey.OpenBaseKey( RegistryHive.LocalMachine, mode ) )
            {
                using ( RegistryKey regKey = baseKey.OpenSubKey( UNINSTALL_KEY ) )
                {
                    foreach ( string subKeyName in regKey.GetSubKeyNames() )
                    {
                        using ( RegistryKey subKey = regKey.OpenSubKey( subKeyName ) )
                        {
                            if ( subKey.GetValueNames().Length != 0 )
                            {
                                var installedApplication = new InstalledProgram();
                                installedApplication.DisplayName = subKey.GetValueOrDefault<string>( "DisplayName" );
                                installedApplication.EstimatedSize = subKey.GetValue( "EstimatedSize" );

                                result.Add( installedApplication );
                            }
                        }
                    }
                }
            }

            return result;
        }

        private const string UNINSTALL_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    }
#endregion
}
