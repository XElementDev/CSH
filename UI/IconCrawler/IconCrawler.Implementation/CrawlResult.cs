﻿using System.Drawing;

namespace XElement.CloudSyncHelper.UI.IconCrawler
{
#region not unit-tested
    internal class CrawlResult : ICrawlResult
    {
        public Icon Icon { get; set; }

        public ICrawlInformation Input { get; set; }
    }
#endregion
}
