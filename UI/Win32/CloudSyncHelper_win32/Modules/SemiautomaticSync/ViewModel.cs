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
            this._osConfigToOsConfigVmMap = new Dictionary<IOsConfiguration, OsConfigurationAtGlance.ViewModel>();
            this._osConfigVmToOsConfigMap = new Dictionary<OsConfigurationAtGlance.ViewModel, IOsConfiguration>();
            var osConfigAtGlanceVMs = new List<OsConfigurationAtGlance.ViewModel>( this.Model.OsConfigs.Count() );
            foreach ( var osConfig in this.Model.OsConfigs )
            {
                var osConfigAtGlanceModel = new OsConfigurationAtGlance.Model( osConfig );
                var osConfigAtGlanceVM = new OsConfigurationAtGlance.ViewModel( osConfigAtGlanceModel );
                this._osConfigToOsConfigVmMap.Add( osConfig, osConfigAtGlanceVM );
                this._osConfigVmToOsConfigMap.Add( osConfigAtGlanceVM, osConfig );
                osConfigAtGlanceVMs.Add( osConfigAtGlanceVM );
            }
            this.OsConfigAtGlanceVMs = osConfigAtGlanceVMs;
        }

        private void InitializeSelectedConfiguration()
        {
            //if ( this.Model.SelectedConfiguration != null )
            //{
            //    var newRawValue = this.Model.SelectedConfiguration;
            //    var newVmValue = this._osConfigToOsConfigVmMap[newRawValue];
            //    this.SelectedConfiguration = newVmValue;
            //}
        }

        public bool IsAConfigurationAvailable { get; private set; }

        public /*SemiautomaticSync.*/Model Model { get; private set; }

        public IEnumerable<OsConfigurationAtGlance.ViewModel> OsConfigAtGlanceVMs { get; private set; }

        //private OsConfigurationViewModel _selectedConfiguration;
        //public OsConfigurationViewModel SelectedConfiguration
        //{
        //    get { return this._selectedConfiguration; }
        //    set
        //    {
        //        this._selectedConfiguration = value;
        //        var rawValue = this._osConfigVmToOsConfigMap[this.SelectedConfiguration];
        //        this.Model.SelectedConfiguration = rawValue;
        //    }
        //}

        //public OsConfiguration.ViewModel

        private IDictionary<IOsConfiguration, OsConfigurationAtGlance.ViewModel> _osConfigToOsConfigVmMap;
        private IDictionary<OsConfigurationAtGlance.ViewModel, IOsConfiguration> _osConfigVmToOsConfigMap;
    }
#endregion
}
