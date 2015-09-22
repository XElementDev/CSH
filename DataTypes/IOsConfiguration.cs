using System.Collections.Generic;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IOsConfiguration
    {
        IReadOnlyList<ILinkInfo> Links { get; }

        OsId OsId { get; set; }
    }
}
