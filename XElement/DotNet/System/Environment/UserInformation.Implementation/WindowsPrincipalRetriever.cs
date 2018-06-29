using System;
using System.Security.Principal;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using RoleEnum = XElement.DotNet.System.Environment.UserInformation.Role;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class WindowsPrincipalRetriever : IUserInfoRetriever, IRoleInfoRetriever
    {
        public WindowsPrincipalRetriever()
        {
            return;
        }


        public IUserInformation /*IUserInfoRetriever.*/Get()
        {
            var identity = WindowsPrincipalRetriever.GetIdentity();

            var windowsLogonName = WindowsPrincipalRetriever.GetWindowsLogonName( identity );
            var splittedLogonInfo = windowsLogonName.Split
            (
                new[] { "\\" },
                StringSplitOptions.RemoveEmptyEntries
            );

            var userInformationInt = new UserInformationInt
            {
                Domain = splittedLogonInfo[0],
                FullName = null,
                Role = WindowsPrincipalRetriever.GetRole( identity ),
                TechnicalName = splittedLogonInfo[1]
            };
            return userInformationInt;
        }

        IRoleInformation IFactory<IRoleInformation>.Get() { return this.Get(); }


        private static WindowsIdentity GetIdentity()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            return identity;
        }


        //  --> https://stackoverflow.com/questions/3600322/check-if-the-current-user-is-administrator
        //      Last visited: 2016-07-17
        private static RoleEnum GetRole( WindowsIdentity identity )
        {
            RoleEnum role = RoleEnum.User;

            WindowsPrincipal principal = new WindowsPrincipal( identity );
            var isAdmin = principal.IsInRole( WindowsBuiltInRole.Administrator );
            if ( isAdmin )
                role = RoleEnum.Administrator;

            return role;
        }


        private static string GetWindowsLogonName( WindowsIdentity identity )
        {
            var windowsLogonName = identity.Name;
            return windowsLogonName;
        }
    }
#endregion
}
