using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class AgeOfEmpiresIIHD : AbstractGameInfo
    {
        [ImportingConstructor]
        public AgeOfEmpiresIIHD() : base( "FEAA47FC-FEDA-4945-9A4B-011C15F44E3F" )
        {
            this.ApplicationName = "Age of Empires II: HD Edition";
            this.FolderName = "Age Of Empires 2013 [Age of Empires II_ HD Edition]";
            this.TechnicalNameMatcher = "Age of Empires II: HD Edition";
        }

        protected override void OnImportsSatisfied()
        {
            this.Definition = this._definitionFactory.GetSteamCloud();
        }
    }
}
