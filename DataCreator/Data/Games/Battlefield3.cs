using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class Battlefield3 : GameInfo
    {
        [ImportingConstructor]
        public Battlefield3()
        {
            this.DisplayName = "Battlefield 3";
            this.FolderName = "Battlefield 2011 [Battlefield 3]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Origin
            };
            //  2015-09-25: https://stackoverflow.com/questions/3496351/adding-a-tm-superscript-to-a-string
            this.TechnicalNameMatcher = "Battlefield 3\u2122";  // Battlefield 3™
        }
    }
}
