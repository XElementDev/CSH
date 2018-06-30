using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Borderlands : AbstractGameInfo
    {
        [ImportingConstructor]
        public Borderlands() : base( "FA773668-0021-4493-9C3F-2D981C98244E" )
        {
            this.ApplicationName = "Borderlands";
            this.FolderName = "Borderlands 2009 [Borderlands]";
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
