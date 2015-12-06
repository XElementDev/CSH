using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;

namespace XElement.CloudSyncHelper.UI.IconCrawler.MefExtensions
{
    [Export( typeof( IIconCrawler ) )]
    internal class CompletePrioritizedCrawler : IIconCrawler
    {
        public Image Crawl( ICrawlInformation crawlInfo )
        {
            throw new NotImplementedException();
        }

        [ImportMany( typeof( IPriotizableIconCrawler ) )]
        private IList<IPriotizableIconCrawler> _crawlers;
    }
}
