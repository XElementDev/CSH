using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo OrcsMustDie2()
        {
            return new GameInfo
            {
                DisplayName = "Orcs Must Die! 2",
                FolderName = "Orcs Must Die 2012 [Orcs Must Die! 2]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Orcs Must Die! 2"   // TODO: check matcher
            };
        }
    }
}
