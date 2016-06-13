using System;
using System.DirectoryServices.AccountManagement;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class PrincipalContextRetriever : IUserInformationService
    {
        public IUserInformation CurrentUser
        {
            get
            {
                throw new NotImplementedException();
                //var userPrincipal = this.GetFromPrincipalContext();
                //var userInfo = new UserInformation
                //{
                //};
                //return userInfo;
            }
        }


        private UserPrincipal GetFromPrincipalContext()
        {
            //  --> http://www.dotnetspark.com/links/14003-systemdirectoryservicesaccountmanagement.aspx
            var domainName = global::System.Environment.UserDomainName;
            var userName = global::System.Environment.UserName;
            var context = new PrincipalContext( ContextType.Domain, domainName, userName );
            UserPrincipal user = new UserPrincipal( context );
            user = UserPrincipal.FindByIdentity( context, userName );
            return user;
        }
    }
#endregion
}
