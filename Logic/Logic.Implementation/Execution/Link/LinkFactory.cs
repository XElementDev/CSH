using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
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
                link = new FolderLink( linkParametersDTO );
            }
            else
            {
                link = new FileLink( linkParametersDTO );
            }

            return link;
        }
    }
#endregion
}
