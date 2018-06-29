using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class SteamWorldDig : AbstractGameInfo
    {
        [ImportingConstructor]
        public SteamWorldDig() : base( "464D0492-C5A6-49AE-B425-12ED3A46B082" )
        {
            this.ApplicationName = "SteamWorld Dig";
            this.FolderName = "SteamWorld 2013 [SteamWorld Dig]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
