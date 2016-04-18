using XElement.CloudSyncHelper.Logic;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
    public interface IModelDependencies
    {
        IOsChecker OsChecker { get; }
    }
}
