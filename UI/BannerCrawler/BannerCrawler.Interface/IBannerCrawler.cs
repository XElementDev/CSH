namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    public interface IBannerCrawler
    {
        ICrawlResult CrawlSingle( ICrawlInformation crawlInfo );
    }
}
