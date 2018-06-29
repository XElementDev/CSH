using System;
using System.DirectoryServices;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class DirectoryEntryRetriever : IUserInfoRetriever, IRoleInfoRetriever
    {
        public DirectoryEntryRetriever()
        {
            return;
        }


        public IUserInformation /*IUserInfoRetriever.*/Get()
        {
            var directoryEntry = this.GetFromDirectoryEntry();
            var fullName = (string)directoryEntry.Properties["fullname"].Value;

            var userInformation = new UserInformation
            {
                FullName = fullName,
                Role = null,
                TechnicalName = null
            };
            return userInformation;
        }

        IRoleInformation IFactory<IRoleInformation>.Get() { return this.Get(); }


        private DirectoryEntry GetFromDirectoryEntry()
        {
            //  --> http://www.developerzen.com/2007/06/07/getting-the-full-name-of-the-current-user/#respond
            var path = String.Format
            (
                "WinNT://{0}/{1},User", 
                global::System.Environment.UserDomainName, 
                global::System.Environment.UserName
            );
            DirectoryEntry userEntry = new DirectoryEntry( path );
            return userEntry;
        }
    }
#endregion
}
