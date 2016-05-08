using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IDefinition
    {
        IOsConfigurationInfo BestFittingOsConfigurationInfo { get; }

        bool IsLinked { get; }
    }
}
