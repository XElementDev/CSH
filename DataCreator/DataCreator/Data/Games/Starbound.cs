using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Starbound : AbstractGameInfo
    {
        [ImportingConstructor]
        public Starbound() : base( "E33D0478-9ABC-49DC-9FA0-C9312BC5CF91" )
        {
            this.ApplicationName = "Starbound";
            this.FolderName = "Starbound 2013 [Starbound]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        // TODO: Include
        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            /*
             * Locations: 
             *  1) <install-folder>\storage\player\
             *                                  ↑ folder link to "player" folder
             *  2) <install-folder>\storage\universe\
             *                                  ↑ folder link to "universe" folder
             * see https://pcgamingwiki.com/wiki/Starbound
             */
            return new List<AbstractLinkInfo>();
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
