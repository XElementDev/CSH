﻿namespace XElement.CloudSyncHelper.UI.IconCrawler
{
    public interface IPriotizableIconCrawler : IIconCrawler
    {
        Reliability Reliability { get; }
    }
}
