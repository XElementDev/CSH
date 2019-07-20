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
    internal class LegoIncredibles : AbstractGameInfo
    {
        [ImportingConstructor]
        public LegoIncredibles() : base( "7B93FF82-3FB1-4421-9D30-EA5AA0FE2591" )
        {
            this.ApplicationName = "LEGO The Incredibles";
            this.FolderName = $"LEGO 2018 [{this.ApplicationName}]";
            this.TechnicalNameMatcher = $"LEGO{SpecialCharacters.REGISTERED_TRADEMARK} The Incredibles";
            // SteamID: 818320
            return;
        }


        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.ApplicationData,
                    DestinationSubFolderPath = Path.Combine
                    (
                        "Warner Bros. Interactive Entertainment",
                        "LEGO The Incredibles"
                    ),
                    DestinationTargetName = "SAVEDGAMES",
                    SourceId = "SAVEDGAMES"
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
