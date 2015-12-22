using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Text;

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
            this.TechnicalNameMatcher = "Battlefield 3" + SpecialCharacters.TRADEMARK;
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
