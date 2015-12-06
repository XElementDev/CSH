using System;
using System.Drawing;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
#region not unit-tested
    public class SteamIconCrawler : IPriotizableIconCrawler
    {
        public Image Crawl( ICrawlInformation crawlInfo )
        {
            throw new NotImplementedException();
        }

        public Reliability Realiability { get { return Reliability.High; } }
    }
#endregion
}
