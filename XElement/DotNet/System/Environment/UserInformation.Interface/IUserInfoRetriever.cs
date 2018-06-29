using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.DotNet.System.Environment.UserInformation
{
    public interface IUserInfoRetriever : IFactory<IUserInformation>
    {
    }
}
