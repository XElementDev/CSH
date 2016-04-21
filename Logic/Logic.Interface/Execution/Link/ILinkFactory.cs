using XElement.CloudSyncHelper.DataTypes;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.Logic
{
    public interface ILinkFactory : IFactory<ILink, LinkParametersDTO>
    {
        ILink Get( IApplicationInfo appInfo, ILinkInfo linkInfo, PathVariablesDTO pathVariables );
    }
}
