using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic.Execution;
using XElement.CloudSyncHelper.Logic.Execution.Link;

namespace XElement.CloudSyncHelper.Logic
{
    public class OsConfiguration : IOsConfigurationInt
    {
        public float IsLinkedRatio
        {
            get
            {
                float ratio = 0F;
                if ( this._links.Count != 0 )
                {
                    int potentialLinks = this._links.Count;
                    int realizedLinks = this._links.Count( l => l.IsLinked );
                    ratio = 1F * realizedLinks / potentialLinks;
                }
                return ratio;
            }
        }


#region not unit-tested
        public OsConfiguration( OsConfigurationParametersDTO @params, 
                                OsConfigurationDependenciesDTO dependencies )
        {
            this._appInfo = @params.ApplicationInfo;
            this._linkFactory = dependencies.LinkFactory;
            this._osConfigInfo = @params.OsConfigurationInfo;
            this._pathVariablesDTO = @params.PathVariablesDTO;

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
                var link = this._linkFactory.Get( this._appInfo, linkInfo, this._pathVariablesDTO );
                var linkInt = link as ILinkInt;
                this._links.Add( linkInt );
            }
        }


        public bool IsInCloud { get { return this._links.All( l => l.IsInCloud ); } }


        public bool IsLinked { get { return this._links.All( l => l.IsLinked ); } }


        public void MoveToCloud()
        {
            foreach ( ILinkInt link in this._links )
            {
                link.MoveToCloud();
            }
        }


        public void Undo()
        {
            foreach ( ILinkInt link in this._links )
            {
                link.Undo();
            }
        }


        private IApplicationInfo _appInfo;
        private ILinkFactory _linkFactory;
        private IList<ILinkInt> _links;
        private IOsConfigurationInfo _osConfigInfo;
        private PathVariablesDTO _pathVariablesDTO;
    }
#endregion
}
