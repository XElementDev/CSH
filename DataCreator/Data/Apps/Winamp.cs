using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
    [Export( typeof( AppInfo ) )]
    public class Winamp : AppInfo
    {
        [ImportingConstructor]
        public Winamp()
        {
            this.DisplayName = "Winamp";
            this.FolderName = "Winamp";
            // TODO:    --> check configuration
            this.OsConfigs = new List<OsConfiguration>
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
                            SourceId = Path.Combine("Plugins", "gen_ml.ini")
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
            };
            this.TechnicalNameMatcher = "Winamp";
        }
    }
}
