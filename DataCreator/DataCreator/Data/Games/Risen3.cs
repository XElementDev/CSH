using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Risen3 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Risen3() : base( "7B57B2AB-8B0F-40EB-88F4-2E20002A4EB0" )
        {
            this.ApplicationName = "Risen 3 - Titan Lords";
            this.FolderName = "Risen 2014 [Risen 3 - Titan Lords]";
            this.TechnicalNameMatcher = "Risen 3 - Titan Lords";
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
