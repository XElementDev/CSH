using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class ModelParametersDTO
    {
        IApplicationInfo ApplicationInfo { get; set; }


        bool IsInstalled { get; set; }


        IOsConfigurationInfo OsConfigurationInfo { get; set; }
    }
#endregion
}
