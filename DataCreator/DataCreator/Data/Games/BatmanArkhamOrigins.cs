using System.ComponentModel.Composition;
using XElement.DotNet.System.Text;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class BatmanArkhamOrigins : AbstractGameInfo
    {
        [ImportingConstructor]
        public BatmanArkhamOrigins() : base( "34AA8A3F-AE4E-4876-B5C5-F93712623CC1" )
        {
            this.ApplicationName = $"Batman{SpecialCharacters.TRADEMARK}: Arkham Origins";
            this.FolderName = "Batman Arkham 2013 [Batman_ Arkham Origins]";
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
