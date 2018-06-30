using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class FinalFantasy12Tza : AbstractGameInfo
    {
        [ImportingConstructor]
        public FinalFantasy12Tza() : base( "0FA4567F-5328-4D9A-852D-BB8FE74B508A" )
        {
            this.ApplicationName = "Final Fantasy XII The Zodiac Age";
            this.FolderName = "Final Fantasy 2018 [Final Fantasy XII TZA]";
            this.TechnicalNameMatcher = this.ApplicationName.ToUpper();
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
