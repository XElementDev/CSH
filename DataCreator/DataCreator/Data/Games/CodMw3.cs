using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class CodMw3 : AbstractGameInfo
    {
        [ImportingConstructor]
        public CodMw3() : base( "5015F2D9-3547-4958-8CBE-CDF8E91B43A1" )
        {
            this.ApplicationName = "Call of Duty: Modern Warfare 3";
            this.FolderName = "Call of Duty 2011 [Call of Duty_ Modern Warfare 3]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
