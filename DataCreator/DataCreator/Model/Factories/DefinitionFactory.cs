using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Model
{
#region not unit-tested
    [Export]
    internal class DefinitionFactory
    {
        public Definition Get( Configuration config )
        {
            return new Definition
            {
                Configurations = new List<Configuration> { config }
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
#endregion
}
