using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Owlboy : AbstractGameInfo
    {
        [ImportingConstructor]
        public Owlboy() : base( "3B69007D-6EB1-423D-9A56-8FE7C5BAC404" )
        {
            this.ApplicationName = "Owlboy";
            this.FolderName = "Owlboy 2016 [Owlboy]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
        }
    }
}
