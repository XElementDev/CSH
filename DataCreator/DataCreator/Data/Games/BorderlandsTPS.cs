using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class BorderlandsTPS : AbstractGameInfo
    {
        [ImportingConstructor]
        public BorderlandsTPS() : base( "ABEBD728-DEC6-4CCB-8130-AC281B61A49C" )
        {
            this.ApplicationName = "Borderlands: The Pre-Sequel";
            this.FolderName = "Borderlands 2014 [Borderlands_ The Pre-Sequel]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
