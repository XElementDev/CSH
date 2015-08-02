using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface ISyncData
    {
        IReadOnlyList<IProgramInfo> ProgramInfos { get; }
    }
}
