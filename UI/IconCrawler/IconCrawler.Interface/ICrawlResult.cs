using System.Drawing;

namespace XElement.CloudSyncHelper.UI.BannerCrawler
{
    public interface ICrawlResult
    {
        ICrawlInformation Input { get; }
        Image Image { get; }
    }
}
