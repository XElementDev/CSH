using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo BioshockInfinite()
        {
            return new GameInfo
            {
                DisplayName = "BioShock Infinite",
                FolderName = "BioShock 2013 [BioShock Infinite]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "BioShock Infinite"  // TODO: check matcher
            };
        }
    }
}
