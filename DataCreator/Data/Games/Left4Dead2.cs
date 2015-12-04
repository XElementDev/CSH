using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Left4Dead2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Left4Dead2()
        {
            this.DisplayName = "Left 4 Dead 2";
            this.FolderName = "Left 4 Dead 2009 [Left 4 Dead 2]";
            this.TechnicalNameMatcher = "Left 4 Dead 2";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
