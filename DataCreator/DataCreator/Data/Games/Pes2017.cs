using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Pes2017 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Pes2017() : base( "36FB54CC-18DD-4250-907F-B2372BA9AE56" )
        {
            this.ApplicationName = "Pro Evolution Soccer 2017";
            this.FolderName = "PES 2016 [Pro Evolution Soccer 2017]";
            this.TechnicalNameMatcher = "Pro Evolution Soccer 2017";
        }

        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine( "KONAMI", "Pro Evolution Soccer 2017" ),
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
        }
    }
}
