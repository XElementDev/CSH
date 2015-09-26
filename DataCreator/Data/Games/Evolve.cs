using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo Evolve()
        {
            return new GameInfo
            {
                DisplayName = "Evolve",
                FolderName = "Evolve 2015 [Evolve]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Evolve"
            };
        }
    }
}
