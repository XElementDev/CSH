using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo Borderlands2()
        {
            return new GameInfo
            {
                DisplayName = "Borderlands 2",
                FolderName = "Borderlands 2012 [Borderlands 2]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Borderlands 2"  // TODO: check matcher
            };
        }
    }
}
