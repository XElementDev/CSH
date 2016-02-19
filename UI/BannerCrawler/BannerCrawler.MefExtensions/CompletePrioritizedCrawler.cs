using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.BannerCrawler.MefExtensions
{
#region not unit-tested
    //[Export( typeof( IBannerCrawler ) )]
    internal class CompletePrioritizedCrawler : IBannerCrawler
    {
        public ICrawlResult /*IBannerCrawler.*/CrawlSingle( ICrawlInformation crawlInfo )
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS0169
        //  --> crawling will start on import
        [ImportMany( typeof( IPriotizableBannerCrawler ) )]
        private IList<IPriotizableBannerCrawler> _crawlers;
#pragma warning restore CS0169
    }
#endregion
}
