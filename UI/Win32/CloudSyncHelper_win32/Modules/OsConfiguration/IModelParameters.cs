using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
    public interface IModelParameters
    {
        bool IsInstalled { get; }

        IOsConfigurationInfo OsConfiguration { get; }
    }
}
