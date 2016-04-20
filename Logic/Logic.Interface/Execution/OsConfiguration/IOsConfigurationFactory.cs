using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IOsConfigurationFactory : IFactory<IOsConfiguration, 
                                                        IOsConfigurationParameters>
    {
    }
}
