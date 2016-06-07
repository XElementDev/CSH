using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.Logic
{
#region not unit-tested
    public class OsFilter : IOsFilter
    {
        public OsFilter( IOsRecognizer osRecognizer )
        {
            this._osRecognizer = osRecognizer;
        }

        public IEnumerable<IOsConfigurationInfo> GetFilteredOsConfigs( IEnumerable<IOsConfigurationInfo> osConfigs )
        {
            var filteredOsConfigs = new List<IOsConfigurationInfo>();
            var osId = this._osRecognizer.GetOsId();

            if ( osId.HasValue )
            {
                filteredOsConfigs = osConfigs.Where( c => c.OsId == osId.Value ).ToList();
            }

            return filteredOsConfigs;
        }

        protected IOsRecognizer _osRecognizer;
    }
#endregion
}
