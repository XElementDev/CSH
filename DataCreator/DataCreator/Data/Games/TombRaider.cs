using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TombRaider : AbstractGameInfo
    {
        [ImportingConstructor]
        public TombRaider() : base( "5C3D9CED-75F1-48E9-A299-A3CDE663D9F6" )
        {
            this.ApplicationName = "Tomb Raider";
            this.FolderName = "Tomb Raider 2013 [Tomb Raider]";
            this.TechnicalNameMatcher = "Tomb Raider";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
