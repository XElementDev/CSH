using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class FootballManager2017 : AbstractGameInfo
    {
        [ImportingConstructor]
        public FootballManager2017() : base( "8F2F4639-74B5-4CC8-AE9B-9177ED20AE45" )
        {
            this.ApplicationName = "Football Manager 2017";
            this.FolderName = "FM 2016 [Football Manager 2017]";
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
