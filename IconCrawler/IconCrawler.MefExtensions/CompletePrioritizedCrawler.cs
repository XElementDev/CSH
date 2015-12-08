using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.IconCrawler.MefExtensions
{
#region not unit-tested
    //[Export( typeof( IIconCrawler ) )]
    internal class CompletePrioritizedCrawler : IIconCrawler
    {
        public IEnumerable<ICrawlResult> Crawl( IEnumerable<ICrawlInformation> crawlInfos )
        {
            throw new NotImplementedException();
        }

        [ImportMany( typeof( IPriotizableIconCrawler ) )]
        private IList<IPriotizableIconCrawler> _crawlers;
    }
#endregion
}
