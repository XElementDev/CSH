using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
    public interface IModelParameters
    {
        IApplicationInfo ApplicationInfo { get; }

        bool IsInstalled { get; }

        IOsConfigurationInfo OsConfigurationInfo { get; }
    }
}
