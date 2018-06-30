using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheWalkingDeadS1 : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheWalkingDeadS1() : base( "28BD5524-AC8D-4F07-8987-524A4384722C" )
        {
            this.ApplicationName = "The Walking Dead";
            this.FolderName = "The Walking Dead 2012-2013 [The Walking Dead]";
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
