using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IDefinition
    {
        IEnumerable<IOsConfiguration> OsConfigs { get; }

        bool SupportsSteamCloud { get; }
    }
}
