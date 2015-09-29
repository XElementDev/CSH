using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class Anno2070 : GameInfo
    {
        [ImportingConstructor]
        public Anno2070()
        {
            this.DisplayName = "ANNO 2070";
            this.FolderName = "Anno 2011 [ANNO 2070]";
            this.OsConfigs = new List<OsConfiguration>
            {
                new OsConfiguration
                {
                    Links = new List<AbstractLinkInfo>
                    {
                        new FolderLinkInfo
                        {
                            DestinationRoot = Environment.SpecialFolder.MyDocuments,
                            DestinationSubFolderPath = Path.Combine("ANNO 2070", "Accounts", "%UPLAY_ACCOUNT_NAME%"),
                            DestinationTargetName = "Savegames",
                            SourceId = "Savegames"
                        }
                    },
                    OsId = OsId.Win81
                }
            };
            this.TechnicalNameMatcher = "ANNO 2070";    // TODO: check matcher
        }
    }
}
