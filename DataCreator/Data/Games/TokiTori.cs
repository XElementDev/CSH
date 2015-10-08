using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TokiTori : AbstractGameInfo
    {
        [ImportingConstructor]
        public TokiTori()
        {
            this.DisplayName = "Toki Tori";
            this.FolderName = "Toki Tori 2010 [Toki Tori]";
            this.TechnicalNameMatcher = "Toki Tori";    // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
