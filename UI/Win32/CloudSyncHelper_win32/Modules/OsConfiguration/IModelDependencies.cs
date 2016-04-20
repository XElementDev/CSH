using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
    public interface IModelDependencies
    {
        IOsChecker OsChecker { get; }

        IFactory<Logic.IOsConfiguration, Win32.Model.IOsConfigurationParameters> OsConfigurationFactory { get; }
    }
}
