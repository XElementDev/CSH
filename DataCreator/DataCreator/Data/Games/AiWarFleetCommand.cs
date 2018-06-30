using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class AiWarFleetCommand : AbstractGameInfo
    {
        [ImportingConstructor]
        public AiWarFleetCommand() : base( "68718BE0-4C10-40D3-954E-3584545DFBD5" )
        {
            this.ApplicationName = "AI War: Fleet Command";
            this.FolderName = "AI War 2009 [AI War_ Fleet Command]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        // TODO: Include
        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            /*
             * Location: <install-folder>\RuntimeData\Save\
             *                                          ↑ folder link to "Save" folder
             * see https://pcgamingwiki.com/wiki/AI_War:_Fleet_Command
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
