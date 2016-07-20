namespace XElement.DotNet.System.Environment.UserInformation
{
    public interface IUserInformation
    {
        string FullName { get; }


        Role? Role { get; }


        string TechnicalName { get; }
    }
}
