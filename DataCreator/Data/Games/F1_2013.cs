using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class F1_2013 : GameInfo
    {
        [ImportingConstructor]
        public F1_2013()
        {
            this.DisplayName = "F1 2013";
            this.FolderName = "F1 2013 [F1 2013]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "F1 2013";  // TODO: check matcher
        }
    }
}
