using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Model
{
#region not unit-tested
    public class DefinitionParametersDTO
    {
        public IApplicationInfo ApplicationInfo { get; set; }

        public IEnumerable<IOsConfigurationInfo> OsConfigurationInfos { get; set; }
    }
#endregion
}
