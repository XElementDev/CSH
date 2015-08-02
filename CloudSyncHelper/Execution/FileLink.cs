using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper
{
#region not unit-tested
    public class FileLink : LinkBase
    {
        public FileLink( IProgramInfo programInfo, IFileLinkInfo fileLinkInfo ) 
            : base( programInfo, fileLinkInfo ) { }

        protected override string /*LinkBase.*/_mkLinkParams { get { return string.Empty; } }
    }
#endregion
}
