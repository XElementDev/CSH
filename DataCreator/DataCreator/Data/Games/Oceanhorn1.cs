using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Oceanhorn1 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Oceanhorn1() : base( "D2F74FF9-9F06-4EBF-893E-AD6E526DDF50" )
        {
            this.ApplicationName = "Oceanhorn: Monster of Uncharted Seas";
            this.FolderName = "Oceanhorn 2015 [Oceanhorn_ Monster of Uncharted Seas]";
            this.TechnicalNameMatcher = "Oceanhorn: Monster of Uncharted Seas";
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
