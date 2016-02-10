using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.BannerCrawler.MefExtensions
{
    [Export( typeof ( IPriotizableIconCrawler ) )]
    internal class SteamIconCrawler : 
        global::XElement.CloudSyncHelper.UI.BannerCrawler.SteamBannerCrawler, 
        IPriotizableIconCrawler { }
}
