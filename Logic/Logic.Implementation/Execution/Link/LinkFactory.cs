using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
#region not unit-tested
    public class LinkFactory : ILinkFactory
    {
        public LinkFactory() { }

        public ILink Get( ILinkParameters @params )
        {
            ILink link = null;

            if ( @params.LinkInfo is IFolderLinkInfo )
            {
                link = new FolderLink( @params.ApplicationInfo,
                                       @params.LinkInfo as IFolderLinkInfo,
                                       @params.PathVariables );
            }
            else
            {
                link = new FileLink( @params.ApplicationInfo, 
                                       @params.LinkInfo as IFileLinkInfo, 
                                       @params.PathVariables );
            }

            return link;
        }
    }
#endregion
}
