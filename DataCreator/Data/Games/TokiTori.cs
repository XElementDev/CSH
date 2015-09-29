using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class TokiTori : GameInfo
    {
        [ImportingConstructor]
        public TokiTori()
        {
            this.DisplayName = "Toki Tori";
            this.FolderName = "Toki Tori 2010 [Toki Tori]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Toki Tori";    // TODO: check matcher
        }
    }
}
