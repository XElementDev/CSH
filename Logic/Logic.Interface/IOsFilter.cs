using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IOsFilter
    {
        IEnumerable<IOsConfigurationInfo> GetFilteredOsConfigs( IEnumerable<IOsConfigurationInfo> osConfigs );
    }
}
