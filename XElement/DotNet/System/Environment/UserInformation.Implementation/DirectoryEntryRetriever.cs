using System;
using System.DirectoryServices;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class DirectoryEntryRetriever : IUserInformationService
    {
        public IUserInformation CurrentUser
        {
            get
            {
                var directoryEntry = this.GetFromDirectoryEntry();
                var fullName = (string)directoryEntry.Properties["fullname"].Value;
                var userInfo = new UserInformation
                {
                    FullName = fullName
                };
                return userInfo;
            }
        }


        private DirectoryEntry GetFromDirectoryEntry()
        {
            //  --> http://www.developerzen.com/2007/06/07/getting-the-full-name-of-the-current-user/#respond
            var path = String.Format( "WinNT://{0}/{1},User", 
                                      global::System.Environment.UserDomainName, 
                                      global::System.Environment.UserName );
            DirectoryEntry userEntry = new DirectoryEntry( path );
            return userEntry;
        }
    }
#endregion
}
