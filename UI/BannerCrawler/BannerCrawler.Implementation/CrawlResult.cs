using System.Drawing;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
#region not unit-tested
    internal class CrawlResult : ICrawlResult
    {
        public Image Image { get; set; }

        public ICrawlInformation Input { get; set; }
    }
#endregion
}
