using System.Collections.Generic;
using System.Management;

namespace XElement.CloudSyncHelper.InstalledPrograms
{
#region not unit-tested
    public class WmiScanner : IScanner
    {
        //  --> Based on: https://code.msdn.microsoft.com/windowsdesktop/Get-a-list-of-Installed-9620d03d
        //      Last visited: 2015-09-11
        public IEnumerable<IInstalledProgram> /*IScanner.*/GetInstalledPrograms()
        {
            var result = new List<IInstalledProgram>();
            var moSearch = new ManagementObjectSearcher( "Select * from Win32_Product" );

            ManagementObjectCollection moReturn = moSearch.Get();
            foreach ( ManagementObject mo in moReturn )
            {
                var nameObj = mo["Name"];
                if ( nameObj != null )
                {
                    var name = nameObj.ToString();
                    var installedProgram = new InstalledProgram
                    {
                        DisplayName = name
                    };
                    result.Add( installedProgram );
                }
            }

            return result;
        }
    }
#endregion
}
