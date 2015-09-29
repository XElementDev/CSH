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
                new OsConfiguration
                {
                    Links = new List<AbstractLinkInfo>
                    {
                        new FolderLinkInfo
                        {
                            DestinationRoot = Environment.SpecialFolder.ApplicationData,
                            DestinationSubFolderPath = Path.Combine("EAC"),
                            DestinationTargetName = "Profiles",
                            SourceId = "Profiles"
                        }
                    },
                    OsId = OsId.Win81
                }
            };
            this.TechnicalNameMatcher = "Exact Audio Copy.*";
        }
    }
}
