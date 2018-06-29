using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class SysEnvironmentRetriever : IUserInfoRetriever, IRoleInfoRetriever
    {
        public SysEnvironmentRetriever()
        {





            return;
        }


        public IUserInformation /*IUserInfoRetriever.*/Get()
        {
            var userInformationInt = new UserInformationInt
            {
                Domain = global::System.Environment.UserDomainName,
                FullName = null,
                Role = null,
                TechnicalName = global::System.Environment.UserName
            };
            return userInformationInt;
        }

        IRoleInformation IFactory<IRoleInformation>.Get() { return this.Get(); }
    }
#endregion
}
