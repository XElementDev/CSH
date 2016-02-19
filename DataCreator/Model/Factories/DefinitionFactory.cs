using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Model
{
    [Export]
    internal class DefinitionFactory
    {
        public Definition Get( IEnumerable<OsConfiguration> osConfigs )
        {
            return new Definition
            {
                OsConfigs = osConfigs.ToList()
            };
        }

        public Definition GetSteamCloud()
        {
            return new Definition
            {
                SupportsSteamCloud = true
            };
        }
    }
}
