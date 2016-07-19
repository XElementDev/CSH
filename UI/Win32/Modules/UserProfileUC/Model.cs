using XElement.DotNet.System.Environment.UserInformation;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.UserProfile
{
#region not unit-tested
    public class Model
    {
        public Model( ModelParametersDTO parameters )
        {
            this.FullName = parameters.FullName;
            this.Role = parameters.Role;
        }


        public string FullName { get; private set; }


        public Role? Role { get; private set; }
    }
#endregion
}
