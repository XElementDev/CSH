using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
#region not unit-tested
    public class LinkFactory : ILinkFactory
    {
        public LinkFactory( MkLink.IFactory mkLinkExecutorFactory )
        {
            this._mkLinkExecutorFactory = mkLinkExecutorFactory;
        }


        public ILink Get( IApplicationInfo appInfo, 
                          ILinkInfo linkInfo, 
                          PathVariablesDTO pathVariablesDTO )
        {
            var linkParamsDTO = new LinkParametersDTO
            {
                ApplicationInfo = appInfo, 
                LinkInfo = linkInfo, 
                PathVariablesDTO = pathVariablesDTO
            };
            return this.Get( linkParamsDTO );
        }

        public ILink Get( LinkParametersDTO linkParametersDTO )
        {
            ILink link = null;

            var dependenciesDTO = new Link.DependenciesDTO
            {
                MkLinkExecutorFactory = this._mkLinkExecutorFactory
            };
            if ( linkParametersDTO.LinkInfo is IFolderLinkInfo )
            {
                link = new FolderLink( linkParametersDTO, dependenciesDTO );
            }
            else
            {
                link = new FileLink( linkParametersDTO, dependenciesDTO );
            }

            return link;
        }


        protected MkLink.IFactory _mkLinkExecutorFactory;
    }
#endregion
}
