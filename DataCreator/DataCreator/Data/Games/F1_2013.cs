using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class F1_2013 : AbstractGameInfo
    {
        [ImportingConstructor]
        public F1_2013() : base( "BBF68042-6A44-4FC7-A243-4A640C4F2134" )
        {
            this.ApplicationName = "F1 2013";
            this.FolderName = "F1 2013 [F1 2013]";
            this.TechnicalNameMatcher = "F1 2013";  // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            this.Definition = this._definitionFactory.GetSteamCloud();
        }
    }
}
