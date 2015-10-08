using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class F1_2013 : AbstractGameInfo
    {
        [ImportingConstructor]
        public F1_2013()
        {
            this.DisplayName = "F1 2013";
            this.FolderName = "F1 2013 [F1 2013]";
            this.TechnicalNameMatcher = "F1 2013";  // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
