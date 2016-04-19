using XElement.CloudSyncHelper.Logic;
using XElement.CloudSyncHelper.UI.Win32.Model;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
    public interface IModelDependencies
    {
        IOsChecker OsChecker { get; }

        IFactory<Logic.OsConfiguration, IOsConfigurationParameters> OsConfigurationFactory { get; }
    }
}
