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
    internal class TheSims3 : AbstractGameInfo
    {
        [ImportingConstructor]
        public TheSims3() : base( "0AED2DDF-6109-401F-9467-484FA853450F" )
        {
            this.ApplicationName = "The Sims 3";
            this.FolderName = "The Sims 2009 [The Sims 3]";
            this.TechnicalNameMatcher = String.Format( ".*Sims{0} 3",
                                                       SpecialCharacters.TRADEMARK );
        }

        private List<AbstractLinkInfo> GetLinksForWin10_deDE()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine( "Electronic Arts", "Die Sims 3" ),
                    DestinationTargetName = "Saves",
                    SourceId = "Saves"
                }
            };
        }

        private List<AbstractLinkInfo> GetLinksForWin10_deDE_InclMods()
        {
            var configuration = this.GetLinksForWin10_deDE();
            configuration.Add
                (
                    new FolderLinkInfo
                    {
                        DestinationRoot = Environment.SpecialFolder.MyDocuments,
                        DestinationSubFolderPath = Path.Combine( "Electronic Arts", "Die Sims 3" ),
                        DestinationTargetName = "Mods",
                        SourceId = "Mods"
                    }
                );
            return configuration;
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                this._osConfigFactory.Get( this.GetLinksForWin10_deDE(), OsId.Win10, "[de-DE]" ), 
                this._osConfigFactory.Get( this.GetLinksForWin10_deDE_InclMods(), OsId.Win10, "[de-DE] mit Mods" )
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
        }
    }
}
