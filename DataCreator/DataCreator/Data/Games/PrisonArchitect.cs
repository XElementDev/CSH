using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class PrisonArchitect : AbstractGameInfo
    {
        [ImportingConstructor]
        public PrisonArchitect() : base( "D1350109-09FE-4458-8323-A2A087924DDF" )
        {
            this.ApplicationName = "Prison Architect";
            this.FolderName = "Prison Architect 2015 [Prison Architect]";
            this.TechnicalNameMatcher = "Prison Architect";
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
                    DestinationRoot = Environment.SpecialFolder.LocalApplicationData,
                    DestinationSubFolderPath = Path.Combine( "Introversion", "Prison Architect" ),
                    DestinationTargetName = "Campaign",
                    SourceId = "Campaign"
                },
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.LocalApplicationData,
                    DestinationSubFolderPath = Path.Combine( "Introversion", "Prison Architect" ),
                    DestinationTargetName = "saves",
                    SourceId = "saves"
                },
                new FileLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.LocalApplicationData,
                    DestinationSubFolderPath = Path.Combine( "Introversion", "Prison Architect" ),
                    DestinationTargetName = "unlocked.txt",
                    SourceId = "unlocked.txt"
                }
            };
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                this.GetConfigForWin10()
            };
            var config = this._configFactory.Get( osConfigs );
            this.Definition = this._definitionFactory.Get( config );
        }
    }
}
