namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    public interface IPriotizableIconCrawler : IIconCrawler
    {
        Reliability Reliability { get; }
    }
}
