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

            if ( linkParametersDTO.LinkInfo is IFolderLinkInfo )
            {
                link = new FolderLink( linkParametersDTO.ApplicationInfo,
                                       linkParametersDTO.LinkInfo as IFolderLinkInfo,
                                       linkParametersDTO.PathVariablesDTO );
            }
            else
            {
                link = new FileLink( linkParametersDTO.ApplicationInfo, 
                                       linkParametersDTO.LinkInfo as IFileLinkInfo, 
                                       linkParametersDTO.PathVariablesDTO );
            }

            return link;
        }
    }
#endregion
}
