using System;
using System.Collections.Generic;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Apps
    {
        public static List<AbstractProgramInfo> CreateAppLinkInfos()
        {
            return new List<AbstractProgramInfo>
            {
                ExactAudioCopy(),
                Mp3tag(),
                TeamSpeak3(),
                Winamp()
            };
        }

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

        private static AppInfo Winamp()
        {
            return new AppInfo
            {
                DisplayName = "Winamp",
                FolderName = "Winamp",
                OsConfigs = new List<OsConfiguration>
                {
                    new OsConfiguration
                    {
                        Links = new List<AbstractLinkInfo>
                        {
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine("Winamp", "Plugins"),
                                DestinationTargetName = "gen_ml.ini",
                                SourceId = "gen_ml.ini"
                            },
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine("Winamp"),
                                DestinationTargetName = "auth.ini",
                                SourceId = "auth.ini"
                            },
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine("Winamp"),
                                DestinationTargetName = "studio.xnf",
                                SourceId = "studio.xnf"
                            },
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine("Winamp"),
                                DestinationTargetName = "winamp.ini",
                                SourceId = "winamp.ini"
                            },
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine("Winamp"),
                                DestinationTargetName = "Winamp.m3u",
                                SourceId = "Winamp.m3u"
                            },
                            new FileLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.ApplicationData,
                                DestinationSubFolderPath = Path.Combine("Winamp"),
                                DestinationTargetName = "Winamp.m3u8",
                                SourceId = "Winamp.m3u8"
                            }
                        },
                        OsId = OsId.Win81
                    }
                },
                TechnicalNameMatcher = "Winamp"
            };
        }
    }
}
