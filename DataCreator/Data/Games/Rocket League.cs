using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo RocketLeague()
        {
            return new GameInfo
            {
                DisplayName = "Rocket League",
                FolderName = "Rocket League 2015 [Rocket League]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Rocket League"
            };
        }
    }
}
