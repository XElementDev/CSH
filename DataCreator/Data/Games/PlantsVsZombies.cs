using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System;

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
            this.TechnicalNameMatcher = "Pflanzen gegen Zombies" + SpecialCharacters.TRADEMARK;
        }

        protected override void OnImportsSatisfied()
        {
        }
    }
}
