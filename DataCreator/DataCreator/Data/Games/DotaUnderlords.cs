using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class DotaUnderlords : AbstractGameInfo
    {
        [ImportingConstructor]
        public DotaUnderlords() : base( "A88C6006-1BB8-4F7D-B215-480F2C4D8D77" )
        {
            this.ApplicationName = "Dota Underlords";
            this.FolderName = $"Dota 2019 [{this.ApplicationName}]";
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
