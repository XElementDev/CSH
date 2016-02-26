using System.Collections.Generic;

namespace XElement.CloudSyncHelper.DataTypes
{
    public interface IDefinition
    {
        IEnumerable<IConfiguration> Configurations { get; }

        bool SupportsSteamCloud { get; }
    }
}
