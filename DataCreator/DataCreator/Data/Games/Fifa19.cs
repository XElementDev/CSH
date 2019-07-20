using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Fifa19 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Fifa19() : base( "7B36D1EF-1B8A-48E0-98AD-F76EC50E7E7B" )
        {
            this.ApplicationName = "FIFA 19";
            this.FolderName = $"Fifa 2018 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                // Origin
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
            return;
        }
    }
}
