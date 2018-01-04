using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export(typeof(AbstractGameInfo))]
    internal class DefendYourLife : AbstractGameInfo
    {
        [ImportingConstructor]
        public DefendYourLife() : base( "A0DE5CE4-C59C-479C-9FF6-D0B5E9119561" )
        {
            this.ApplicationName = "Defend Your Life";
            this.FolderName = "Defend Your Life 2015 [Defend Your Life]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }


        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            /*
             * Steam Cloud is not supported (anymore): http://steamcommunity.com/app/357780/discussions/0/617335934134432320/
             * Manual back-ups are not possible: http://steamcommunity.com/app/357780/discussions/0/611703898450155035/
             */
            return new List<AbstractLinkInfo>();
        }


        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                this._osConfigFactory.Get( this.GetLinksForWin10(), OsId.Win10, "Defend Your Life" )
            };
            this.DefinitionInfo = this._definitionFactory.Get(osConfigs);
        }
    }
}
