namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( /*SemiautomaticSync.*/Model semiautoSyncModel )
        {
            this.Model = semiautoSyncModel;
            this.IsAConfigurationAvailable = this.Model.SupportedOSsVM.IsWindows10Supported || 
                                             this.Model.SupportedOSsVM.IsWindows81Supported || 
                                             this.Model.SupportedOSsVM.IsWindows8Supported || 
                                             this.Model.SupportedOSsVM.IsWindows7Supported;
        }

        public bool IsAConfigurationAvailable { get; private set; }

        public /*SemiautomaticSync.*/Model Model { get; private set; }
    }
#endregion
}
