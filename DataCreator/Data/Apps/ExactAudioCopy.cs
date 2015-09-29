using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Apps
{
    [Export( typeof( AppInfo ) )]
    public class ExactAudioCopy : AppInfo
    {
        [ImportingConstructor]
        public ExactAudioCopy()
        {
            this.DisplayName = "Exact Audio Copy";
            this.FolderName = "Exact Audio Copy";
            this.OsConfigs = new List<OsConfiguration>
            {
                this.GetConfigForWin8_1(),
                GetConfigForWin10()
            };
            this.TechnicalNameMatcher = "Exact Audio Copy.*";
        }

        private OsConfiguration GetConfigForWin8_1()
        {
            return new OsConfiguration { Links = this.GetLinksForWin81_10(), OsId = OsId.Win81 };
        }

        private OsConfiguration GetConfigForWin10()
        {
            return new OsConfiguration { Links = this.GetLinksForWin81_10(), OsId = OsId.Win10 };
        }

        private List<AbstractLinkInfo> GetLinksForWin81_10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.ApplicationData,
                    DestinationSubFolderPath = Path.Combine("EAC"),
                    DestinationTargetName = "Profiles",
                    SourceId = "Profiles"
                }
            };
        }
    }
}
