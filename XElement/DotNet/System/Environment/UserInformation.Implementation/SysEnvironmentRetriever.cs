namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class SysEnvironmentRetriever : IUserInformationService
    {
        public IUserInformation CurrentUser
        {
            get
            {
                var userInfo = new UserInformation
                {
                    Domain = global::System.Environment.UserDomainName, 
                    TechnicalName = global::System.Environment.UserName
                };
                return userInfo;

                //System.Security.Principal.WindowsIdentity.GetCurrent()

                //Environment.

                ////  --> https://stackoverflow.com/questions/3471635/get-first-name-last-name-of-logedin-windows-user
                //UserPrincipal userPrincipal = UserPrincipal.Current;
                //var name = userPrincipal.DisplayName;
                //var surname = userPrincipal.Surname;

                ////  --> http://www.codeproject.com/Questions/354321/Get-User-Image-for-Windows-Login-user
                //var imageFile = new FileInfo( Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) +
                //    @"\Microsoft\User Account Pictures\" + Environment.UserDomainName + "+" + Environment.UserName + ".dat" );

                //var bla = WindowsIdentity.GetCurrent( TokenAccessLevels.Read );
                //bla.

                ////  --> https://stackoverflow.com/questions/12113706/filenotfoundexception-at-system-directoryservices-interop-unsafenativemethods-ia
                //new PrincipalContext(ContextType.Machine, Environment.MachineName).
            }
        }
    }
#endregion
}
