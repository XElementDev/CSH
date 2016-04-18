using System;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution
{
#region not unit-tested
    internal class FileLink : LinkBase, ILink
    {
        public FileLink( IApplicationInfo appInfo, 
                         IFileLinkInfo fileLinkInfo, 
                         IPathVariables pathVariables )
            : base( appInfo, fileLinkInfo, pathVariables ) { }

        protected override FileSystemInfo /*LinkBase.*/FileSystemInfo
        {
            get { return new FileInfo( this.LinkPath ); }
        }

        public override bool /*LinkBase.*/IsInCloud
        {
            get { return File.Exists( this.TargetPath ); }
        }

        protected override string /*LinkBase.*/MkLinkParams { get { return string.Empty; } }

        public override void /*LinkBase.*/MoveToCloud()
        {
            // TODO: MoveToCloud for files
            throw new NotImplementedException();
        }

        public override void /*LinkBase.*/Undo()
        {
            if ( File.Exists( this.LinkPath ) )
            {
                File.Delete( this.LinkPath );
            }
        }
    }
#endregion
}
