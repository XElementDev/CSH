using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Model
{
    [Export]
    internal class ConfigurationFactory
    {
        public Configuration Get( IEnumerable<OsConfiguration> osConfigs )
        {
            return new Configuration
            {
                OsConfigs = osConfigs.ToList()
            };
        }

        public Configuration GetSteamCloud()
        {
            return new Configuration
            {
                SupportsSteamCloud = true
            };
        }
    }
}
