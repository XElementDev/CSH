namespace XElement.DotNet.System.Environment.UserInformation
{
    public interface IUserInformation : IRoleInformation
    {
        string FullName { get; }


        string TechnicalName { get; }
    }
}
