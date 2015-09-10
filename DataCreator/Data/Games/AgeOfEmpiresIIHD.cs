using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo AgeOfEmpiresIIHD()
        {
            return new GameInfo
            {
                DisplayName = "Age of Empires II: HD Edition",
                FolderName = "Age Of Empires 2013 [Age of Empires II_ HD Edition]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Steam Cloud
                },
                TechnicalNameMatcher = "Age of Empires II: HD Edition"
            };
        }
    }
}
