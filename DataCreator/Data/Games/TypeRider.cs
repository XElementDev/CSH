using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo TypeRider()
        {
            return new GameInfo
            {
                DisplayName = "Type:Rider",
                FolderName = "Type_Rider 2013 [Type_Rider]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Type:Rider" // TODO: check matcher
            };
        }
    }
}
