using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Tools
{
    [Export( typeof( AbstractToolInfo ) )]
    internal class Mp3tag : AbstractToolInfo
    {
        [ImportingConstructor]
        public Mp3tag() : base( "9A78A831-C24B-47CD-8EB6-2889CB3100AF" )
        {
            this.ApplicationName = "Mp3tag";
            this.FolderName = "Mp3tag";
            this.TechnicalNameMatcher = "Mp3tag";
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
            var osConfigs = new List<OsConfigurationInfo>
            {
                this._osConfigFactory.Get( this.GetLinksForWin81_10(), OsId.Win81 ),
                this._osConfigFactory.Get( this.GetLinksForWin81_10(), OsId.Win10 )
            };
            this.Definition = this._definitionFactory.Get( osConfigs );
        }
    }
}
