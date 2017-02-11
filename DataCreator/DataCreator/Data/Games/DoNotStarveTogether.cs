using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class DoNotStarveTogether : AbstractGameInfo
    {
        [ImportingConstructor]
        public DoNotStarveTogether() : base( "8E0426F4-847D-4E32-8CD3-39B0D1D2BCE6" )
        {
            this.ApplicationName = "Don't Starve Together";
            this.FolderName = "Don't Starve 2016 [Don't Starve Together]";
            this.TechnicalNameMatcher = "Don't Starve Together";
        }

        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            var destinationSubFolderPath = Path.Combine( "Klei", "DoNotStarveTogether" );

            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments, 
                    DestinationSubFolderPath = destinationSubFolderPath, 
                    DestinationTargetName = "Cluster_1", 
                    SourceId = "Cluster_1"
                },
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = destinationSubFolderPath,
                    DestinationTargetName = "Cluster_2",
                    SourceId = "Cluster_2"
                },
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = destinationSubFolderPath,
                    DestinationTargetName = "Cluster_3",
                    SourceId = "Cluster_3"
                },
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = destinationSubFolderPath,
                    DestinationTargetName = "Cluster_4",
                    SourceId = "Cluster_4"
                },
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = destinationSubFolderPath,
                    DestinationTargetName = "Cluster_5",
                    SourceId = "Cluster_5"
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
