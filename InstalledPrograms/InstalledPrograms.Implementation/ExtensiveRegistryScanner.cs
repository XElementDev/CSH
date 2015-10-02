using Microsoft.Win32;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace XElement.CloudSyncHelper.InstalledPrograms
{
#region not unit-tested
    //  --> Based on: http://www.codeproject.com/Tips/782919/Get-List-of-Installed-Applications-of-System-in-Cs
    //      Visited: 2015-08-02
    public class ExtensiveRegistryScanner : IScanner
    {
        public IEnumerable<IInstalledProgram> /*IScanner.*/GetInstalledPrograms()
        {
            var result = new List<InstalledProgram>();

            result.AddRange( this.GetInstalledPrograms( Registry.CurrentUser, HKCU_UNINSTALL_KEY ) );
            result.AddRange( this.GetInstalledPrograms( Registry.LocalMachine, HKLM_UNINSTALL_KEY_32BIT ) );
            result.AddRange( this.GetInstalledPrograms( Registry.LocalMachine, HKLM_UNINSTALL_KEY_64BIT ) );

            return result;
        }

        private IList<InstalledProgram> GetInstalledPrograms( RegistryKey key, string uninstallKey )
        {
            IList<InstalledProgram> result = new List<InstalledProgram>();

            using ( var regKey = key.OpenSubKey( uninstallKey,
                                                 RegistryKeyPermissionCheck.ReadSubTree,
                                                 RegistryRights.ReadKey ) )
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

            return result;
        }

        private const string HKCU_UNINSTALL_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        private const string HKLM_UNINSTALL_KEY_32BIT = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        private const string HKLM_UNINSTALL_KEY_64BIT = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
    }
#endregion
}
