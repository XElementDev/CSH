using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Execution
{
#region not unit-tested
    internal class FileLink : LinkBase, ILink
    {
        public FileLink( IProgramInfo programInfo, IFileLinkInfo fileLinkInfo, PathVariablesDTO pathVariables )
            : base( programInfo, fileLinkInfo, pathVariables ) { }

        public override bool /*LinkBase.*/IsInCloud
        {
            get { return File.Exists( this.Target ); }
        }

        public override bool /*LinkBase.*/IsLinked
        {
            get
            {
                var dirInfo = new FileInfo( this.Link );
                var attr = dirInfo.Attributes;
                return new SymbolicLinkHelper().IsSymbolicLink( attr );
            }
        }

        public override void /*LinkBase.*/Undo()
        {
            File.Delete( this.Link );
        }

        protected override string /*LinkBase.*/_mkLinkParams { get { return string.Empty; } }
    }
#endregion
}
