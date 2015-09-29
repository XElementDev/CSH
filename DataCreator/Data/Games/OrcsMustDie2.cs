using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class OrcsMustDie2 : GameInfo
    {
        [ImportingConstructor]
        public OrcsMustDie2()
        {
            this.DisplayName = "Orcs Must Die! 2";
            this.FolderName = "Orcs Must Die 2012 [Orcs Must Die! 2]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Orcs Must Die! 2"; // TODO: check matcher
        }
    }
}
