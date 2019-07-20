using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Fortified : AbstractGameInfo
    {
        [ImportingConstructor]
        public Fortified() : base( "0767D99A-970A-43BC-A7F6-C82DC5BA3AC5" )
        {
            this.ApplicationName = "Fortified";
            this.FolderName = $"Fortified 2016 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = this.ApplicationName;
            // SteamID: 334210
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
