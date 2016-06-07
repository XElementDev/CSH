using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
    public interface IOsConfigurationParameters
    {
        IApplicationInfo ApplicationInfo { get; }

        IOsConfigurationInfo OsConfigurationInfo { get; }
    }
}
