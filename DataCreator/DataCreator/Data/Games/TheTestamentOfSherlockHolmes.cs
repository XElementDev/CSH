using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheTestamentOfSherlockHolmes : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheTestamentOfSherlockHolmes() : base( "739B85A5-328F-4293-9D7E-184556BA1555" )
        {
            this.ApplicationName = "The Testament of Sherlock Holmes";
            this.FolderName = "Sherlock Holmes 2012 [The Testament of Sherlock Holmes]";
            this.TechnicalNameMatcher = "The Testament of Sherlock Holmes"; // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
