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
            this.InitializeOsConfigAtGlanceVMs();
            this.InitializeSelectedConfiguration();
        }

        private void InitializeOsConfigAtGlanceVMs()
        {
            var capacity = this.Model.OsConfigs.Count();
            this._osConfigAtGlanceVmToOsConfigMap = 
                new Dictionary<OsConfigurationAtGlance.ViewModel, IOsConfiguration>( capacity );
            this._osConfigToOsConfigAtGlanceVmMap = 
                new Dictionary<IOsConfiguration, OsConfigurationAtGlance.ViewModel>( capacity );
            var osConfigAtGlanceVMs = new List<OsConfigurationAtGlance.ViewModel>( capacity );

            foreach ( var osConfig in this.Model.OsConfigs )
            {
                var osConfigAtGlanceModel = new OsConfigurationAtGlance.Model( osConfig );
                var osConfigAtGlanceVM = new OsConfigurationAtGlance.ViewModel( osConfigAtGlanceModel );
                osConfigAtGlanceVMs.Add( osConfigAtGlanceVM );
                this._osConfigToOsConfigAtGlanceVmMap.Add( osConfig, osConfigAtGlanceVM );
                this._osConfigAtGlanceVmToOsConfigMap.Add( osConfigAtGlanceVM, osConfig );
            }

            this.OsConfigAtGlanceVMs = osConfigAtGlanceVMs;
        }

        private void InitializeSelectedConfiguration()
        {
            if ( this.Model.SelectedConfiguration != null )
            {
                var newRawValue = this.Model.SelectedConfiguration;
                var newVmValue = this._osConfigToOsConfigAtGlanceVmMap[newRawValue];
                this.SelectedConfigAtGlance = newVmValue;
            }
        }

        public bool IsAConfigurationAvailable { get; private set; }

        public /*SemiautomaticSync.*/Model Model { get; private set; }

        public IEnumerable<OsConfigurationAtGlance.ViewModel> OsConfigAtGlanceVMs { get; private set; }

        private OsConfigurationAtGlance.ViewModel _selectedConfigAtGlance;
        public OsConfigurationAtGlance.ViewModel SelectedConfigAtGlance
        {
            get { return this._selectedConfigAtGlance; }
            set
            {
                this._selectedConfigAtGlance = value;

                var rawValue = this._osConfigAtGlanceVmToOsConfigMap[this.SelectedConfigAtGlance];
                this.Model.SelectedConfiguration = rawValue;
            }
        }

        //{
        //    {
        //    }
        //}

        private IDictionary<OsConfigurationAtGlance.ViewModel, IOsConfiguration> _osConfigAtGlanceVmToOsConfigMap;
        private IDictionary<IOsConfiguration, OsConfigurationAtGlance.ViewModel> _osConfigToOsConfigAtGlanceVmMap;
    }
#endregion
}
