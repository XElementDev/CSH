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
            this.ShowDefaultProfilePicture = model.ProfilePicture == null;
        }


        public Model Model { get; private set; }


        public bool ShowDefaultProfilePicture { get; private set; }
    }
#endregion
}
