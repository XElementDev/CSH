using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Execution;

namespace XElement.CloudSyncHelper
{
#region not unit-tested
    public class ExecutionLogic
    {
        public ExecutionLogic( IApplicationInfo appInfo, 
                               PathVariablesDTO pathVariables, 
                               ConfigForOsHelper cfg4OsHelper )
        {
            this._configForOsHelper = cfg4OsHelper;
            this._pathVariables = pathVariables;
            this._appInfo = appInfo;

            this.Initialize();
        }

        public IEnumerable<ILink> Config { get; private set; }

        public bool HasSuitableConfig { get; private set; }

        private void Initialize()
        {
            this.Initialize_Config();
            this.Initialize_HasSuitableConfig();
            this.IsInCloud = this.Config.Count() != 0 && this.Config.All( c => c.IsInCloud );
            this.IsLinked = this.Config.Count() != 0 && this.Config.All( c => c.IsLinked );
        }

        private void Initialize_Config()
        {
            var definition = this._appInfo.Definition;
            var osConfigs = (definition != default( IDefinition ) ?
                                definition.OsConfigs :
                                new List<IOsConfiguration>());
            var suitableConfig = this._configForOsHelper.GetSuitableConfig( osConfigs );
            var config = new List<ILink>();
            foreach ( ILinkInfo linkInfo in suitableConfig )
            {
                ILink link = null;
                if ( linkInfo is IFolderLinkInfo )
                    link = new FolderLink( this._appInfo, linkInfo as IFolderLinkInfo, this._pathVariables );
                else
                    link = new FileLink( this._appInfo, linkInfo as IFileLinkInfo, this._pathVariables );
                config.Add( link );
            }
            this.Config = config;
        }

        private void Initialize_HasSuitableConfig()
        {
            var isThereAConfigForThisOs = this.Config.Count() != 0;
            this.HasSuitableConfig = isThereAConfigForThisOs;
        }

        public bool IsInCloud { get; private set; }

        public bool IsLinked { get; private set; }

        public void Link()
        {
            foreach ( ILink link in this.Config )
            {
                link.Do();
            }
        }

        public void MoveToCloud()
        {
            foreach ( ILink link in this.Config )
            {
                link.MoveToCloud();
            }
        }

        public void Unlink()
        {
            foreach ( ILink link in this.Config )
            {
                link.Undo();
            }
        }

        private IApplicationInfo _appInfo;
        private ConfigForOsHelper _configForOsHelper;
        private PathVariablesDTO _pathVariables;
    }
#endregion
}
