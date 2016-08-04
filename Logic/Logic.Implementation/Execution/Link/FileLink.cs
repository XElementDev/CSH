using System.IO;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
#region not unit-tested
    internal class FileLink : LinkBase, ILinkInt
    {
        public FileLink( LinkParametersDTO parametersDTO )
            : base( parametersDTO ) { }

        protected override FileSystemInfo /*LinkBase.*/FileSystemInfo
        {
            get { return new FileInfo( this.LinkPath ); }
        }

        public override bool /*LinkBase.*/IsInCloud
        {
            get { return File.Exists( this.TargetPath ); }
        }

        protected override string /*LinkBase.*/MkLinkParams { get { return string.Empty; } }

        protected override void /*LinkBase.*/MoveToCloud_CopyStuff()
        {
            File.Copy( this.LinkPath, this.TargetPath );
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
