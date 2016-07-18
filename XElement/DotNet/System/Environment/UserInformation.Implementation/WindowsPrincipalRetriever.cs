using System.Security.Principal;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class WindowsPrincipalRetriever : IUserInformationService
    {
        public IUserInformation CurrentUser
        {
            get
            {
                var role = WindowsPrincipalRetriever.Role;
                var userInfo = new UserInformation
                {
                    Role = role
                };
                return userInfo;
            }
        }


        //  --> https://stackoverflow.com/questions/3600322/check-if-the-current-user-is-administrator
        //      Last visited: 2016-07-17
        private static Role Role
        {
            get
            {
                Role result = Role.User;

                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal( identity );
                var isAdmin = principal.IsInRole( WindowsBuiltInRole.Administrator );
                if ( isAdmin )
                    result = Role.Administrator;

                return result;
            }
        }
    }
#endregion
}
