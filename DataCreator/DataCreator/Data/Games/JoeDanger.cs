using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class JoeDanger : AbstractGameInfo
    {
        [ImportingConstructor]
        public JoeDanger() : base( "53C7BC46-AA43-413F-8F13-9CFEB4DF9FF0" )
        {
            this.ApplicationName = "Joe Danger";
            this.FolderName = "Joe Danger 2013 [Joe Danger]";
            this.TechnicalNameMatcher = "Joe Danger";   // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.Definition = this._definitionFactory.GetSteamCloud();
        }
    }
}
