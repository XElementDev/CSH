using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Braid : AbstractGameInfo
    {
        [ImportingConstructor]
        public Braid() : base( "FDC6616E-D674-4148-A716-FE0DA3584F67" )
        {
            this.ApplicationName = "Braid";
            this.FolderName = "Braid 2009 [Braid]";
            this.TechnicalNameMatcher = "Braid";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
