using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Pes2018 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Pes2018() : base( "385CB477-72A2-4EDF-8BE4-B1AD92509817" )
        {
            this.ApplicationName = "Pro Evolution Soccer 2018";
            this.FolderName = $"PES 2017 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = "PRO EVOLUTION SOCCER 2018";
            // SteamID: 592580
            return;
        }


        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine( "KONAMI", "PRO EVOLUTION SOCCER 2018" ),
                    DestinationTargetName = "save",
                    SourceId = "save"
                }
            };
        }


        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                this._osConfigFactory.Get( this.GetLinksForWin10(), OsId.Win10 )
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
            return;
        }
    }
}
