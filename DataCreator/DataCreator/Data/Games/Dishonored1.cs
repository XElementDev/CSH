using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Dishonored1 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Dishonored1() : base( "934B0E8F-0962-4609-A6C4-7DDAE9E0848E" )
        {
            this.ApplicationName = "Dishonored";
            this.FolderName = "Dishonored 2012 [Dishonored]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
