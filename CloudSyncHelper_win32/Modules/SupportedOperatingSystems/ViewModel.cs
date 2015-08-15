using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SupportedOperatingSystems
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( IEnumerable<IOsConfiguration> osConfigs )
        {
            this._osConfigs = osConfigs;
        }

        private bool IsSupported( OsId osId )
        {
            return this._osConfigs.Any( c => c.OsId == osId );
        }

        public bool IsWindows8Supported { get { return this.IsSupported( OsId.Win8 ); } }

        public bool IsWindows81Supported { get { return this.IsSupported( OsId.Win81 ); } }

        public bool IsWindows10Supported { get { return this.IsSupported( OsId.Win10 ); } }

        private IEnumerable<IOsConfiguration> _osConfigs;
    }
#endregion
}
