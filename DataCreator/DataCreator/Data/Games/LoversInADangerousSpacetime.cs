using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class LoversInADangerousSpacetime : AbstractGameInfo
    {
        [ImportingConstructor]
        public LoversInADangerousSpacetime() : base( "3526A2B7-715C-4D22-88AD-BCDB5E129D9B" )
        {
            this.ApplicationName = "Lovers in a Dangerous Spacetime";
            this.FolderName = this.ApplicationName;
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
