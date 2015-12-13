using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Battlefield3 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Battlefield3() : base( "BFEA2A56-3721-40AB-B0C2-8E3F81678E51" )
        {
            this.DisplayName = "Battlefield 3";
            this.FolderName = "Battlefield 2011 [Battlefield 3]";
            //  2015-09-25: https://stackoverflow.com/questions/3496351/adding-a-tm-superscript-to-a-string
            this.TechnicalNameMatcher = "Battlefield 3\u2122";  // Battlefield 3™
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                // Origin
            };
            this.Configuration = this._configFactory.Get( osConfigs );
        }
    }
}
