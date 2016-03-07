using System.Collections;
using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
    public interface IModelConstructorParameters
    {
        IEnumerable<IConfiguration> Configurations { get; }
        bool IsInstalled { get; }
        ProgramInfoViewModel ProgramInfoVM { get; }
    }
}
