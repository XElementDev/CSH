using XElement.CloudSyncHelper.DataTypes;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IOsConfigurationFactory : IFactory<IOsConfiguration, 
                                                        OsConfigurationParametersDTO>
    {
        IOsConfiguration Get( IApplicationInfo appInfo, 
                              IOsConfigurationInfo osConfigInfo,
                              PathVariablesDTO pathVariables );
    }
}
