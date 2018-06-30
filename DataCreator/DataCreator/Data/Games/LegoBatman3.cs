using System;
using System.ComponentModel.Composition;
using XElement.DotNet.System.Text;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class LegoBatman3 : AbstractGameInfo
    {
        [ImportingConstructor]
        public LegoBatman3() : base( "A1F8ED7C-B93F-4F32-AEFF-E63EF632618D" )
        {
            this.ApplicationName = "LEGO Batman 3: Beyond Gotham";
            this.FolderName = "LEGO Batman 2014 [LEGO Batman 3_ Beyond Gotham]";
            var matcher = String.Format( "LEGO{0} Batman{1} 3: Beyond Gotham", 
                                         SpecialCharacters.REGISTERED_TRADEMARK, 
                                         SpecialCharacters.TRADEMARK );
            this.TechnicalNameMatcher = matcher;
            return;
        }


        protected override void OnImportsSatisfied()
        {
            this.DefinitionInfo = this._definitionFactory.GetSteamCloud();
            return;
        }
    }
}
