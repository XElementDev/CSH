using System.Drawing;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    public interface ICrawlResult
    {
        ICrawlInformation Input { get; }
        Image Image { get; }
    }
}
