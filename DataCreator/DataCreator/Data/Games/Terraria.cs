using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Terraria : AbstractGameInfo
    {
        [ImportingConstructor]
        public Terraria() : base( "367CBED1-9FF1-4226-9BAF-E3230AE19EFB" )
        {
            this.ApplicationName = "Terraria";
            this.FolderName = "Terraria 2011 [Terraria]";
            this.TechnicalNameMatcher = "Terraria";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
