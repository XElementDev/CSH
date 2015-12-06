using System;
using System.Collections.Generic;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
#region not unit-tested
    public class SteamIconCrawler : IPriotizableIconCrawler
    {
        public IEnumerable<ICrawlResult> Crawl( IEnumerable<ICrawlInformation> crawlInfos )
        {
            throw new NotImplementedException();
        }

        public Reliability Realiability { get { return Reliability.High; } }
    }
#endregion
}
