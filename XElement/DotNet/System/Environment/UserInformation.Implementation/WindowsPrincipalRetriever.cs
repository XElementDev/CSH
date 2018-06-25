using System;
using System.Security.Principal;
using RoleEnum = XElement.DotNet.System.Environment.UserInformation.Role;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class WindowsPrincipalRetriever : IUserInformationInt
    {
        public WindowsPrincipalRetriever()
        {
            var identity = WindowsPrincipalRetriever.GetIdentity();

            var windowsLogonName = WindowsPrincipalRetriever.GetWindowsLogonName( identity );
            var splittedLogonInfo = windowsLogonName.Split( new[] { "\\" }, 
                                                            StringSplitOptions.RemoveEmptyEntries );

            this.Domain = splittedLogonInfo[0];
            this.FullName = null;
            this.Role = WindowsPrincipalRetriever.GetRole( identity );
            this.TechnicalName = splittedLogonInfo[1];

            return;
        }


        public string /*IUserInformationInt.*/Domain { get; private set; }


        public string /*IUserInformationInt.*/FullName { get; private set; }


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


        public RoleEnum? /*IUserInformationInt.*/Role { get; private set; }


        public string /*IUserInformationInt.*/TechnicalName { get; private set; }
    }
#endregion
}
