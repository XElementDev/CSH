using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class ShadowOfTheTombRaider : AbstractGameInfo
    {
        [ImportingConstructor]
        public ShadowOfTheTombRaider() : base( "FA9D943C-3E5E-4980-94A8-41388F0E3684" )
        {
            this.ApplicationName = "Shadow of the Tomb Raider";
            this.FolderName = "Tomb Raider 2018 [Shadow of the Tomb Raider]";
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
