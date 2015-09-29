using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class Borderlands2 : GameInfo
    {
        [ImportingConstructor]
        public Borderlands2()
        {
            this.DisplayName = "Borderlands 2";
            this.FolderName = "Borderlands 2012 [Borderlands 2]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Borderlands 2";    // TODO: check matcher
        }
    }
}
