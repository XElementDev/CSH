using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class ModelParametersDTO
    {
        public IApplicationInfo ApplicationInfo { get; set; }


        public bool IsInstalled { get; set; }


        public IOsConfigurationInfo OsConfigurationInfo { get; set; }
    }
#endregion
}
