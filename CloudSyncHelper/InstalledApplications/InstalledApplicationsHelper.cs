using Microsoft.Win32;
using System.Collections.Generic;
namespace XElement.CloudSyncHelper
{
#region not unit-tested
    //  --> Based on: http://www.codeproject.com/Tips/782919/Get-List-of-Installed-Applications-of-System-in-Cs
    //      Visited: 2015-08-02
    public class InstalledApplicationsHelper
    {
        public IList<InstalledApplication> GetInstalledApplications()
        {
            IList<InstalledApplication> result = new List<InstalledApplication>();

            using ( RegistryKey regKey = Registry.LocalMachine.OpenSubKey( UNINSTALL_KEY ) )
            {
                foreach ( string subKeyName in regKey.GetSubKeyNames() )
                {
                    using ( RegistryKey subKey = regKey.OpenSubKey( subKeyName ) )
                    {
                        if ( subKey.GetValueNames().Length != 0 )
                        {
                            var installedApplication = new InstalledApplication();
                            installedApplication.DisplayName = subKey.GetValueOrDefault<string>( "DisplayName" );
                            installedApplication.EstimatedSize = subKey.GetValue( "EstimatedSize" );

                            result.Add( installedApplication );
                        }
                    }
                }
            }

            return result;
        }

        private const string UNINSTALL_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    }

    internal static class Extensions
    {
        public static T GetValueOrDefault<T>( this RegistryKey registryKey, string name )
        {
            T value = default(T);

            try
            {
                value = (T)registryKey.GetValue( name );
            }
            catch { }

            return value;
        }
    }
#endregion
}
