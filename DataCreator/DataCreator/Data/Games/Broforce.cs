using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Broforce : AbstractGameInfo
    {
        [ImportingConstructor]
        public Broforce() : base( "0E472D3F-D542-437A-8E29-B86563F664B6" )
        {
            this.ApplicationName = "Broforce";
            this.FolderName = "Broforce 2014 [Broforce]";
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
