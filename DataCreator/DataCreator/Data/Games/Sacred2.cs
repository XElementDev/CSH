using System.Collections.Generic;
using System.ComponentModel.Composition;
using XElement.CloudSyncHelper.Serialization.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataCreator.Data.Games
{
    [Export( typeof( AbstractGameInfo ) )]
    internal class Sacred2 : AbstractGameInfo
    {
        [ImportingConstructor]
        public Sacred2() : base( "924637E9-DFB9-4A71-8A51-687DD56177D7" )
        {
            this.ApplicationName = "Sacred 2: Fallen Angel";
            this.FolderName = "Sacred 2008 [Sacred 2_ Fallen Angel]";
            this.TechnicalNameMatcher = "Sacred 2 Gold";
        }


        private List<AbstractLinkInfo> GetLinksForWin10()
        {
            return new List<AbstractLinkInfo>
            {
                //new FolderLinkInfo
                //{
                //    DestinationRoot = default( Environment.SpecialFolder ),//TODO: <X>:\Users\<User>\Saved Games
                //    DestinationSubFolderPath = "Ascaron Entertainment",
                //    DestinationTargetName = "Sacred 2",
                //    SourceId = "Sacred_2"
                //}
            };
        }


        protected override void OnImportsSatisfied()
        {
            var osConfigs = new List<OsConfigurationInfo>
            {
                this._osConfigFactory.Get( this.GetLinksForWin10(), OsId.Win10, "Sacred 2 Gold" )
            };
            this.DefinitionInfo = this._definitionFactory.Get( osConfigs );
        }
    }
}
