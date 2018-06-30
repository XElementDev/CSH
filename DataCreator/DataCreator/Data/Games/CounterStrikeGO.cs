using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class CounterStrikeGO : AbstractGameInfo
    {
        [ImportingConstructor]
        public CounterStrikeGO() : base( "CD027C0C-9ED5-4B81-B0AB-4EA5C0269D66" )
        {
            this.ApplicationName = "Counter-Strike: Global Offensive";
            this.FolderName = "Counter-Strike 2012 [Counter-Strike_ Global Offensive]";
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
