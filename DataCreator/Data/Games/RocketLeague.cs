using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class RocketLeague : AbstractGameInfo
    {
        [ImportingConstructor]
        public RocketLeague() : base( "F4B10EAD-6195-47F3-A99E-CBDB4C93029C" )
        {
            this.ApplicationName = "Rocket League";
            this.FolderName = "Rocket League 2015 [Rocket League]";
            this.TechnicalNameMatcher = "Rocket League";
        }

        protected override void OnImportsSatisfied()
        {
            this.Definition = this._configFactory.GetSteamCloud();
        }
    }
}
