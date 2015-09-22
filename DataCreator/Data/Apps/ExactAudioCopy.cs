using System;
using System.Collections.Generic;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Apps
    {
        private static AppInfo ExactAudioCopy()
        {
            return new AppInfo
            {
                DisplayName = "Exact Audio Copy",
                FolderName = "Exact Audio Copy",
                OsConfigs = new List<OsConfiguration>
                {
                    new OsConfiguration
                    {
                        Links = new List<AbstractLinkInfo>
                        {
                            new FolderLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine("EAC"),
                                DestinationTargetName = "Profiles",
                                SourceId = "Profiles"
                            }
                        },
                        OsId = OsId.Win81
                    }
                },
                TechnicalNameMatcher = "Exact Audio Copy.*"
            };
        }
    }
}
