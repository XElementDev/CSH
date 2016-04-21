using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
    public interface IModelDependencies
    {
        IFactory<IDefinition, Win32.Model.DefinitionParametersDTO> DefinitionFactory { get; }

        IFactory<OsConfiguration.Model, OsConfiguration.IModelParameters> OsConfigurationModelFactory { get; }
    }
}
