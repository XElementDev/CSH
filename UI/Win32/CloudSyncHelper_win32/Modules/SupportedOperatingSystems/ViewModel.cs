using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using XElement.DotNet.System.Environment;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SupportedOperatingSystems
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( IEnumerable<IOsConfigurationInfo> osConfigs )
        {
            this._osConfigs = osConfigs;
        }

        private bool IsSupported( OsId osId )
        {
            return this._osConfigs.Any( c => c.OsId == osId );
        }

        public bool IsWindows7Supported { get { return this.IsSupported( OsId.Win7 ); } }

        public bool IsWindows8Supported { get { return this.IsSupported( OsId.Win8 ); } }

        public bool IsWindows81Supported { get { return this.IsSupported( OsId.Win81 ); } }

        public bool IsWindows10Supported { get { return this.IsSupported( OsId.Win10 ); } }

        private IEnumerable<IOsConfigurationInfo> _osConfigs;
    }
#endregion
}
