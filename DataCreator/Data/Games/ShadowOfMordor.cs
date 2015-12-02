using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class ShadowOfMordor : AbstractGameInfo
    {
        [ImportingConstructor]
        public ShadowOfMordor()
        {
            this.DisplayName = "Middle-earth: Shadow of Mordor";
            this.FolderName = "Middle-earth_ Shadow of Mordor";
            this.TechnicalNameMatcher = "Middle-earth: Shadow of Mordor";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
