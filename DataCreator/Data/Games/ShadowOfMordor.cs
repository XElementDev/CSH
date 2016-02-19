using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class ShadowOfMordor : AbstractGameInfo
    {
        [ImportingConstructor]
        public ShadowOfMordor() : base( "4D79F7A4-8588-4242-8DC0-9694B5BBCAAC" )
        {
            this.ApplicationName = "Middle-earth: Shadow of Mordor";
            this.FolderName = "Middle-earth_ Shadow of Mordor";
            this.TechnicalNameMatcher = "Middle-earth: Shadow of Mordor";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
