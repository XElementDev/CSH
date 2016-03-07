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

        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine( "Electronic Arts", "Die Sims 3" ),
                    DestinationTargetName = "Mods",
                    SourceId = "Mods"
                },
                new FolderLinkInfo
                {
                    DestinationRoot = Environment.SpecialFolder.MyDocuments,
                    DestinationSubFolderPath = Path.Combine( "Electronic Arts", "Die Sims 3" ),
                    DestinationTargetName = "Saves",
                    SourceId = "Saves"
                }
            };
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfiguration>
            {
                this._osConfigFactory.Get( this.GetLinksForWin10(), OsId.Win10, "[de-DE]" )
            };
            this.Definition = this._definitionFactory.Get( osConfigs );
        }
    }
}
