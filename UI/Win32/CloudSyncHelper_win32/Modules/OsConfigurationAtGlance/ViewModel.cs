namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfigurationAtGlance
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( /*OsConfigurationGlance*/Model model )
        {
            this.Model = model;
            this.InitializeOperatingSystemVM();
        }

        private void InitializeOperatingSystemVM()
        {
            var osModel = this.Model.OperatingSystemModel;
            var viewModel = new OperatingSystem.ViewModel( osModel );
            this.OperatingSystemVM = viewModel;
        }

        public /*OsConfigurationGlance*/Model Model { get; private set; }

        public OperatingSystem.ViewModel OperatingSystemVM { get; private set; }
    }
#endregion
}
