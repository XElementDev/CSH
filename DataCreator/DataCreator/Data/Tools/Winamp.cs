using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Tools
{
    [Export( typeof( AbstractToolInfo ) )]
    internal class Winamp : AbstractToolInfo
    {
        [ImportingConstructor]
        public Winamp() : base( "B2D4A228-A950-4036-949B-4F328F416866" )
        {
            this.ApplicationName = "Winamp";
            this.FolderName = "Winamp";
            this.TechnicalNameMatcher = "Winamp";
        }

        private List<AbstractLinkInfo> GetLinksForWindows81_10()
        {
            return new List<AbstractLinkInfo>
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
            };
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                this._osConfigFactory.Get( this.GetLinksForWindows81_10(), OsId.Win81 ), // TODO: Check config for Win8.1
                this._osConfigFactory.Get( this.GetLinksForWindows81_10(), OsId.Win10 )
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
        }
    }
}
