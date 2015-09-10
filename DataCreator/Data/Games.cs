using System;
using System.Collections.Generic;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Serialization.DataTypes;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
        public static List<AbstractProgramInfo> CreateGameLinkInfos()
        {
            return new List<AbstractProgramInfo>
            {
                AgeOfEmpiresIIHD(),
                Anno2070(),
                Pes2015()
            };
        }

        private static GameInfo Anno2070()
        {
            return new GameInfo
            {
                DisplayName = "ANNO 2070",
                FolderName = "Anno 2011 [ANNO 2070]",
                OsConfigs = new List<OsConfiguration>
                {
                    new OsConfiguration
                    {
                        Links = new List<AbstractLinkInfo>
                        {
                            new FolderLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.MyDocuments,
                                DestinationSubFolderPath = Path.Combine("ANNO 2070", "Accounts", "%UPLAY_ACCOUNT_NAME%"),
                                DestinationTargetName = "Savegames",
                                SourceId = "Savegames"
                            }
                        },
                        OsId = OsId.Win81
                    }
                },
                TechnicalNameMatcher = "ANNO 2070"  // TODO: check matcher
            };
        }

        private static GameInfo Pes2015()
        {
            return new GameInfo
            {
                DisplayName = "Pro Evolution Soccer 2015",
                FolderName = "PES 2014 [Pro Evolution Soccer 2015]",
                OsConfigs = new List<OsConfiguration>
                {
                    new OsConfiguration
                    {
                        Links = new List<AbstractLinkInfo>
                        {
                            new FolderLinkInfo
                            {
                                DestinationRoot = Environment.SpecialFolder.MyDocuments,
                                DestinationSubFolderPath = Path.Combine( "KONAMI", "Pro Evolution Soccer 2015" ),
                                DestinationTargetName = "save",
                                SourceId = "save"
                            }
                        },
                        OsId = OsId.Win81
                    }
                },
                TechnicalNameMatcher = "Pro Evolution Soccer 2015"
            };
        }
    }
}
