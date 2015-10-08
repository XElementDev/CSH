using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Pes2015 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Pes2015()
        {
            this.DisplayName = "Pro Evolution Soccer 2015";
            this.FolderName = "PES 2014 [Pro Evolution Soccer 2015]";
            this.TechnicalNameMatcher = "Pro Evolution Soccer 2015";
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
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
            this.Configuration = this._configFactory.Get( osConfigs );
        }
    }
}
