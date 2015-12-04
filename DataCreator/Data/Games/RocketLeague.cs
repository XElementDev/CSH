using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class RocketLeague : AbstractGameInfo
    {
        [ImportingConstructor]
        public RocketLeague()
        {
            this.DisplayName = "Rocket League";
            this.FolderName = "Rocket League 2015 [Rocket League]";
            this.TechnicalNameMatcher = "Rocket League";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
