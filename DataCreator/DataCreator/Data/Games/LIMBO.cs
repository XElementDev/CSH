using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Limbo : AbstractGameInfo
    {
        [ImportingConstructor]
        public Limbo() : base( "803F2C35-45C2-4A36-A3C4-9406EF99B89D" )
        {
            this.ApplicationName = "LIMBO";
            this.FolderName = "Limbo 2011 [LIMBO]";
            this.TechnicalNameMatcher = "LIMBO";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
