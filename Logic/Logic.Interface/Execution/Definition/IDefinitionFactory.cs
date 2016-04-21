using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.Logic
{
    public interface IDefinitionFactory : IFactory<IDefinition, DefinitionParametersDTO>
    {
    }
}
