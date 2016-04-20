using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    public class Model : NotifyPropertyChanged
    {
        public Model( IModelParameters @params, 
                      IModelDependencies dependencies )
        {
            this._isInstalled = @params.IsInstalled;
            this._osConfigModelFactory = dependencies.OsConfigurationModelFactory;
            this._programInfoVM = @params.ProgramInfoVM;

            this.Initialize();
        }

        public bool CanConfigBeChanged
        {
            get { return !this.IsLinked; }
        }

        public bool HasSuitableConfig { get { return this._programInfoVM.HasSuitableConfig; } }

        private void Initialize()
        {
            this.InitializePublicProperties();
            this.InitializeOsConfigurationModels();
            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
            this.MoveToCloudCommand = new DelegateCommand( this.MoveToCloudCommand_Execute,
                                                           this.MoveToCloudCommand_CanExecute );
        }

        private void InitializeOsConfigurationModels()
        {
            this._osConfigInfoToOsConfigModelMap = new Dictionary<IOsConfigurationInfo, OsConfiguration.Model>();
            foreach ( var osConfigInfo in this.OsConfigs )
            {
                var modelParameters = new OsConfiguration.ModelParameters
                {
                    ApplicationInfo = this._programInfoVM.ApplicationInfo,
                    IsInstalled = this._isInstalled,
                    OsConfigurationInfo = osConfigInfo
                };
                var model = this._osConfigModelFactory.Get( modelParameters );
                this._osConfigInfoToOsConfigModelMap.Add( osConfigInfo, model );
            }
        }

        private void InitializePublicProperties()
        {
            this.OsConfigs = this._programInfoVM.OsConfigs;
            this.SupportedOSsVM = new SupportedOperatingSystems.ViewModel( this._programInfoVM.OsConfigs );

            if ( this.OsConfigs.Count() != 0 )
            {
                this.SelectedConfiguration = this.OsConfigs.First();
            }
        }

        public bool IsInCloud { get { return this._programInfoVM.IsInCloud; } }

        public bool IsLinked { get { return this._programInfoVM.IsLinked; } }

        // TODO: Finish move to cloud feature
        public ICommand MoveToCloudCommand { get; private set; }
        private bool MoveToCloudCommand_CanExecute()
        {
            return this._isInstalled &&
                this.HasSuitableConfig &&
                !this.IsInCloud;
        }
        private void MoveToCloudCommand_Execute()
        {
            this._programInfoVM.ExecutionLogic.MoveToCloud();
            this.RaisePropertiesChanged();
        }

        public IEnumerable<IOsConfigurationInfo> OsConfigs { get; private set; }

        private void RaisePropertiesChanged()
        {
            this.RaisePropertyChanged( "IsInCloud" );
            this.RaisePropertyChanged( "IsLinked" );
            (this.MoveToCloudCommand as DelegateCommand).RaiseCanExecuteChanged();
            this.RaisePropertyChanged( nameof( this.CanConfigBeChanged ) );
        }

        //  TODO: find best fitting config (done in ExecutionLogic?!)
        private IOsConfigurationInfo _selectedConfiguration;
        public IOsConfigurationInfo SelectedConfiguration
        {
            get { return this._selectedConfiguration; }
            set
            {
                this._selectedConfiguration = value;
                var selectedOsConfigModel = this._osConfigInfoToOsConfigModelMap != null ?
                                            this._osConfigInfoToOsConfigModelMap[value] :
                                            null;
                this.SelectedOsConfigurationModel = selectedOsConfigModel;
            }
        }

        private OsConfiguration.Model _selectedOsConfigurationModel;
        public OsConfiguration.Model SelectedOsConfigurationModel
        {
            get { return this._selectedOsConfigurationModel; }
            set
            {
                this._selectedOsConfigurationModel = value;
                this.RaisePropertyChanged( nameof( this.SelectedOsConfigurationModel ) );
            }
        }

        public SupportedOperatingSystems.ViewModel SupportedOSsVM { get; private set; }

        private bool _isInstalled;
        private IDictionary<IOsConfigurationInfo, OsConfiguration.Model> _osConfigInfoToOsConfigModelMap;
        private IFactory<OsConfiguration.Model, OsConfiguration.IModelParameters> _osConfigModelFactory;
        private ProgramInfoViewModel _programInfoVM;
    }
#endregion
}
