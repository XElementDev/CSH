using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Tes5Skyrim : AbstractGameInfo
    {
        [ImportingConstructor]
        public Tes5Skyrim() : base( "6E5B3B3F-A4E3-4F67-989A-E1E313EF9D24" )
        {
            this.ApplicationName = "The Elder Scrolls V: Skyrim";
            this.FolderName = "TES 2011 [The Elder Scrolls V_ Skyrim]";
            this.TechnicalNameMatcher = "The Elder Scrolls V: Skyrim";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
