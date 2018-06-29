using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Risen2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Risen2() : base( "A9B69AC8-4A31-4856-9830-4957E6A4C9AD" )
        {
            this.ApplicationName = "Risen 2 - Dark Waters";
            this.FolderName = "Risen 2012 [Risen 2 - Dark Waters]";
            this.TechnicalNameMatcher = this.ApplicationName;
        }

        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                //new FolderLinkInfo
                //{
                //    DestinationRoot = default( Environment.SpecialFolder ),//TODO: <X>:\Users\<User>\Saved Games
                //    DestinationSubFolderPath = "Risen2",
                //    DestinationTargetName = "SaveGames",
                //    SourceId = "SaveGames"
                //}
            };
        }

        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                this._osConfigFactory.Get( this.GetLinksForWin10(), OsId.Win10 )
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
        }
    }
}
