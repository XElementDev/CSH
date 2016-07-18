namespace XElement.DotNet.System.Environment.UserInformation
{
#region not unit-tested
    public class UserInformation : IUserInformationInt
    {
        public string Domain { get; set; }


        public string FullName { get; set; }


        public Role? Role { get; set; }


        public string TechnicalName { get; set; }
    }
#endregion
}
