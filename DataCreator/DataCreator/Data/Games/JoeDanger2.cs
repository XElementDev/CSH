using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class JoeDanger2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public JoeDanger2() : base( "CD27DCA3-D440-4B2E-AA72-78F47AB9D07E" )
        {
            this.ApplicationName = "Joe Danger 2: The Movie";
            this.FolderName = "Joe Danger 2013 [Joe Danger 2_ The Movie]";
            this.TechnicalNameMatcher = this.ApplicationName; // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
