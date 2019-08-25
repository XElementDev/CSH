using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheRoom : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheRoom() : base( "673B3575-904D-4590-8DB7-A5B9AD09D1BB" )
        {
            this.ApplicationName = "The Room";
            this.FolderName = $"The Room 2014 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = this.ApplicationName;
            // SteamID: 288160
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
