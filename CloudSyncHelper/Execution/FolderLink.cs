using System;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal class FolderLink : LinkBase
    {
        public FolderLink( IProgramInfo programInfo, IFolderLinkInfo folderLinkInfo, PathVariablesDTO pathVariables )
            : base( programInfo, folderLinkInfo, pathVariables ) { }

        public override void /*LinkBase.*/Undo()
        {
            // TODO: Check for FolderLink logic
            throw new NotImplementedException();
        }

        protected override string /*LinkBase.*/_mkLinkParams { get { return "/D"; } }
    }
#endregion
}
