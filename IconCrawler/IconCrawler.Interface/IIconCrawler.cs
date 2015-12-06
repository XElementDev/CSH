using System.Drawing;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    public interface IIconCrawler
    {
        Image Crawl( ICrawlInformation crawlInfo );
    }
}
