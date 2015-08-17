using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Execution;

namespace XElement.CloudSyncHelper
{
#region not unit-tested
    public class ExecutionLogic
    {
        public ExecutionLogic( IProgramInfo programInfo, PathVariablesDTO pathVariables )
        {
            this._pathVariables = pathVariables;
            this._programInfo = programInfo;
        }

        public IEnumerable<ILink> Config
        {
            get
            {
                var suitableConfig = OsIdHelper.GetSuitableConfig( this._programInfo.OsConfigs );
                var config = new List<ILink>();
                foreach ( ILinkInfo linkInfo in suitableConfig )
                {
                    ILink link = null;
                    if ( linkInfo is IFolderLinkInfo )
                        link = new FolderLink( this._programInfo, linkInfo as IFolderLinkInfo, this._pathVariables );
                    else
                        link = new FileLink( this._programInfo, linkInfo as IFileLinkInfo, this._pathVariables );
                    config.Add( link );
                }
                return config;
            }
        }

        public bool HasSuitableConfig()
        {
            var isThereAConfigForThisOs = this.Config != null;
            return isThereAConfigForThisOs;
        }

        public bool IsInCloud { get { return this.Config.All( c => c.IsInCloud ); } }

        public bool IsLinked { get { return this.Config.All( c => c.IsLinked ); } }

        public void Link()
        {
            var standardOutputs = new List<string>();
            foreach ( ILink link in this.Config )
            {
                link.Do();
                standardOutputs.Add( link.StandardOutput );
            }
            this.StandardOutputs = standardOutputs;
        }

        public IEnumerable<string> LinkPaths
        {
            get
            {
                var linkPaths = new List<string>();
                foreach ( ILink link in this.Config )
                {
                    linkPaths.Add( link.Link );
                }
                return linkPaths;
            }
        }

        public IEnumerable<string> StandardOutputs { get; private set; }

        public IEnumerable<string> TargetPaths
        {
            get
            {
                var targetPaths = new List<string>();
                foreach ( ILink link in this.Config )
                {
                    targetPaths.Add( link.Target );
                }
                return targetPaths;
            }
        }

        public void Unlink()
        {
            foreach ( ILink link in this.Config )
            {
                link.Undo();
            }
        }

        private PathVariablesDTO _pathVariables;
        private IProgramInfo _programInfo;
    }
#endregion
}
