using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic.Execution;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class OsConfiguration : IOsConfiguration
    {
        public OsConfiguration( IOsConfigurationParameters @params, 
                                IOsConfigurationDependencies dependencies )
        {
            this._appInfo = @params.ApplicationInfo;
            this._osConfigInfo = @params.OsConfigurationInfo;
            this._pathVariables = @params.PathVariables;

            this.InitializeLinks();
        }

        public void Do()
        {
            foreach ( ILinkInt link in this._links )
            {
                link.Do();
            }
        }

        private void InitializeLinks()
        {
            var capacity = this._osConfigInfo.Links.Count;
            this._links = new List<ILinkInt>( capacity );
            foreach ( var linkInfo in this._osConfigInfo.Links )
            {
                ILinkInt link = null;
                if ( linkInfo is IFolderLinkInfo )
                    link = new FolderLink( this._appInfo, linkInfo as IFolderLinkInfo, this._pathVariables );
                else
                    link = new FileLink( this._appInfo, linkInfo as IFileLinkInfo, this._pathVariables );
                this._links.Add( link );
            }
        }

        public bool IsInCloud { get { return this._links.All( l => l.IsInCloud ); } }

        public bool IsLinked { get { return this._links.All( l => l.IsInCloud ); } }

        public void Undo()
        {
            foreach ( ILinkInt link in this._links )
            {
                link.Undo();
            }
        }

        private IApplicationInfo _appInfo;
        private IList<ILinkInt> _links;
        private IOsConfigurationInfo _osConfigInfo;
        private IPathVariables _pathVariables;
    }
#endregion
}
