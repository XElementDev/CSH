using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class GoatSimulator : AbstractGameInfo
    {
        [ImportingConstructor]
        public GoatSimulator() : base( "C7307409-5748-456C-928A-29B6B1C4B630" )
        {
            this.ApplicationName = "Goat Simulator";
            this.FolderName = "Goat Simulator 2014 [Goat Simulator]";
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
