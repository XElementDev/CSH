using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Model
{
#region not unit-tested
    [Export]
    internal class ConfigurationFactory
    {
        public Configuration Get( IEnumerable<OsConfiguration> osConfigs )
        {
            return this.Get( osConfigs: osConfigs, name: "default" );
        }

        public Configuration Get( IEnumerable<OsConfiguration> osConfigs, string name )
        {
            return new Configuration
            {
                Author = "XElement",
                Name = name,
                OsConfigs = osConfigs.ToList()
            };
        }
    }
#endregion
}
