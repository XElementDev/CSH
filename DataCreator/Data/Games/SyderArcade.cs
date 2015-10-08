using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class SyderArcade : AbstractGameInfo
    {
        [ImportingConstructor]
        public SyderArcade()
        {
            this.DisplayName = "Syder Arcade";
            this.FolderName = "Syder Arcade 2013 [Syder Arcade]";
            this.TechnicalNameMatcher = "Syder Arcade"; // TODO: check matcher
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                // TODO
            };
            this.Configuration = this._configFactory.Get( osConfigs );
        }
    }
}
