using System;
using System.Collections.Generic;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Apps
    {
        private static AppInfo TeamSpeak3()
        {
            return new AppInfo
            {
                DisplayName = "TeamSpeak 3",
                FolderName = "TeamSpeak 3",
                OsConfigs = new List<OsConfiguration>
                {
                    new OsConfiguration
                    {
                        Links = new List<AbstractLinkInfo>
                        {
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine("TS3Client"),
                                DestinationTargetName = "settings.db",
                                SourceId = "settings.db"
                            }
                        },
                        OsId = OsId.Win81
                    }
                },
                TechnicalNameMatcher = "TeamSpeak 3 Client" // TODO: check matcher
            }; // TODO: check configuration
        }
    }
}
