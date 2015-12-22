using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Left4Dead2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Left4Dead2() : base( "27F4C600-EE69-48B2-BE52-F2918DB21CED" )
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
