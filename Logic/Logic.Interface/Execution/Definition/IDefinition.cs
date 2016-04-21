using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IDefinition
    {
        IOsConfigurationInfo BestFittingOsConfiguration { get; }
    }
}
