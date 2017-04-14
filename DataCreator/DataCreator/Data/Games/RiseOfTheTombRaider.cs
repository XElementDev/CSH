using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class RiseOfTheTombRaider : AbstractGameInfo
    {
        [ImportingConstructor]
        public RiseOfTheTombRaider() : base( "FA3807B1-C3A4-4162-9314-79FDA4120BD5" )
        {
            this.ApplicationName = "Rise of the Tomb Raider";
            this.FolderName = "Tomb Raider 2016 [Rise of the Tomb Raider]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
