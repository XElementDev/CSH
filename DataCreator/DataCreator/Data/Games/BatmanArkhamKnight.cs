using System.ComponentModel.Composition;
using XElement.DotNet.System.Text;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class BatmanArkhamKnight : AbstractGameInfo
    {
        [ImportingConstructor]
        public BatmanArkhamKnight() : base( "8AA28E96-C9A2-4F9A-8499-D07304E0585A" )
        {
            this.ApplicationName = "Batman: Arkham Knight";
            this.FolderName = "Batman Arkham 2015 [Batman_ Arkham Knight]";
            this.TechnicalNameMatcher = $"Batman{SpecialCharacters.TRADEMARK}: Arkham Knight";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
