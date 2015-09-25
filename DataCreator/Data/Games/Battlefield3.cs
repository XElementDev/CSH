using System.Collections.Generic;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        private static GameInfo Battlefield3()
        {
            return new GameInfo
            {
                DisplayName = "Battlefield 3",
                FolderName = "Battlefield 2011 [Battlefield 3]",
                OsConfigs = new List<OsConfiguration>
                {
                    // Origin
                },
                //  2015-09-25: https://stackoverflow.com/questions/3496351/adding-a-tm-superscript-to-a-string
                TechnicalNameMatcher = "Battlefield 3\u2122"    // Battlefield 3™
            };
        }
    }
}
