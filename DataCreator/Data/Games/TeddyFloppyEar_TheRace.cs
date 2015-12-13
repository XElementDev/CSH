using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TeddyFloppyEar_TheRace : AbstractGameInfo
    {
        [ImportingConstructor]
        public TeddyFloppyEar_TheRace()
        {
            this.DisplayName = "Teddy Floppy Ear - The Race";
            this.FolderName = "Teddy Floppy Ear 2012 [Teddy Floppy Ear - The Race]";
            this.TechnicalNameMatcher = "Teddy Floppy Ear - The Race";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
