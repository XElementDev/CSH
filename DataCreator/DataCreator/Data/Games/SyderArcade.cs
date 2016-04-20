using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class SyderArcade : AbstractGameInfo
    {
        [ImportingConstructor]
        public SyderArcade() : base( "1E4E19E9-CBFA-411D-A926-FE80FE67950E" )
        {
            this.ApplicationName = "Syder Arcade";
            this.FolderName = "Syder Arcade 2013 [Syder Arcade]";
            this.TechnicalNameMatcher = "Syder Arcade"; // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                // TODO
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
        }
    }
}
