using System.IO;

namespace XElement.CloudSyncHelper
{
#region not unit-tested
    //  --> Based on:   https://stackoverflow.com/questions/1485155/check-if-a-file-is-real-or-a-symbolic-link
    //                  https://stackoverflow.com/questions/1395205/better-way-to-check-if-path-is-a-file-or-a-directory
    //      Last visited: 2015-08-06
    public /*static*/ class SymbolicLinkHelper
    {
        public SymbolicLinkHelper() { }

        private bool IsADirectory( string path )
        {
            var fileAttributes = File.GetAttributes( path );
            return fileAttributes.HasFlag( FileAttributes.Directory );
        }

        public bool IsSymbolicLink( string path )
        {
            if ( File.Exists( path ) )
            {
                FileSystemInfo fileOrDirInfo = null;
                if( this.IsADirectory( path ) )
                {
                    fileOrDirInfo = new DirectoryInfo( path );
                }
                else
                {
                    fileOrDirInfo = new FileInfo( path );
                }
                return this.IsSymbolicLink( fileOrDirInfo.Attributes );
            }
            return false;
        }
        private bool IsSymbolicLink( FileAttributes fileAttributes )
        {
            return fileAttributes.HasFlag( FileAttributes.ReparsePoint );
        }
    }
#endregion
}
