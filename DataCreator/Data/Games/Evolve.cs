using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Evolve : AbstractGameInfo
    {
        [ImportingConstructor]
        public Evolve()
        {
            this.DisplayName = "Evolve";
            this.FolderName = "Evolve 2015 [Evolve]";
            this.TechnicalNameMatcher = "Evolve";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
