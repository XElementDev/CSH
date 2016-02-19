using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
    [Export( typeof( AbstractAppInfo ) )]
    internal class NotepadPlusPlus : AbstractAppInfo
    {
        [ImportingConstructor]
        public NotepadPlusPlus() : base( "97C5D94B-2794-45D1-8442-710754E41D77" )
        {
            this.ApplicationName = "Notepad++";
            this.FolderName = "Notepad++";
            this.TechnicalNameMatcher = "Notepad\\+\\+";
        }

        private OsConfiguration GetConfigForWindows10()
        {
            return new OsConfiguration
            {
                Links = new List<AbstractLinkInfo>
                {
                    new FileLinkInfo
                    {
                        DestinationRoot = Environment.SpecialFolder.ApplicationData,
                        DestinationSubFolderPath = Path.Combine("Notepad++"),
                        DestinationTargetName = "config.xml",
                        SourceId = "config.xml"
                    },
                    new FileLinkInfo
                    {
                        DestinationRoot = Environment.SpecialFolder.ApplicationData,
                        DestinationSubFolderPath = Path.Combine("Notepad++"),
                        DestinationTargetName = "contextMenu.xml",
                        SourceId = "contextMenu.xml"
                    },
                    new FileLinkInfo
                    {
                        DestinationRoot = Environment.SpecialFolder.ApplicationData,
                        DestinationSubFolderPath = Path.Combine("Notepad++"),
                        DestinationTargetName = "functionList.xml",
                        SourceId = "functionList.xml"
                    },
                    new FileLinkInfo
                    {
                        DestinationRoot = Environment.SpecialFolder.ApplicationData,
                        DestinationSubFolderPath = Path.Combine("Notepad++"),
                        DestinationTargetName = "langs.xml",
                        SourceId = "langs.xml"
                    },
                    new FileLinkInfo
                    {
                        DestinationRoot = Environment.SpecialFolder.ApplicationData,
                        DestinationSubFolderPath = Path.Combine("Notepad++"),
                        DestinationTargetName = "nativeLang.xml",
                        SourceId = "nativeLang.xml"
                    },
                    new FileLinkInfo
                    {
                        DestinationRoot = Environment.SpecialFolder.ApplicationData,
                        DestinationSubFolderPath = Path.Combine("Notepad++"),
                        DestinationTargetName = "shortcuts.xml",
                        SourceId = "shortcuts.xml"
                    },
                    new FileLinkInfo
                    {
                        DestinationRoot = Environment.SpecialFolder.ApplicationData,
                        DestinationSubFolderPath = Path.Combine("Notepad++"),
                        DestinationTargetName = "stylers.xml",
                        SourceId = "stylers.xml"
                    }
                },
                OsId = OsId.Win10
            };
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                GetConfigForWindows10()
            };
            this.Definition = this._configFactory.Get( osConfigs );
        }
    }
}
