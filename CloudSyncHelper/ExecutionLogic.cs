using System;
using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper
{
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

        public void Link()
        {
            // TODO: Implement link
            throw new NotImplementedException();
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
            // TODO: implement unlink
            throw new NotImplementedException();
        }

        private PathVariablesDTO _pathVariables;
        private IProgramInfo _programInfo;
    }
}
