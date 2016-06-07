using System.Collections.Generic;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class DefinitionParametersDTO
    {
        public IApplicationInfo ApplicationInfo { get; set; }

        public IEnumerable<IOsConfigurationInfo> OsConfigurationInfos { get; set; }

        public PathVariablesDTO PathVariablesDTO { get; set; }
    }
#endregion
}
