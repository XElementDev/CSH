using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class TheStanleyParable : GameInfo
    {
        [ImportingConstructor]
        public TheStanleyParable()
        {
            this.DisplayName = "The Stanley Parable";
            this.FolderName = "The Stanley Parable 2013 [The Stanley Parable]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "The Stanley Parable";
        }
    }
}
