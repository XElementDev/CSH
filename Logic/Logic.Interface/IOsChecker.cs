using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IOsChecker
    {
        bool IsSuitableForOs( IOsConfigurationInfo osConfig );
    }
}
