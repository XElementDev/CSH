using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class AgeOfEmpiresIIHD : GameInfo
    {
        [ImportingConstructor]
        public AgeOfEmpiresIIHD()
        {
            this.DisplayName = "Age of Empires II: HD Edition";
            this.FolderName = "Age Of Empires 2013 [Age of Empires II_ HD Edition]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Age of Empires II: HD Edition";
        }
    }
}
