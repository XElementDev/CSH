using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TokiTori : AbstractGameInfo
    {
        [ImportingConstructor]
        public TokiTori() : base( "A2ACE881-7DBF-40ED-8BA9-72689E8ED9EC" )
        {
            this.ApplicationName = "Toki Tori";
            this.FolderName = "Toki Tori 2010 [Toki Tori]";
            this.TechnicalNameMatcher = "Toki Tori";    // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
