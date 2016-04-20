using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.CloudSyncHelper.Logic
{
    public interface ILinkFactory : IFactory<ILink, ILinkParameters>
    {
    }
}
