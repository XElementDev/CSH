using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class KingdomRushOrigins : AbstractGameInfo
    {
        [ImportingConstructor]
        public KingdomRushOrigins() : base( "2834F049-2790-41B0-9F3F-D99820401BD6" )
        {
            this.ApplicationName = "Kingdom Rush Origins";
            this.FolderName = "Kingdom Rush 2018 [Kingdom Rush Origins]";
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
