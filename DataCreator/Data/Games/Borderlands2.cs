using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Borderlands2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Borderlands2()
        {
            this.DisplayName = "Borderlands 2";
            this.FolderName = "Borderlands 2012 [Borderlands 2]";
            this.TechnicalNameMatcher = "Borderlands 2";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
