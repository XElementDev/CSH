using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TypeRider : AbstractGameInfo
    {
        [ImportingConstructor]
        public TypeRider()
        {
            this.DisplayName = "Type:Rider";
            this.FolderName = "Type_Rider 2013 [Type_Rider]";
            this.TechnicalNameMatcher = "Type:Rider";   // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
