using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class OrcsMustDie2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public OrcsMustDie2() : base( "41128DF6-5E43-45A1-9DA3-70EE2760FCFE" )
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
