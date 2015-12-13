using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheLegoMovieVideogame : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheLegoMovieVideogame() : base( "2D01A67E-3A6F-4A5E-B774-5B0206C09BF9" )
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
