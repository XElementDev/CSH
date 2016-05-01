namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( OsConfiguration.Model model )
        {
            this.Model = model;
        }

        public Model Model { get; private set; }
    }
#endregion
}
