using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class ForgeQuest : AbstractGameInfo
    {
        [ImportingConstructor]
        public ForgeQuest() : base( "E1D567DE-EB0D-429D-B9AE-634A6D5952F7" )
        {
            this.ApplicationName = "Forge Quest";
            this.FolderName = "Forge Quest 2015 [Forge Quest]";
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
