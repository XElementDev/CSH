namespace XElement.CloudSyncHelper.UI.Win32.Modules.FullyAutomaticSync
{
    public class ViewModel
    {
        public ViewModel( IViewModelConstructorParameters ctorParams )
        {
            this.SupportsSteamCloud = ctorParams.SupportsSteamCloud;
        }

        public bool IsLinked { get { return this.SupportsSteamCloud; } }

        public bool SupportsSteamCloud { get; private set; }
    }
}
