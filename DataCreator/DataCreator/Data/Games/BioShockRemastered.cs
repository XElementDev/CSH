using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class BioshockRemastered : AbstractGameInfo
    {
        [ImportingConstructor]
        public BioshockRemastered() : base( "9B336EA3-FF18-4158-8264-1481DF91A4BB" )
        {
            this.ApplicationName = "BioShock Remastered";
            this.FolderName = "BioShock 2016 [BioShock Remastered]";
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
