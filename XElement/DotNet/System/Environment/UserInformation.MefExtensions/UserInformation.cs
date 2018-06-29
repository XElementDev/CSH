namespace XElement.DotNet.System.Environment.UserInformation.MefExtensions
{
#region not unit-tested
    internal class UserInformation : IUserInformation
    {
        public string /*IUserInformation.*/FullName { get; set; }


        public Role? /*IUserInformation.*/Role { get; set; }


        public string /*IUserInformation.*/TechnicalName { get; set; }
    }
#endregion
}
