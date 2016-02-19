using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Anno2070 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Anno2070() : base( "FE83FD10-2446-45BF-A31B-3149150D6ED3" )
        {
            this.ApplicationName = "ANNO 2070";
            this.FolderName = "Anno 2011 [ANNO 2070]";
            this.TechnicalNameMatcher = "ANNO 2070";    // TODO: check matcher
        }

        private OsConfiguration GetConfigForWin8_1()
        {
            return new OsConfiguration
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
            };
        }

        private OsConfiguration GetConfigForWin10()
        {
            var win10Config = this.GetConfigForWin8_1();
            win10Config.OsId = OsId.Win10;
            return win10Config;
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                GetConfigForWin8_1(),   // TODO: Check config for Win8.1
                GetConfigForWin10()     // TODO: Check config for Win10
            };
            this.Definition = this._definitionFactory.Get( osConfigs );
        }
    }
}
