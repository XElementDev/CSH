using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class EuroTruckSimulator2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public EuroTruckSimulator2() : base( "C3187302-9293-4BA2-9EBB-206218BD3196" )
        {
            this.ApplicationName = "Euro Truck Simulator 2";
            this.FolderName = "Euro Truck Simulator 2012 [Euro Truck Simulator 2]";
            this.TechnicalNameMatcher = "Euro Truck Simulator 2";
        }

        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments, 
                    DestinationSubFolderPath = Path.Combine( "Euro Truck Simulator 2" ), 
                    DestinationTargetName = "profiles", 
                    SourceId = "profiles"
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
