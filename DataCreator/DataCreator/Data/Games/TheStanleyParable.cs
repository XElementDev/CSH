using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheStanleyParable : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheStanleyParable() : base( "7B7EE663-825C-4FDF-B1E9-85009096C212" )
        {
            this.ApplicationName = "The Stanley Parable";
            this.FolderName = "The Stanley Parable 2013 [The Stanley Parable]";
            this.TechnicalNameMatcher = "The Stanley Parable";
        }

        protected override void OnImportsSatisfied()
        {
            this.Definition = this._definitionFactory.GetSteamCloud();
        }
    }
}
