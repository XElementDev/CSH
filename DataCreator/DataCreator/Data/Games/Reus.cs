using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Reus : AbstractGameInfo
    {
        [ImportingConstructor]
        public Reus() : base( "DE8BF438-D9D5-442B-A1E9-93685B4ED382" )
        {
            this.ApplicationName = "Reus";
            this.FolderName = "Reus 2013 [Reus]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            var destTargetName = "Saves";
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine("Reus"),
                    DestinationTargetName = destTargetName,
                    SourceId = destTargetName
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
