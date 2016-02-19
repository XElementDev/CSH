using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface ISyncData
    {
        IReadOnlyList<IApplicationInfo> ApplicationInfos { get; }
    }
}
