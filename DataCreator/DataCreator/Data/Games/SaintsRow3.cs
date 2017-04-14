using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class SaintsRow3 : AbstractGameInfo
    {
        [ImportingConstructor]
        public SaintsRow3() : base( "5D92770F-DA68-4ADA-BCDD-B0D42B8B5833" )
        {
            this.ApplicationName = "Saints Row: The Third";
            this.FolderName = "Saints Row 2011 [Saints Row_ The Third]";
            this.TechnicalNameMatcher = "Saints Row: The Third";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
