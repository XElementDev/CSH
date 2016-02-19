using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
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

        private OsConfiguration GetConfigForWindows8_1()
        {
            return new OsConfiguration
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
            };
        }

        private OsConfiguration GetConfigForWindows10()
        {
            var win10Config = this.GetConfigForWindows8_1();
            win10Config.OsId = OsId.Win10;
            return win10Config;
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                GetConfigForWindows8_1(),   // TODO: Check config for Win8.1
                GetConfigForWindows10()
            };
            this.Definition = this._configFactory.Get( osConfigs );
        }
    }
}
