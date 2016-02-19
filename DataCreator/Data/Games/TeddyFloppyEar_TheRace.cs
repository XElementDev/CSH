using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TeddyFloppyEar_TheRace : AbstractGameInfo
    {
        [ImportingConstructor]
        public TeddyFloppyEar_TheRace() : base( "45FDF15F-AFD9-42CA-99A4-6A262064CFFB" )
        {
            this.ApplicationName = "Teddy Floppy Ear - The Race";
            this.FolderName = "Teddy Floppy Ear 2012 [Teddy Floppy Ear - The Race]";
            this.TechnicalNameMatcher = "Teddy Floppy Ear - The Race";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
