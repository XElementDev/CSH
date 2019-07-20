using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Portal2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Portal2() : base( "270A4DED-FC78-458A-9391-770D3BEE483D" )
        {
            this.ApplicationName = "Portal 2";
            this.FolderName = $"Portal 2011 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = this.ApplicationName;
            // SteamID: 620
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
