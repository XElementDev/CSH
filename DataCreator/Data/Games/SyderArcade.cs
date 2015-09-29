using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class SyderArcade : GameInfo
    {
        [ImportingConstructor]
        public SyderArcade()
        {
            this.DisplayName = "Syder Arcade";
            this.FolderName = "Syder Arcade 2013 [Syder Arcade]";
            this.OsConfigs = new List<OsConfiguration>
            {
                // TODO
            };
            this.TechnicalNameMatcher = "Syder Arcade"; // TODO: check matcher
        }
    }
}
