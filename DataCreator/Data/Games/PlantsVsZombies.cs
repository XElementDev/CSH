using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class PlantsVsZombies : GameInfo
    {
        [ImportingConstructor]
        public PlantsVsZombies()
        {
            this.DisplayName = "Plants vs. Zombies";
            this.FolderName = "Plants vs. Zombies 2009 [Pflanzen gegen Zombies]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // Origin
            };
            //  2015-09-25: https://stackoverflow.com/questions/3496351/adding-a-tm-superscript-to-a-string
            this.TechnicalNameMatcher = "Pflanzen gegen Zombies\u2122";  // Plfanzen gegen Zombies™
        }
    }
}
