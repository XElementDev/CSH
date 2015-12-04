using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheTestamentOfSherlockHolmes : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheTestamentOfSherlockHolmes()
        {
            this.DisplayName = "The Testament of Sherlock Holmes";
            this.FolderName = "Sherlock Holmes 2012 [The Testament of Sherlock Holmes]";
            this.TechnicalNameMatcher = "The Testament of Sherlock Holmes"; // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
