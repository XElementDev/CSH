using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper
{
    public interface IOsFilter
    {
        IEnumerable<IOsConfiguration> GetFilteredOsConfigs( IEnumerable<IOsConfiguration> osConfigs );
    }
}
