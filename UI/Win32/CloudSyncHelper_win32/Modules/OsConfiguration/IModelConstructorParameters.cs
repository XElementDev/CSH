using System.Collections.Generic;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
    public interface IModelConstructorParameters
    {
        IEnumerable<ILink> Links { get; }
    }
}
