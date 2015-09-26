using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo F1_2013()
        {
            return new GameInfo
            {
                DisplayName = "F1 2013",
                FolderName = "F1 2013 [F1 2013]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "F1 2013"    // TODO: check matcher
            };
        }
    }
}
