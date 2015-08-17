﻿using System;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal class FolderLink : LinkBase, ILink
    {
        public FolderLink( IProgramInfo programInfo, IFolderLinkInfo folderLinkInfo, PathVariablesDTO pathVariables )
            : base( programInfo, folderLinkInfo, pathVariables ) { }

        public override bool /*LinkBase.*/IsInCloud
        {
            get { return Directory.Exists( this.Target ); }
        }

        public override void /*LinkBase.*/Undo()
        {
            // TODO: Check for FolderLink logic
            throw new NotImplementedException();
        }

        protected override string /*LinkBase.*/_mkLinkParams { get { return "/D"; } }
    }
#endregion
}
