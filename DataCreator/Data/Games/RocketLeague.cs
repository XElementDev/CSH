using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class RocketLeague : GameInfo
    {
        [ImportingConstructor]
        public RocketLeague()
        {
            this.DisplayName = "Rocket League";
            this.FolderName = "Rocket League 2015 [Rocket League]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Rocket League";
        }
    }
}
