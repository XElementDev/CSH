using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal class FileLink : LinkBase, ILink
    {
        public FileLink( IProgramInfo programInfo, IFileLinkInfo fileLinkInfo, PathVariablesDTO pathVariables )
            : base( programInfo, fileLinkInfo, pathVariables ) { }

        protected override FileSystemInfo /*LinkBase.*/FileSystemInfo
        {
            get { return new FileInfo( this.Link ); }
        }

        public override bool /*LinkBase.*/IsInCloud
        {
            get { return File.Exists( this.Target ); }
        }

        public override void /*LinkBase.*/Undo()
        {
            File.Delete( this.Link );
        }

        protected override string /*LinkBase.*/MkLinkParams { get { return string.Empty; } }
    }
#endregion
}
