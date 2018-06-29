using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.Logic.Execution.MkLink
{
    public interface IFactory : IFactory<IExecutor, ParametersDTO>
    { }
}
