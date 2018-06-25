namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class SysEnvironmentRetriever : IUserInformationInt
    {
        public SysEnvironmentRetriever()
        {
            this.Domain = global::System.Environment.UserDomainName;
            this.FullName = null;
            this.Role = null;
            this.TechnicalName = global::System.Environment.UserName;

            return;
        }


        public string /*IUserInformationInt.*/Domain { get; private set; }


        public string /*IUserInformationInt.*/FullName { get; private set; }


        public Role? /*IUserInformationInt.*/Role { get; private set; }


        public string /*IUserInformationInt.*/TechnicalName { get; private set; }
    }
#endregion
}
