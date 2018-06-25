using System;
using System.DirectoryServices;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class DirectoryEntryRetriever : IUserInformation
    {
        public DirectoryEntryRetriever()
        {
            var directoryEntry = this.GetFromDirectoryEntry();
            var fullName = (string)directoryEntry.Properties["fullname"].Value;

            this.FullName = fullName;
            this.Role = null;
            this.TechnicalName = null;
        }


        public string /*IUserInformation.*/FullName { get; private set; }


        private DirectoryEntry GetFromDirectoryEntry()
        {
            //  --> http://www.developerzen.com/2007/06/07/getting-the-full-name-of-the-current-user/#respond
            var path = String.Format( "WinNT://{0}/{1},User", 
                                      global::System.Environment.UserDomainName, 
                                      global::System.Environment.UserName );
            DirectoryEntry userEntry = new DirectoryEntry( path );
            return userEntry;
        }


        public Role? /*IUserInformation.*/Role { get; private set; }


        public string /*IUserInformation.*/TechnicalName { get; private set; }
    }
#endregion
}
