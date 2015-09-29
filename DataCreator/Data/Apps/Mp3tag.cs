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
            };
            this.TechnicalNameMatcher = "Mp3tag";
        }
    }
}
