using System.Drawing;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.UserProfile
{
#region not unit-tested
    public class Model
    {
        public Model( ModelParametersDTO parameters )
        {
            this.FullName = parameters.FullName;
            this.ProfilePicture = parameters.ProfilePicture;
        }


        public string FullName { get; private set; }


        public Image ProfilePicture { get; private set; }
    }
#endregion
}
