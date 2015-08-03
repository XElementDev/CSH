using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper
{
    internal static class OsIdHelper
    {
        public static IReadOnlyList<ILinkInfo> GetSuitableConfig( IReadOnlyList<IOsConfiguration> osConfigs )
        {
            var osId = OsIdHelper.GetOsId();

            if ( osId.HasValue )
                return osConfigs.SingleOrDefault( c => c.OsId == osId.Value ).Links;
            else
                return null;
        }

        private static OsId? GetOsId()
        {
            // TODO: Fix .NET version number issue
            return OsId.Win81;

            //var version = Environment.OSVersion.Version;
            //if      ( version.Major == 6 && version.Minor == 0 )  return OsId.WinVista;
            //else if ( version.Minor == 6 && version.Minor == 1 )  return OsId.Win7;
            //else if ( version.Major == 6 && version.Minor == 2 )  return OsId.Win8;
            //else if ( version.Major == 6 && version.Minor == 3 )  return OsId.Win81;
            //else if ( version.Major == 10 && version.Minor == 0 ) return OsId.Win10;
            //else return null;
        }
    }
}
