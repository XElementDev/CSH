using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class SaintsRowIV : AbstractGameInfo
    {
        [ImportingConstructor]
        public SaintsRowIV() : base( "B4C5E79F-4594-4D9B-B40A-38385D261C9B" )
        {
            this.ApplicationName = "Saints Row IV";
            this.FolderName = "Saints Row 2013 [Saints Row IV]";
            this.TechnicalNameMatcher = "Saints Row IV";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
