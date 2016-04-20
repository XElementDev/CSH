using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
    public interface IModelDependencies
    {
        IFactory<OsConfiguration.Model, OsConfiguration.IModelParameters> OsConfigurationModelFactory { get; }
    }
}
