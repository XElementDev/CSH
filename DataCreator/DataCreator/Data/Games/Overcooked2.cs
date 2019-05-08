using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Overcooked2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Overcooked2() : base( "2108BD77-A9C3-4098-875E-3436EF346768" )
        {
            this.ApplicationName = "Overcooked! 2";
            this.FolderName = "Overcooked 2018 [Overcooked 2]";
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
