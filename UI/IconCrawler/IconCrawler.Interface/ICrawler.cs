namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    public interface ICrawler
    {
        ICrawlResult CrawlSingle( ICrawlInformation input );
    }
}
