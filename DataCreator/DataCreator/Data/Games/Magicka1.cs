using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Magicka1 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Magicka1() : base( "C166905A-52A3-4DA4-A6A6-61B20FE103A7" )
        {
            this.ApplicationName = "Magicka";
            this.FolderName = "Magicka 2011 [Magicka]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        // TODO: Include
        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            /*
             * Location: <install-folder>\SaveData\
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
