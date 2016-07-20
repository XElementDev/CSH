using System.Drawing;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.UserProfile
{
#region not unit-tested
    public class ModelParametersDTO
    {
        public string FullName { get; set; }


        public string Prename { get; set; }
        public bool? IsAdministrator { get; set; }




        public Image ProfilePicture { get; set; }




        public string Surname { get; set; }
        public string TechnicalName { get; set; }
    }
#endregion
}
