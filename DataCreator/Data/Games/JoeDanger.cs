using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class JoeDanger : AbstractGameInfo
    {
        [ImportingConstructor]
        public JoeDanger()
        {
            this.DisplayName = "Joe Danger";
            this.FolderName = "Joe Danger 2013 [Joe Danger]";
            this.TechnicalNameMatcher = "Joe Danger";   // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
