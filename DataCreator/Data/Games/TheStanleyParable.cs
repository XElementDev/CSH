using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheStanleyParable : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheStanleyParable()
        {
            this.DisplayName = "The Stanley Parable";
            this.FolderName = "The Stanley Parable 2013 [The Stanley Parable]";
            this.TechnicalNameMatcher = "The Stanley Parable";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
