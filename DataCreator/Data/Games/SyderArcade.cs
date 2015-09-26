using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo SyderArcade()
        {
            return new GameInfo
            {
                DisplayName = "Syder Arcade",
                FolderName = "Syder Arcade 2013 [Syder Arcade]",
                OsConfigs = new List<OsConfiguration>
                {
                    // TODO
                },
                TechnicalNameMatcher = "Syder Arcade"   // TODO: check matcher
            };
        }
    }
}
