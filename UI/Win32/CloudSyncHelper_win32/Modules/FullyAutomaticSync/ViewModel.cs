namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
    public class ViewModel
    {
        public ViewModel( IViewModelConstructorParameters ctorParams )
        {
            this.SupportsSteamCloud = ctorParams.SupportsSteamCloud;
            this.IsLinked = ctorParams.IsInstalled && this.SupportsSteamCloud;
        }

        public bool IsLinked { get; private set; }

        public bool SupportsSteamCloud { get; private set; }
    }
}
