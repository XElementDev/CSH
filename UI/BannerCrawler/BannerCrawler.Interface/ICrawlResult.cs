using System.Drawing;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    public interface ICrawlResult
    {
        Image Image { get; }
        ICrawlInformation Input { get; }
    }
}
