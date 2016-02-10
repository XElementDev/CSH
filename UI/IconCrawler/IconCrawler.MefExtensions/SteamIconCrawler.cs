using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.IconCrawler.MefExtensions
{
    [Export( typeof ( IPriotizableIconCrawler ) )]
    internal class SteamIconCrawler : 
        global::XElement.CloudSyncHelper.UI.IconCrawler.SteamBannerCrawler, 
        IPriotizableIconCrawler { }
}
