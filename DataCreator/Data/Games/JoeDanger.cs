using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo JoeDanger()
        {
            return new GameInfo
            {
                DisplayName = "Joe Danger",
                FolderName = "Joe Danger 2013 [Joe Danger]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Joe Danger" // TODO: check matcher
            };
        }
    }
}
