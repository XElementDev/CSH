using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.IconCrawler.MefExtensions
{
    [Export ( typeof( ICrawler ) )]
    internal class LocalIconCrawler :
        global::XElement.CloudSyncHelper.UI.IconCrawler.LocalIconCrawler { }
}
