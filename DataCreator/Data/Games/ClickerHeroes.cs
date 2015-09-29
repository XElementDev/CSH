using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class ClickerHeroes : GameInfo
    {
        [ImportingConstructor]
        public ClickerHeroes()
        {
            this.DisplayName = "Clicker Heroes";
            this.FolderName = "Clicker Heroes";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Clicker Heroes";
        }
    }
}
