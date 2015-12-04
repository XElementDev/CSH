using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IConfiguration
    {
        IEnumerable<IOsConfiguration> OsConfigs { get; }

        bool SupportsSteamCloud { get; }
    }
}
