using System.IO;
using XElement.CloudSyncHelper.ReparsePointAdapter;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    //  --> Based on:   https://stackoverflow.com/questions/1485155/check-if-a-file-is-real-or-a-symbolic-link
    //                  https://stackoverflow.com/questions/1395205/better-way-to-check-if-path-is-a-file-or-a-directory
    //      Last visited: 2015-08-06
    public /*static*/ class SymbolicLinkHelper
    {
        public SymbolicLinkHelper() { }

        public string GetSymbolicLinkTarget( string symbolicLinkPath )
        {
            return new ReparsePointHelper().GetTarget( symbolicLinkPath );
        }

        public bool IsSymbolicLink( FileAttributes fileAttributes )
        {
            var isError = (int)fileAttributes == -1;
            var isSymbolicLink = fileAttributes.HasFlag( FileAttributes.ReparsePoint );
            return !isError && isSymbolicLink;
        }
    }
#endregion
}
