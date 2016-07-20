
namespace XElement.CloudSyncHelper.UI.Win32.Modules.UserProfile
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( Model model )
        {
            this.Model = model;
            this.Initialize();
        }




        private void Initialize()
        {
        }


        public Model Model { get; private set; }
    }
#endregion
}
