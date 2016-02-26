using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Borderlands2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Borderlands2() : base( "8A5665B2-1454-49B4-9EE4-2A7B7A3396B5" )
        {
            this.ApplicationName = "Borderlands 2";
            this.FolderName = "Borderlands 2012 [Borderlands 2]";
            this.TechnicalNameMatcher = "Borderlands 2";
        }

        protected override void OnImportsSatisfied()
        {
            this.Definition = this._definitionFactory.GetSteamCloud();
        }
    }
}
