using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class TheTestamentOfSherlockHolmes : GameInfo
    {
        [ImportingConstructor]
        public TheTestamentOfSherlockHolmes()
        {
            this.DisplayName = "The Testament of Sherlock Holmes";
            this.FolderName = "Sherlock Holmes 2012 [The Testament of Sherlock Holmes]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "The Testament of Sherlock Holmes"; // TODO: check matcher
        }
    }
}
