using System;
using System.Collections.Generic;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data
{
    internal static partial class Games
    {
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
