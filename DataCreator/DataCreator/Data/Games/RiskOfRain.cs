using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class RiskOfRain : AbstractGameInfo
    {
        [ImportingConstructor]
        public RiskOfRain() : base( "F0C7E626-408D-4C70-9B41-83C6C7C6BBEC" )
        {
            this.ApplicationName = "Risk of Rain";
            this.FolderName = "Risk of Rain 2013 [Risk of Rain]";
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
