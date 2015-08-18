using System;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal class FolderLink : LinkBase, ILink
    {
        public FolderLink( IProgramInfo programInfo, IFolderLinkInfo folderLinkInfo, PathVariablesDTO pathVariables )
            : base( programInfo, folderLinkInfo, pathVariables ) { }

        protected override FileSystemInfo /*LinkBase.*/FileSystemInfo
        {
            get { return new DirectoryInfo( this.Link ); }
        }

        public override bool /*LinkBase.*/IsInCloud
        {
            get { return Directory.Exists( this.Target ); }
        }

        public override void /*LinkBase.*/Undo()
        {
            // TODO: Implement undo logic for FolderLink
            throw new NotImplementedException();
        }

        protected override string /*LinkBase.*/MkLinkParams { get { return "/D"; } }
    }
#endregion
}
