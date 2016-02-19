using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
    [Export( typeof( AbstractAppInfo ) )]
    internal class Mp3tag : AbstractAppInfo
    {
        [ImportingConstructor]
        public Mp3tag() : base( "9A78A831-C24B-47CD-8EB6-2889CB3100AF" )
        {
            this.ApplicationName = "Mp3tag";
            this.FolderName = "Mp3tag";
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

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                GetConfigForWindows8_1(),
                GetConfigForWindows10()
            };
            this.Configuration = this._configFactory.Get( osConfigs );
        }
    }
}
