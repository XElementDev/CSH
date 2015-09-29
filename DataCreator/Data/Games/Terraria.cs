using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class Terraria : GameInfo
    {
        [ImportingConstructor]
        public Terraria()
        {
            this.DisplayName = "Terraria";
            this.FolderName = "Terraria 2011 [Terraria]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Terraria";
        }
    }
}
