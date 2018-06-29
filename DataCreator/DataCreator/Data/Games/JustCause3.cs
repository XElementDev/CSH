using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class JustCause3 : AbstractGameInfo
    {
        [ImportingConstructor]
        public JustCause3() : base( "D829C019-30C1-454C-B0D7-654ED434F274" )
        {
            this.ApplicationName = "Just Cause 3";
            this.FolderName = "Just Cause 2015 [Just Cause 3]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        //TODO: Remove folder "0" (which is located in the "Saves" folder) as it contains the video settings.
        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments, 
                    DestinationSubFolderPath = Path.Combine( "Square Enix", "Just Cause 3" ), 
                    DestinationTargetName = "Saves", 
                    SourceId = "Saves"
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
