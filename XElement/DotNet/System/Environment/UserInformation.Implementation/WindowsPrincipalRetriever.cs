using System.Security.Principal;
using RoleEnum = XElement.DotNet.System.Environment.UserInformation.Role;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class WindowsPrincipalRetriever : IRoleInformation
    {
        public WindowsPrincipalRetriever()
        {
            this.Role = WindowsPrincipalRetriever.GetRole();
        }


        public RoleEnum? /*IRoleInformation.*/Role { get; private set; }


        //  --> https://stackoverflow.com/questions/3600322/check-if-the-current-user-is-administrator
        //      Last visited: 2016-07-17
        private static RoleEnum GetRole()
        {
            RoleEnum result = RoleEnum.User;

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal( identity );
            var isAdmin = principal.IsInRole( WindowsBuiltInRole.Administrator );
            if ( isAdmin )
                result = RoleEnum.Administrator;

            return result;
        }
    }
#endregion
}
