using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper
{
#region not unit-tested
    public class FolderLink : LinkBase
    {
        public FolderLink( IProgramInfo programInfo, IFolderLinkInfo folderLinkInfo ) 
            : base( programInfo, folderLinkInfo ) { }

        protected override string /*LinkBase.*/_mkLinkParams { get { return "/D"; } }
    }
#endregion
}
