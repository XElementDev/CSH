using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo Terraria()
        {
            return new GameInfo
            {
                DisplayName = "Terraria",
                FolderName = "Terraria 2011 [Terraria]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Terraria"   // TODO: check matcher
            };
        }
    }
}
