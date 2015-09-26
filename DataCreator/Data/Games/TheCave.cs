using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo TheCave()
        {
            return new GameInfo
            {
                DisplayName = "The Cave",
                FolderName = "The Cave 2013 [The Cave]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "The Cave"   // TODO: check matcher
            };
        }
    }
}
