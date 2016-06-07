using System.Collections.Generic;
using System.Linq;
using XElement.CloudSyncHelper.DataTypes;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    public class ViewModel : NotifyPropertyChanged
    {
        public ViewModel( /*SemiautomaticSync.*/Model semiautoSyncModel )
        {
            this.Model = semiautoSyncModel;

            this.Initialize();
            this.RegisterPropertyChangedEvents();
            this.UpdateSelectedOsConfigurationVM();
            this.UpdateSelectedPathMapVM();
        }

        private void Initialize()
        {
            this.IsAConfigurationAvailable = this.Model.SupportedOSsVM.IsWindows10Supported ||
                                             this.Model.SupportedOSsVM.IsWindows81Supported ||
                                             this.Model.SupportedOSsVM.IsWindows8Supported ||
                                             this.Model.SupportedOSsVM.IsWindows7Supported;
            this.InitializeOsConfigVMs();
            this.InitializeOsConfigAtGlanceVMs();
            this.InitializeSelectedConfiguration();
            this.InitializeSelectedPathMapVm();
        }

        private void InitializeOsConfigAtGlanceVMs()
        {
            var capacity = this.Model.OsConfigs.Count();
            this._osConfigAtGlanceVmToOsConfigMap = 
                new Dictionary<OsConfigurationAtGlance.ViewModel, IOsConfigurationInfo>( capacity );
            this._osConfigToOsConfigAtGlanceVmMap = 
                new Dictionary<IOsConfigurationInfo, OsConfigurationAtGlance.ViewModel>( capacity );
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

        private void InitializeOsConfigVMs()
        {
            var capacity = this.Model.OsConfigs.Count();
            this._osConfigInfoToOsConfigVmMap = 
                new Dictionary<IOsConfigurationInfo, OsConfiguration.ViewModel>( capacity );

            foreach ( var osConfigInfo in this.Model.OsConfigs )
            {
                var model = this.Model.OsConfigInfoToOsConfigModelMap[osConfigInfo];
                var viewModel = new OsConfiguration.ViewModel( model );
                this._osConfigInfoToOsConfigVmMap.Add( osConfigInfo, viewModel );
            }
        }

        private void InitializeSelectedConfiguration()
        {
            if ( this.Model.SelectedOsConfigurationInfo != null )
            {
                var newRawValue = this.Model.SelectedOsConfigurationInfo;
                var newVmValue = this._osConfigToOsConfigAtGlanceVmMap[newRawValue];
                this.SelectedConfigAtGlance = newVmValue;
            }
        }

        private void InitializeSelectedPathMapVm()
        {
            var capacity = this.Model.OsConfigs.Count();
            var map = new Dictionary<IOsConfigurationInfo, PathMap.ViewModel>( capacity );
            foreach ( var osConfigInfo in this.Model.OsConfigs )
            {
                var pathMapModel = this.Model.OsConfigInfoToPathMapModelMap[osConfigInfo];
                var pathMapVM = new PathMap.ViewModel( pathMapModel );
                map.Add( osConfigInfo, pathMapVM );
            }
            this._osConfigInfoToPathMapVmMap = map;
        }

        public bool IsAConfigurationAvailable { get; private set; }

        public /*SemiautomaticSync.*/Model Model { get; private set; }

        public IEnumerable<OsConfigurationAtGlance.ViewModel> OsConfigAtGlanceVMs { get; private set; }

        private void RegisterPropertyChangedEvents()
        {
            this.Model.PropertyChanged += ( s, e ) =>
            {
                if ( e.PropertyName == nameof( this.Model.SelectedOsConfigurationInfo ) )
                {
                    this.UpdateSelectedOsConfigurationVM();
                    this.UpdateSelectedPathMapVM();
                }
            };
        }

        private OsConfigurationAtGlance.ViewModel _selectedConfigAtGlance;
        public OsConfigurationAtGlance.ViewModel SelectedConfigAtGlance
        {
            get { return this._selectedConfigAtGlance; }
            set
            {
                this._selectedConfigAtGlance = value;

                var rawValue = this._osConfigAtGlanceVmToOsConfigMap[this.SelectedConfigAtGlance];
                this.Model.SelectedOsConfigurationInfo = rawValue;
            }
        }

        private OsConfiguration.ViewModel _selectedOsConfigurationVM;
        public OsConfiguration.ViewModel SelectedOsConfigurationVM
        {
            get { return this._selectedOsConfigurationVM; }
            private set
            {
                this._selectedOsConfigurationVM = value;
                this.RaisePropertyChanged( nameof( this.SelectedOsConfigurationVM ) );
            }
        }

        private PathMap.ViewModel _selectedPathMapVM;
        public PathMap.ViewModel SelectedPathMapVM
        {
            get { return this._selectedPathMapVM; }
            set
            {
                this._selectedPathMapVM = value;
                this.RaisePropertyChanged( nameof( this.SelectedPathMapVM ) );
            }
        }

        private void UpdateSelectedOsConfigurationVM()
        {
            var osConfigInfo = this.Model.SelectedOsConfigurationInfo;
            if ( osConfigInfo != null )
            {
                var osConfigVM = this._osConfigInfoToOsConfigVmMap[osConfigInfo];
                this.SelectedOsConfigurationVM = osConfigVM;
            }
        }

        private void UpdateSelectedPathMapVM()
        {
            var osConfigInfo = this.Model.SelectedOsConfigurationInfo;
            if ( osConfigInfo != null )
            {
                var pathMapVM = this._osConfigInfoToPathMapVmMap[osConfigInfo];
                this.SelectedPathMapVM = pathMapVM;
            }
        }

        private IDictionary<OsConfigurationAtGlance.ViewModel, IOsConfigurationInfo> _osConfigAtGlanceVmToOsConfigMap;
        private IDictionary<IOsConfigurationInfo, OsConfiguration.ViewModel> _osConfigInfoToOsConfigVmMap;
        private IDictionary<IOsConfigurationInfo, PathMap.ViewModel> _osConfigInfoToPathMapVmMap;
        private IDictionary<IOsConfigurationInfo, OsConfigurationAtGlance.ViewModel> _osConfigToOsConfigAtGlanceVmMap;
    }
#endregion
}
