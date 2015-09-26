using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo Left4Dead2()
        {
            return new GameInfo
            {
                DisplayName = "Left 4 Dead 2",
                FolderName = "Left 4 Dead 2009 [Left 4 Dead 2]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Left 4 Dead 2"   // TODO: check matcher
            };
        }
    }
}
