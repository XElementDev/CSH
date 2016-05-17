﻿using System;
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
        public Pes2015() : base( "E14C9A54-0243-4D24-9E8F-12BDB609386F" )
        {
            this.DisplayName = "Pro Evolution Soccer 2015";
            this.FolderName = "PES 2014 [Pro Evolution Soccer 2015]";
            this.TechnicalNameMatcher = "Pro Evolution Soccer 2015";
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
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine( "KONAMI", "Pro Evolution Soccer 2015" ),
                    DestinationTargetName = "save",
                    SourceId = "save"
                }
            };
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                this.GetConfigForWin8_1(),
                this.GetConfigForWin10()
            };
            this.Configuration = this._configFactory.Get( osConfigs );
        }
    }
}