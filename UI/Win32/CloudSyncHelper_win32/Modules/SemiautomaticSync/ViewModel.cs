using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    public class ViewModel
    {
        public ViewModel( /*SemiautomaticSync.*/Model semiautoSyncModel )
        {
            this.Model = semiautoSyncModel;
            this.Initialize();
        }

        private void Initialize()
        {
            this.IsAConfigurationAvailable = this.Model.SupportedOSsVM.IsWindows10Supported ||
                                             this.Model.SupportedOSsVM.IsWindows81Supported ||
                                             this.Model.SupportedOSsVM.IsWindows8Supported ||
                                             this.Model.SupportedOSsVM.IsWindows7Supported;
            this.InitializeOsConfigVMs();
            this.InitializeSelectedConfiguration();
        }

        private void InitializeOsConfigVMs()
        {
            this._osConfigToVmMap = new Dictionary<IOsConfiguration, OsConfigurationViewModel>();
            var osConfigVMs = new List<OsConfigurationViewModel>( this.Model.OsConfigs.Count() );
            foreach ( var osConfig in this.Model.OsConfigs )
            {
                var osConfigVM = new OsConfigurationViewModel( osConfig );
                this._osConfigToVmMap.Add( osConfig, osConfigVM );
                osConfigVMs.Add( osConfigVM );
            }
            this.OsConfigVMs = osConfigVMs;
        }

        private void InitializeSelectedConfiguration()
        {
            if ( this.Model.SelectedConfiguration != null )
            {
                var newRawValue = this.Model.SelectedConfiguration;
                var newVmValue = this._osConfigToVmMap[newRawValue];
                this.SelectedConfiguration = newVmValue;
            }
        }

        public bool IsAConfigurationAvailable { get; private set; }

        public /*SemiautomaticSync.*/Model Model { get; private set; }

        public IEnumerable<OsConfigurationViewModel> OsConfigVMs { get; private set; }

        public OsConfigurationViewModel SelectedConfiguration { get; set; }

        private IDictionary<IOsConfiguration, OsConfigurationViewModel> _osConfigToVmMap;
    }
#endregion
}
