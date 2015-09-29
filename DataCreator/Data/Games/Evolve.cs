using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class Evolve : GameInfo
    {
        [ImportingConstructor]
        public Evolve()
        {
            this.DisplayName = "Evolve";
            this.FolderName = "Evolve 2015 [Evolve]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Evolve";
        }
    }
}
