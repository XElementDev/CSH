using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class ProjectCars2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public ProjectCars2() : base( "DA07EBC9-1814-410C-9A24-21C23889B8F9" )
        {
            this.ApplicationName = "Project CARS 2";
            this.FolderName = $"Project Cars 2017 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = this.ApplicationName;
            // SteamID: 378860
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
