using System.Drawing;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    public interface ICrawlResult
    {
        Icon Icon { get; }
        ICrawlInformation Input { get; }
    }
}
