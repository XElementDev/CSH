using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheCave : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheCave() : base( "AF32D0F2-36DE-40EB-813F-BAFA91E178FE" )
        {
            this.ApplicationName = "The Cave";
            this.FolderName = "The Cave 2013 [The Cave]";
            this.TechnicalNameMatcher = "The Cave"; // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
