using System;
using System.Collections.Generic;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Apps
    {
        private static AppInfo Mp3tag()
        {
            return new AppInfo
            {
                DisplayName = "Mp3tag",
                FolderName = "Mp3tag",
                OsConfigs = new List<OsConfiguration>
                {
                    new OsConfiguration
                    {
                        Links = new List<AbstractLinkInfo>
                        {
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine( "Mp3tag", "data" ),
                                DestinationTargetName = "columns.ini",
                                SourceId = Path.Combine( "data", "columns.ini" )
                            },
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine( "Mp3tag", "data" ),
                                DestinationTargetName = "genres.ini",
                                SourceId = Path.Combine( "data", "genres.ini" )
                            },
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine( "Mp3tag", "data" ),
                                DestinationTargetName = "usrfields.ini",
                                SourceId = Path.Combine( "data", "usrfields.ini" )
                            },
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine( "Mp3tag" ),
                                DestinationTargetName = "mp3tag.cfg",
                                SourceId = "mp3tag.cfg"
                            }
                        },
                        OsId = OsId.Win81
                    }
                },
                TechnicalNameMatcher = "Mp3tag"
            };
        }
    }
}
