using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic.Execution;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class LinkFactory : ILinkFactory
    {
        public LinkFactory() { }

        public ILink Get( IApplicationInfo appInfo, 
                          ILinkInfo linkInfo, 
                          IPathVariables pathVariables )
        {
            var linkParamsDTO = new LinkParametersDTO
            {
                ApplicationInfo = appInfo, 
                LinkInfo = linkInfo, 
                PathVariables = pathVariables
            };
            return this.Get( linkParamsDTO );
        }
        public ILink Get( LinkParametersDTO linkParametersDTO )
        {
            ILink link = null;

            if ( linkParametersDTO.LinkInfo is IFolderLinkInfo )
            {
                link = new FolderLink( linkParametersDTO.ApplicationInfo,
                                       linkParametersDTO.LinkInfo as IFolderLinkInfo,
                                       linkParametersDTO.PathVariables );
            }
            else
            {
                link = new FileLink( linkParametersDTO.ApplicationInfo, 
                                       linkParametersDTO.LinkInfo as IFileLinkInfo, 
                                       linkParametersDTO.PathVariables );
            }

            return link;
        }
    }
#endregion
}
