using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class TalesFromTheBorderlands : AbstractGameInfo
    {
        [ImportingConstructor]
        public TalesFromTheBorderlands() : base( "95DA055D-201B-4089-958A-51536052EFF8" )
        {
            this.ApplicationName = "Tales from the Borderlands";
            this.FolderName = "Borderlands 2014-2015 [Tales from the Borderlands]";
            this.TechnicalNameMatcher = "Tales from the Borderlands";
        }

        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments, 
                    DestinationSubFolderPath = "Telltale Games", 
                    DestinationTargetName = "Tales from the Borderlands", 
                    SourceId = "Tales from the Borderlands"
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
