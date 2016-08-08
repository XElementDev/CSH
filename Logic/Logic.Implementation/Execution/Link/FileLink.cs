using System.IO;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
#region not unit-tested
    internal class FileLink : LinkBase, ILinkInt
    {
        public FileLink( LinkParametersDTO parametersDTO, 
                         DependenciesDTO dependenciesDTO )
            : base( parametersDTO, dependenciesDTO ) { }


        protected override FileSystemInfo /*LinkBase.*/FileSystemInfo
        {
            get { return new FileInfo( this.LinkPath ); }
        }


        public override bool /*LinkBase.*/IsInCloud
        {
            get { return File.Exists( this.TargetPath ); }
        }


        protected override MkLink.Type /*LinkBase.*/MkLinkType
        {
            get { return MkLink.Type.FILE_LINK; }
        }


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
