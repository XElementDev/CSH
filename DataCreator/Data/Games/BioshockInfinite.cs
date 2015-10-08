using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class BioshockInfinite : AbstractGameInfo
    {
        [ImportingConstructor]
        public BioshockInfinite()
        {
            this.DisplayName = "BioShock Infinite";
            this.FolderName = "BioShock 2013 [BioShock Infinite]";
            this.TechnicalNameMatcher = "BioShock Infinite";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
