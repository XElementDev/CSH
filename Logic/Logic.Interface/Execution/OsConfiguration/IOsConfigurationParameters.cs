using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IOsConfigurationParameters
    {
        IApplicationInfo ApplicationInfo { get; }

        IOsConfigurationInfo OsConfigurationInfo { get; }

        IPathVariables PathVariables { get; }
    }
}
