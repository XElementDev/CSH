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
        public OsConfigurationInfo Get( List<AbstractLinkInfo> links, OsId osId )
        {
            return this.Get( links: links, osId: osId, name: "default" );
        }

        public OsConfigurationInfo Get( List<AbstractLinkInfo> links, OsId osId, string name )
        {
            return new OsConfigurationInfo
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
