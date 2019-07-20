using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Gta5 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Gta5() : base( "A1A893C8-3D3C-43AF-850F-71C6227E045B" )
        {
            this.ApplicationName = "Grand Theft Auto V";
            this.FolderName = $"GTA 2015 [Grand Theft Auto V]";
            this.TechnicalNameMatcher = this.ApplicationName;
            // SteamID: 271590
            return;
        }


        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                // Rockstar
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
            return;
        }
    }
}
