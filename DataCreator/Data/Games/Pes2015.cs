using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( GameInfo ) )]
    public class Pes2015 : GameInfo
    {
        [ImportingConstructor]
        public Pes2015()
        {
            this.DisplayName = "Pro Evolution Soccer 2015";
            this.FolderName = "PES 2014 [Pro Evolution Soccer 2015]";
            this.OsConfigs = new List<OsConfiguration>
            {
                new OsConfiguration
                {
                    Links = new List<AbstractLinkInfo>
                    {
                        new FolderLinkInfo
                        {
                            DestinationRoot = Environment.SpecialFolder.MyDocuments,
                            DestinationSubFolderPath = Path.Combine( "KONAMI", "Pro Evolution Soccer 2015" ),
                            DestinationTargetName = "save",
                            SourceId = "save"
                        }
                    },
                    OsId = OsId.Win81
                }
            };
            this.TechnicalNameMatcher = "Pro Evolution Soccer 2015";
        }
    }
}
