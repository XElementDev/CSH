using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class AgeOfEmpiresIIHD : AbstractGameInfo
    {
        [ImportingConstructor]
        public AgeOfEmpiresIIHD()
        {
            this.DisplayName = "Age of Empires II: HD Edition";
            this.FolderName = "Age Of Empires 2013 [Age of Empires II_ HD Edition]";
            this.TechnicalNameMatcher = "Age of Empires II: HD Edition";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
