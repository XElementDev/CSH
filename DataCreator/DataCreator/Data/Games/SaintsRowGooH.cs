using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class SaintsRowGooH : AbstractGameInfo
    {
        [ImportingConstructor]
        public SaintsRowGooH() : base( "4C2DEDD5-697F-4F2D-A31E-23B1C12E0BC4" )
        {
            this.ApplicationName = "Saints Row: Gat out of Hell";
            this.FolderName = "Saints Row 2015 [Saints Row_ Gat out of Hell]";
            this.TechnicalNameMatcher = "Saints Row: Gat out of Hell";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
