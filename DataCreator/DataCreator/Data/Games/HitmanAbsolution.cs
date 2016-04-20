using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class HitmanAbsolution : AbstractGameInfo
    {
        [ImportingConstructor]
        public HitmanAbsolution() : base( "81A91AE5-E1CD-4F42-B814-CEB590B61B83" )
        {
            this.ApplicationName = "Hitman: Absolution";
            this.FolderName = "Hitman 2012-2014 [Hitman_ Absolution]";
            this.TechnicalNameMatcher = "Hitman: Absolution";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
