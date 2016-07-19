using XElement.DotNet.System.Environment.UserInformation;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.UserProfile
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this.Model = model;
            this.Initialize( model );
        }


        private void Initialize( Model model )
        {
            this.IsAdmin = model.Role == Role.Administrator;
        }


        public bool IsAdmin { get; private set; }


        public Model Model { get; private set; }
    }
#endregion
}
