using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    internal class TeddyFloppyEar_TheRace : GameInfo
    {
        [ImportingConstructor]
        public TeddyFloppyEar_TheRace()
        {
            this.DisplayName = "Teddy Floppy Ear - The Race";
            this.FolderName = "Teddy Floppy Ear 2012 [Teddy Floppy Ear - The Race]";
            this.OsConfigs = new List<OsConfiguration>()
            {
                // Steam Cloud
            };
            this.TechnicalNameMatcher = "Teddy Floppy Ear - The Race";
        }
    }
}
