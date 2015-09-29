using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
    [Export( typeof( AppInfo ) )]
    public class TeamSpeak3 : AppInfo
    {
        [ImportingConstructor]
        public TeamSpeak3()
        {
            this.DisplayName = "TeamSpeak 3";
            this.FolderName = "TeamSpeak 3";
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
                            DestinationSubFolderPath = Path.Combine("TS3Client"),
                            DestinationTargetName = "settings.db",
                            SourceId = "settings.db"
                        }
                    },
                    OsId = OsId.Win81
                }
            };
            this.TechnicalNameMatcher = "TeamSpeak 3 Client";   // TODO: check matcher
        }
    }
}
