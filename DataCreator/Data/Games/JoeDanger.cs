using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class JoeDanger : GameInfo
    {
        [ImportingConstructor]
        public JoeDanger()
        {
            this.DisplayName = "Joe Danger";
            this.FolderName = "Joe Danger 2013 [Joe Danger]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Joe Danger";   // TODO: check matcher
        }
    }
}
