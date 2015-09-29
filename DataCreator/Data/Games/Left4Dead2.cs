using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class Left4Dead2 : GameInfo
    {
        [ImportingConstructor]
        public Left4Dead2()
        {
            this.DisplayName = "Left 4 Dead 2";
            this.FolderName = "Left 4 Dead 2009 [Left 4 Dead 2]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Left 4 Dead 2";    // TODO: check matcher
        }
    }
}
