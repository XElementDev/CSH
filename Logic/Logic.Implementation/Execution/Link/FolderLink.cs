using System;
using System.IO;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic.Execution.Link
{
#region not unit-tested
    internal class FolderLink : LinkBase, ILinkInt
    {
        public FolderLink( IApplicationInfo appInfo, 
                           IFolderLinkInfo folderLinkInfo, 
                           PathVariablesDTO pathVariablesDTO )
            : base( appInfo, folderLinkInfo, pathVariablesDTO ) { }

        private void AbstractSourceDestLinker( Func<string, string[]> sourcePathsGetter, 
                                               string source, 
                                               string destination, 
                                               Action<string, string> foreachAction )
        {
            var sourcePaths = sourcePathsGetter( source );
            foreach ( var sourcePath in sourcePaths )
            {
                var count = source.Length + "\\".Length;
                var directoryOffset = sourcePath.Remove( 0, count );
                var destPath = Path.Combine( destination, directoryOffset );
                foreachAction( sourcePath, destPath );
            }
        }

        // Copy all levels
        private void CopyFilesRecursively( string source, string destination )
        {
            Directory.CreateDirectory( destination );

            this.ShallowCopyFiles( source, destination );
            this.AbstractSourceDestLinker( s => Directory.GetDirectories( s ), 
                                           source, 
                                           destination, 
                                           ( s, d ) => this.CopyFilesRecursively( s, d ) );
        }

        protected override FileSystemInfo /*LinkBase.*/FileSystemInfo
        {
            get { return new DirectoryInfo( this.LinkPath ); }
        }

        public override bool /*LinkBase.*/IsInCloud
        {
            get { return Directory.Exists( this.TargetPath ); }
        }

        protected override string /*LinkBase.*/MkLinkParams { get { return "/D"; } }

        protected override void /*LinkBase.*/MoveToCloud_CopyStuff()
        {
            this.CopyFilesRecursively( this.LinkPath, this.TargetPath );
        }

        // Copy only one level
        private void ShallowCopyFiles( string source, string destination )
        {
            this.AbstractSourceDestLinker( s => Directory.GetFiles( s ),
                                           source,
                                           destination,
                                           ( s, d ) => File.Copy( s, d ) );
        }

        public override void /*LinkBase.*/Undo()
        {
            if ( Directory.Exists( this.LinkPath ) )
            {
                Directory.Delete( this.LinkPath, true );
            }
        }
    }
#endregion
}
