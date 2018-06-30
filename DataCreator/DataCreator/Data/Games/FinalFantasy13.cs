using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class FinalFantasy13 : AbstractGameInfo
    {
        [ImportingConstructor]
        public FinalFantasy13() : base( "2FDE9DBB-DB61-4DEC-8621-3B7BCA0A9016" )
        {
            this.ApplicationName = "Final Fantasy XIII";
            this.FolderName = "Final Fantasy 2009-2014 [Final Fantasy XIII]";
            this.TechnicalNameMatcher = "FINAL FANTASY XIII";
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
