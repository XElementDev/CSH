using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Evolve : AbstractGameInfo
    {
        [ImportingConstructor]
        public Evolve() : base( "23D95F4A-43A2-4084-809E-5F8001714F97" )
        {
            this.ApplicationName = "Evolve";
            this.FolderName = "Evolve 2015 [Evolve]";
            this.TechnicalNameMatcher = "Evolve";
        }

        protected override void OnImportsSatisfied()
        {
            this.Definition = this._definitionFactory.GetSteamCloud();
        }
    }
}
