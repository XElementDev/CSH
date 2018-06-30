using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class CodMw3 : AbstractGameInfo
    {
        [ImportingConstructor]
        public CodMw3() : base( "5015F2D9-3547-4958-8CBE-CDF8E91B43A1" )
        {
            this.ApplicationName = "Call of Duty: Modern Warfare 3";
            this.FolderName = "Call of Duty 2011 [Call of Duty_ Modern Warfare 3]";
            this.TechnicalNameMatcher = this.ApplicationName;
            return;
        }


        // TODO: Include
        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            /*
             * Location: <install-folder>\players2\save\
             *                                      ↑ folder link to "save" folder
             * see https://pcgamingwiki.com/wiki/Call_of_Duty:_Modern_Warfare_3
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
