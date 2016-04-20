using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class FarCry4 : AbstractGameInfo
    {
        [ImportingConstructor]
        public FarCry4() : base( "CA3C10FC-D045-4431-A73D-B9F06D992CDB" )
        {
            this.ApplicationName = "Far Cry 4";
            this.FolderName = "Far Cry 2014 [Far Cry 4]";
            this.TechnicalNameMatcher = "Far Cry 4";
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                // Uplay
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
        }
    }
}
