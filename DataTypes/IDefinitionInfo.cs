using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IDefinitionInfo
    {
        IEnumerable<IOsConfigurationInfo> OsConfigs { get; }

        bool SupportsSteamCloud { get; }
    }
}
