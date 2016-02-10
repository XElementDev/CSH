namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    public interface IIconCrawler
    {
        ICrawlResult CrawlSingle( ICrawlInformation crawlInfo );
    }
}
