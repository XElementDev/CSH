using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class DrawAStickmanEpic : AbstractGameInfo
    {
        [ImportingConstructor]
        public DrawAStickmanEpic() : base( "2BA555A1-99AE-4543-9713-C97F83149C8A" )
        {
            this.ApplicationName = "Draw a Stickman: EPIC";
            this.FolderName = "Draw a Stickman 2013 [Draw a Stickman_ EPIC]";
            this.TechnicalNameMatcher = "Draw a Stickman: EPIC";
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
