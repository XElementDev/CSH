using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper
{
#region not unit-tested
    public class OsFilter : IOsFilter
    {
        public OsFilter( IOsRecognizer osRecognizer )
        {
            this._osRecognizer = osRecognizer;
        }

        public IEnumerable<IOsConfiguration> GetFilteredOsConfigs( IEnumerable<IOsConfiguration> osConfigs )
        {
            var filteredOsConfigs = new List<IOsConfiguration>();
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
