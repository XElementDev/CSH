using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class SaintsRowIV : AbstractGameInfo
    {
        [ImportingConstructor]
        public SaintsRowIV()
        {
            this.DisplayName = "Saints Row IV";
            this.FolderName = "Saints Row 2013 [Saints Row IV]";
            this.TechnicalNameMatcher = "Saints Row IV";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
