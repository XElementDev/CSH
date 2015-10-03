using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper
{
    [Export]
    public class ConfigForOsHelper
    {
        public IReadOnlyList<ILinkInfo> GetSuitableConfig( IReadOnlyList<IOsConfiguration> osConfigs )
        {
            IReadOnlyList<ILinkInfo> suitableConfig = new List<ILinkInfo>();
            var osId = this._osRecognizer.GetOsId();

            if ( osId.HasValue )
            {
                var osConfig = osConfigs.SingleOrDefault( c => c.OsId == osId.Value );
                if ( osConfig != null )
                {
                    suitableConfig = osConfig.Links;
                }
            }

            return suitableConfig;
        }

        [Import]
        private IOsRecognizer _osRecognizer = null;
    }
}
