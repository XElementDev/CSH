using System.ComponentModel.Composition;
using XElement.DotNet.System.Text;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class DarkSouls1Remastered : AbstractGameInfo
    {
        [ImportingConstructor]
        public DarkSouls1Remastered() : base( "3FB4897B-5200-4422-98E6-BBFC79611985" )
        {
            this.ApplicationName = "Dark Souls: Remastered";
            this.FolderName = $"Dark Souls 2018 [Dark Souls Remastered]";
            this.TechnicalNameMatcher = $"DARK SOULS{SpecialCharacters.TRADEMARK}: REMASTERED";
            // SteamID: 570940
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
