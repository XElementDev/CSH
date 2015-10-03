using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
    [Export( typeof( AppInfo ) )]
    public class Mp3tag : AppInfo
    {
        [ImportingConstructor]
        public Mp3tag()
        {
            this.DisplayName = "Mp3tag";
            this.FolderName = "Mp3tag";
            this.OsConfigs = new List<OsConfiguration>
            {
                GetConfigForWindows8_1(),
                GetConfigForWindows10()
            };
            this.TechnicalNameMatcher = "Mp3tag";
        }

        private OsConfiguration GetConfigForWindows8_1()
        {
            return new OsConfiguration { Links = this.GetLinksForWin81_10(), OsId = OsId.Win81 };
        }

        private OsConfiguration GetConfigForWindows10()
        {
            return new OsConfiguration { Links = this.GetLinksForWin81_10(), OsId = OsId.Win10 };
        }

        private List<AbstractLinkInfo> GetLinksForWin81_10()
        {
            return new List<AbstractLinkInfo>
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
            };
        }
    }
}
