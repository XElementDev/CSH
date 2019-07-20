using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Monaco : AbstractGameInfo
    {
        [ImportingConstructor]
        public Monaco() : base( "FC01571B-68A1-488A-9437-183F09FCBAC8" )
        {
            this.ApplicationName = "Monaco";
            this.FolderName = $"Monaco 2013 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = this.ApplicationName;
            // SteamID: 113020
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
