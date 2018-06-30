using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Hammerwatch : AbstractGameInfo
    {
        [ImportingConstructor]
        public Hammerwatch() : base( "374B5E01-49D3-460C-BB4E-7A676DAD22F3" )
        {
            this.ApplicationName = "Hammerwatch";
            this.FolderName = "Hammerwatch 2013 [Hammerwatch]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        // TODO: Include
        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            /*
             * No clue where the save files are stored
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
