using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo TheTestamentOfSherlockHolmes()
        {
            return new GameInfo
            {
                DisplayName = "The Testament of Sherlock Holmes",
                FolderName = "Sherlock Holmes 2012 [The Testament of Sherlock Holmes]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "The Testament of Sherlock Holmes"   // TODO: check matcher
            };
        }
    }
}
