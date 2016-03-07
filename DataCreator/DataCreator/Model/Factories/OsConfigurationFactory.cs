using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Model
{
#region not unit-tested
    [Export]
    internal class OsConfigurationFactory
    {
        public OsConfiguration Get( List<AbstractLinkInfo> links, OsId osId )
        {
            return this.Get( links: links, osId: osId, name: "default" );
        }

        public OsConfiguration Get( List<AbstractLinkInfo> links, OsId osId, string name )
        {
            return new OsConfiguration
            {
                Author = "XElement", 
                Links = links, 
                Name = name, 
                OsId = osId
            };
        }
    }
#endregion
}
