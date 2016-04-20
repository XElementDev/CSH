using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class BioshockInfinite : AbstractGameInfo
    {
        [ImportingConstructor]
        public BioshockInfinite() : base( "E3471346-DFC0-4B01-B064-1FC8CD5A5EBB" )
        {
            this.ApplicationName = "BioShock Infinite";
            this.FolderName = "BioShock 2013 [BioShock Infinite]";
            this.TechnicalNameMatcher = "BioShock Infinite";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
