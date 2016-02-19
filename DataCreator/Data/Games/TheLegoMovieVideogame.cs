using System;
using System.ComponentModel.Composition;
using XElement.DotNet.System.Text;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheLegoMovieVideogame : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheLegoMovieVideogame() : base( "2D01A67E-3A6F-4A5E-B774-5B0206C09BF9" )
        {
            this.ApplicationName = "The LEGO Movie - Videogame";
            this.FolderName = "LEGO 2014 [The LEGO Movie - Videogame]";
            this.TechnicalNameMatcher = String.Format( "The LEGO{0} Movie - Videogame", 
                                                       SpecialCharacters.REGISTERED_TRADEMARK );
        }

        protected override void OnImportsSatisfied()
        {
            this.Definition = this._definitionFactory.GetSteamCloud();
        }
    }
}
