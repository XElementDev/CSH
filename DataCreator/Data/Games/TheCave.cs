using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class TheCave : GameInfo
    {
        [ImportingConstructor]
        public TheCave()
        {
            this.DisplayName = "The Cave";
            this.FolderName = "The Cave 2013 [The Cave]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "The Cave"; // TODO: check matcher
        }
    }
}
