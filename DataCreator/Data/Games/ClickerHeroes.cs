using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class ClickerHeroes : AbstractGameInfo
    {
        [ImportingConstructor]
        public ClickerHeroes()
        {
            this.DisplayName = "Clicker Heroes";
            this.FolderName = "Clicker Heroes";
            this.TechnicalNameMatcher = "Clicker Heroes";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
