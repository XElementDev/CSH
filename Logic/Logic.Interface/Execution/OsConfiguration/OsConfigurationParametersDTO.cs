using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class OsConfigurationParametersDTO
    {
        public IApplicationInfo ApplicationInfo { get; set; }

        public IOsConfigurationInfo OsConfigurationInfo { get; set; }

        public PathVariablesDTO PathVariablesDTO { get; set; }
    }
#endregion
}
