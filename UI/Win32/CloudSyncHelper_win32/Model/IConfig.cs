namespace XElement.CloudSyncHelper.UI.Win32.Model
{
    public interface IConfig
    {
        string PathToBannerCache { get; }
        string PathToIconCache { get; }
        string PathToSyncDataCache { get; }
        string PathToSyncFolder { get; }
        string UplayAccountName { get; }
        string UserName { get; }
    }
}
