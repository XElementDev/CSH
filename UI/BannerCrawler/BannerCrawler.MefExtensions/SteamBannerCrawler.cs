using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.BannerCrawler.MefExtensions
{
    [Export( typeof ( IPriotizableBannerCrawler ) )]
    internal class SteamBannerCrawler : 
        global::XElement.CloudSyncHelper.UI.BannerCrawler.SteamBannerCrawler, 
        IPriotizableBannerCrawler { }
}
