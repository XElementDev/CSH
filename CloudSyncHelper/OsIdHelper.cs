using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.OsRecognition;

namespace XElement.CloudSyncHelper
{
    internal static class OsIdHelper
    {
        public static IReadOnlyList<ILinkInfo> GetSuitableConfig( IReadOnlyList<IOsConfiguration> osConfigs )
        {
            IReadOnlyList<ILinkInfo> suitableConfig = new List<ILinkInfo>();
            IOsRecognizer osRecognizer = new RegistryRecognizer();
            var osId = osRecognizer.GetOsId();

            if ( osId.HasValue )
            {
                var osConfig = osConfigs.SingleOrDefault( c => c.OsId == osId.Value );
                if ( osConfig != null )
                {
                    suitableConfig = osConfig.Links;
                }
            }

            return suitableConfig;
        }
    }
}
