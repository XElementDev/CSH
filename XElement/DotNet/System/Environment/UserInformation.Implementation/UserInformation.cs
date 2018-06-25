namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class UserInformation : IUserInformationInt
    {
        public string /*IUserInformationInt.*/Domain { get; set; }


        public string /*IUserInformationInt.*/FullName { get; set; }


        public Role? /*IUserInformationInt.*/Role { get; set; }


        public string /*IUserInformationInt.*/TechnicalName { get; set; }
    }
#endregion
}
