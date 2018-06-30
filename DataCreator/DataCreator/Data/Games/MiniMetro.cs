using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class MiniMetro : AbstractGameInfo
    {
        [ImportingConstructor]
        public MiniMetro() : base( "06A5DCA9-C60D-4C92-BED1-B9250766CF69" )
        {
            this.ApplicationName = "Mini Metro";
            this.FolderName = "Mini Metro 2015 [Mini Metro]";
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
