using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class DungeonOfTheEndless : AbstractGameInfo
    {
        [ImportingConstructor]
        public DungeonOfTheEndless() : base( "50A14F8B-52CC-4CBD-8108-C94586DE621F" )
        {
            this.ApplicationName = "Dungeon of the Endless";
            this.FolderName = "Endless 2014 [Dungeon of the Endless]";
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
