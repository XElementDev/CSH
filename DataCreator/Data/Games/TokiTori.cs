using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo TokiTori()
        {
            return new GameInfo
            {
                DisplayName = "Toki Tori",
                FolderName = "Toki Tori 2010 [Toki Tori]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Toki Tori"  // TODO: check matcher
            };
        }
    }
}
