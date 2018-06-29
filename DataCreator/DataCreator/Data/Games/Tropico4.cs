using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Tropico4 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Tropico4() : base( "EF9744AA-F854-466F-879D-03073D2C601B" )
        {
            this.ApplicationName = "Tropico 4";
            this.FolderName = "Tropico 2011 [Tropico 4]";
            this.TechnicalNameMatcher = "Tropico 4";
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
