namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    public interface IPriotizableBannerCrawler : IBannerCrawler
    {
        Reliability Reliability { get; }
    }
}
