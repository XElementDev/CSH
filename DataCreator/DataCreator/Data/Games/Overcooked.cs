using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Overcooked : AbstractGameInfo
    {
        [ImportingConstructor]
        public Overcooked() : base( "2C7C633B-B3B0-4B9C-BB0B-790D2B6384E7" )
        {
            this.ApplicationName = "Overcooked";
            this.FolderName = "Overcooked 2016 [Overcooked]";
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
