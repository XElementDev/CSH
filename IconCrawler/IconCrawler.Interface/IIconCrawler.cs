namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    public interface IIconCrawler
    {
        ICrawlResult CrawlSingle( ICrawlInformation crawlInfo );
    }
}
