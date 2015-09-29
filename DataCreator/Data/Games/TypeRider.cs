using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class TypeRider : GameInfo
    {
        [ImportingConstructor]
        public TypeRider()
        {
            this.DisplayName = "Type:Rider";
            this.FolderName = "Type_Rider 2013 [Type_Rider]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Type:Rider";   // TODO: check matcher
        }
    }
}
