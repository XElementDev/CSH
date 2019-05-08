using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Elex : AbstractGameInfo
    {
        [ImportingConstructor]
        public Elex() : base( "BCD4A517-3762-4FD7-9F25-AF4ABCC709B2" )
        {
            this.ApplicationName = "ELEX";
            this.FolderName = "Elex 2017 [ELEX]";
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
