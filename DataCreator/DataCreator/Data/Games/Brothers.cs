using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Brothers : AbstractGameInfo
    {
        [ImportingConstructor]
        public Brothers() : base( "1E531873-83D6-4BD6-9C54-60AD9301ACA3" )
        {
            this.ApplicationName = "Brothers - A Tale of Two Sons";
            this.FolderName = "Brothers 2013 [Brothers - A Tale of Two Sons]";
            this.TechnicalNameMatcher = "Brothers - A Tale of Two Sons";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
