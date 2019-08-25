using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Firewatch : AbstractGameInfo
    {
        [ImportingConstructor]
        public Firewatch() : base( "45732ED8-B566-4285-875A-602DA56A6FC0" )
        {
            this.ApplicationName = "Firewatch";
            this.FolderName = $"Firewatch 2016 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = this.ApplicationName;
            // SteamID: 383870
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
