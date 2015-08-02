using System;
using System.Collections.Generic;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static class Apps
    {
        public static List<AbstractProgramInfo> CreateAppLinkInfos()
        {
            return new List<AbstractProgramInfo>
            {
                ExactAudioCopy()
            };
        }

        private static AppInformation ExactAudioCopy()
        {
            return new AppInformation
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
                                SourceId = "1"
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
