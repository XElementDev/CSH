using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo ClickerHeroes()
        {
            return new GameInfo
            {
                DisplayName = "Clicker Heroes",
                FolderName = "Clicker Heroes",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Clicker Heroes" // TODO: check matcher
            };
        }
    }
}
