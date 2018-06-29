using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Payday2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Payday2() : base( "A48B8D74-6D6E-4E97-B32F-61BD596F6149" )
        {
            this.ApplicationName = "PAYDAY 2";
            this.FolderName = "Payday 2013 [PAYDAY 2]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
