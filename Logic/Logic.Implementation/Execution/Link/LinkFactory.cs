using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic.Execution;

namespace XElement.CloudSyncHelper.Logic
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
