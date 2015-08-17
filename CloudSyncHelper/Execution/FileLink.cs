﻿using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal class FileLink : LinkBase
    {
        public FileLink( IProgramInfo programInfo, IFileLinkInfo fileLinkInfo, PathVariablesDTO pathVariables )
            : base( programInfo, fileLinkInfo, pathVariables ) { }

        public override void /*LinkBase.*/Undo()
        {
            File.Delete( this.Link );
        }

        protected override string /*LinkBase.*/_mkLinkParams { get { return string.Empty; } }
    }
#endregion
}
