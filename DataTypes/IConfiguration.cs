using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IConfiguration
    {
        string Author { get; }

        string Name { get; }

        IEnumerable<IOsConfiguration> OsConfigs { get; }
    }
}
