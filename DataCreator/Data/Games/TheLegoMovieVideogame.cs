using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheLegoMovieVideogame : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheLegoMovieVideogame()
        {
            this.DisplayName = "The LEGO Movie - Videogame";
            this.FolderName = "LEGO 2014 [The LEGO Movie - Videogame]";
            this.TechnicalNameMatcher = "The LEGO\u00ae Movie - Videogame";
        }

        protected override void OnImportsSatisfied()
        {
            this.Configuration = this._configFactory.GetSteamCloud();
        }
    }
}
