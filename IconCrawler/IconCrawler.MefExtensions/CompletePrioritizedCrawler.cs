using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace XElement.CloudSyncHelper.UI.IconCrawler.MefExtensions
{
#region not unit-tested
    //[Export( typeof( IIconCrawler ) )]
    internal class CompletePrioritizedCrawler : IIconCrawler
    {
        public ICrawlResult /*IIconCrawler.*/CrawlSingle( ICrawlInformation crawlInfo )
        {
            throw new NotImplementedException();
        }

        [ImportMany( typeof( IPriotizableIconCrawler ) )]
        private IList<IPriotizableIconCrawler> _crawlers;
    }
#endregion
}
