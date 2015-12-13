using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class PlantsVsZombies : AbstractGameInfo
    {
        [ImportingConstructor]
        public PlantsVsZombies() : base( "12E4BB5C-3361-47A4-9BB1-2D420C6228CF" )
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

        protected override void OnImportsSatisfied()
        {
        }
    }
}
