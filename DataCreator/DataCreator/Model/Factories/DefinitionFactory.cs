using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Model
{
#region not unit-tested
    [Export]
    internal class DefinitionFactory
    {
        public DefinitionInfo Get( IEnumerable<OsConfigurationInfo> osConfigs )
        {
            return new DefinitionInfo
            {
                OsConfigs = osConfigs.ToList(), 
                SupportsSteamCloud = false
            };
        }

        public DefinitionInfo GetSteamCloud()
        {
            return new DefinitionInfo
            {
                SupportsSteamCloud = true
            };
        }
    }
#endregion
}
