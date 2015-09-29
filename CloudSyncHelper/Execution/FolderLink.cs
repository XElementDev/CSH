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

        private void CopyFilesRecursively( string source, string destination )
        {
            Directory.CreateDirectory( destination );

            this.AbstractSourceDestLinker( s => Directory.GetFiles( s ), 
                                           source, 
                                           destination, 
                                           ( s, d ) => File.Copy( s, d ) );
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

        public override void /*LinkBase.*/MoveToCloud()
        {
            this.CopyFilesRecursively( this.LinkPath, this.TargetPath );
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
