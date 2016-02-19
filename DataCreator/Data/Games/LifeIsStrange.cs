using System.ComponentModel.Composition;
using XElement.DotNet.System.Text;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class LifeIsStrange : AbstractGameInfo
    {
        [ImportingConstructor]
        public LifeIsStrange() : base( "F2929F42-6DC3-4049-99A4-2823D797657E" )
        {
            this.ApplicationName = "Life Is Strange";
            this.FolderName = "Life Is Strange 2015 [Life Is Strange]";
            this.TechnicalNameMatcher = "Life Is Strange" + SpecialCharacters.TRADEMARK;
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
