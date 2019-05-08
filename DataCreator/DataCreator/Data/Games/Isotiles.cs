using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Isotiles : AbstractGameInfo
    {
        [ImportingConstructor]
        public Isotiles() : base( "23779719-864A-499D-8849-42A829B2A097" )
        {
            this.ApplicationName = "Isotiles";
            this.FolderName = "Isotiles 2017 [Isotiles]";
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
