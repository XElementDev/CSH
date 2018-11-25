using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Superhot : AbstractGameInfo
    {
        [ImportingConstructor]
        public Superhot() : base( "753DAA70-6CC6-4571-886A-4786256905BB" )
        {
            this.ApplicationName = "SUPERHOT";
            this.FolderName = "Superhot 2016 [SUPERHOT]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.UserProfile,
                    DestinationSubFolderPath = Path.Combine( "LocalLow", "SUPERHOT_Team" ),
                    DestinationTargetName = "SUPERHOT",
                    SourceId = "SUPERHOT"
                }
            };
        }


        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                this._osConfigFactory.Get( this.GetLinksForWin10(), OsId.Win10 )
            };
            this.DefinitionInfo = this._definitionFactory.Get(osConfigs);
        }
    }
}
