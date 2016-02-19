using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;
using XElement.DotNet.System.Text;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TheSims3 : AbstractGameInfo
    {
        // TODO: Add other languages besides [de-DE]

        [ImportingConstructor]
        public TheSims3() : base( "0AED2DDF-6109-401F-9467-484FA853450F" )
        {
            this.ApplicationName = "Die Sims 3 [DE]";
            this.FolderName = "The Sims 2009 [The Sims 3]";
            this.TechnicalNameMatcher = String.Format( "Die Sims{0} 3",
                                                       SpecialCharacters.TRADEMARK );
        }

        private OsConfiguration GetConfigForWin10()
        {
            return new OsConfiguration { Links = this.GetLinksForWin10(), OsId = OsId.Win10 };
        }

        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine( "Electronic Arts", "Die Sims 3" ),
                    DestinationTargetName = "Mods",
                    SourceId = "Mods"
                },
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine( "Electronic Arts", "Die Sims 3" ),
                    DestinationTargetName = "Saves",
                    SourceId = "Saves"
                }
            };
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                this.GetConfigForWin10()
            };
            this.Configuration = this._configFactory.Get( osConfigs );
        }
    }
}
