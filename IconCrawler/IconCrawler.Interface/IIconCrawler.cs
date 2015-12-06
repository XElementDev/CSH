using System.Collections.Generic;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    public interface IIconCrawler
    {
        IEnumerable<ICrawlResult> Crawl( IEnumerable<ICrawlInformation> crawlInfos );
    }
}
