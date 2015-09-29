using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class BioshockInfinite : GameInfo
    {
        [ImportingConstructor]
        public BioshockInfinite()
        {
            this.DisplayName = "BioShock Infinite";
            this.FolderName = "BioShock 2013 [BioShock Infinite]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "BioShock Infinite";    // TODO: check matcher
        }
    }
}
