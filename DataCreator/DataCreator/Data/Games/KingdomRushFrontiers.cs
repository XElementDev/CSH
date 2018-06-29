using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class KingdomRushFrontiers : AbstractGameInfo
    {
        [ImportingConstructor]
        public KingdomRushFrontiers() : base( "998B35CD-1C88-41AE-8205-3D7D634E5E82" )
        {
            this.ApplicationName = "Kingdom Rush Frontiers";
            this.FolderName = "Kingdom Rush 2016 [Kingdom Rush Frontiers]";
            this.TechnicalNameMatcher = "Kingdom Rush Frontiers";
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
