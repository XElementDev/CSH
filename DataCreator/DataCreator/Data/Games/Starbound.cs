using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Starbound : AbstractGameInfo
    {
        [ImportingConstructor]
        public Starbound() : base( "E33D0478-9ABC-49DC-9FA0-C9312BC5CF91" )
        {
            this.ApplicationName = "Starbound";
            this.FolderName = "Starbound 2013 [Starbound]";
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
