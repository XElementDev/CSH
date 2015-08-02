using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IOsConfiguration
    {
        IReadOnlyList<ILinkInfo> Links { get; }

        OsId OsId { get; set; }
    }
}
