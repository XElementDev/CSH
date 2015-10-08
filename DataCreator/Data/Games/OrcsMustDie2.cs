using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class OrcsMustDie2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public OrcsMustDie2()
        {
            this.DisplayName = "Orcs Must Die! 2";
            this.FolderName = "Orcs Must Die 2012 [Orcs Must Die! 2]";
            this.TechnicalNameMatcher = "Orcs Must Die! 2"; // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
