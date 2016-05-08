﻿using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic;
using XElement.CloudSyncHelper.UI.Win32.DataTypes;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.SemiautomaticSync
{
#region not unit-tested
    public class Model : NotifyPropertyChanged
    {
        public Model( IModelParameters parameters, 
                      IModelDependencies dependencies )
        {
            this.InitializePrivateProperties( parameters, dependencies );
            this.InitializePublicProperties();
            this.InitializeCommands();
            this.RegisterToPropertyChangedEvents();
        }

        public bool CanConfigBeChanged
        {
            get { return !this.IsLinked; }
        }

        public bool HasSuitableConfig { get { return this._programInfoVM.HasSuitableConfig; } }

        private void InitializeCommands()
        {
            this.MoveToCloudCommand = new DelegateCommand( this.MoveToCloudCommand_Execute,
                                                           this.MoveToCloudCommand_CanExecute );
        }

        private void InitializeOsConfigurationModels()
        {
            this.OsConfigInfoToOsConfigModelMap = new Dictionary<IOsConfigurationInfo, OsConfiguration.Model>();
            foreach ( var osConfigInfo in this.OsConfigs )
            {
                var modelParameters = new OsConfiguration.ModelParameters
                {
                    ApplicationInfo = this._programInfoVM.ApplicationInfo,
                    IsInstalled = this._isInstalled,
                    OsConfigurationInfo = osConfigInfo
                };
                var model = this._osConfigModelFactory.Get( modelParameters );
                this.OsConfigInfoToOsConfigModelMap.Add( osConfigInfo, model );
            }
        }

        private void InitializePathMapModels()
        {
            var map = new Dictionary<IOsConfigurationInfo, PathMap.Model>();

            foreach ( var osConfigInfo in this.OsConfigs )
            {
                var osConfigModel = this.OsConfigInfoToOsConfigModelMap[osConfigInfo];
                var @params = new PathMap.ModelParametersDTO
                {
                    Links = osConfigModel.Links
                };
                var pathMapModel = new PathMap.Model( @params );
                map.Add( osConfigInfo, pathMapModel );
            }

            this.OsConfigInfoToPathMapModelMap = map;
        }

        private void InitializePrivateProperties( IModelParameters parameters, 
                                                  IModelDependencies dependencies )
        {
            this._isInstalled = parameters.IsInstalled;
            this._osConfigModelFactory = dependencies.OsConfigurationModelFactory;
            this._programInfoVM = parameters.ProgramInfoVM;

            var definitionParams = new Win32.Model.DefinitionParametersDTO
            {
                ApplicationInfo = this._programInfoVM.ApplicationInfo,
                OsConfigurationInfos = this._programInfoVM.OsConfigs
            };
            this._definition = dependencies.DefinitionFactory.Get( definitionParams );
        }

        private void InitializePublicProperties()
        {
            this.OsConfigs = this._programInfoVM.OsConfigs;
            this.SupportedOSsVM = new SupportedOperatingSystems.ViewModel( this._programInfoVM.OsConfigs );

            if ( this.OsConfigs.Count() != 0 )
            {
                this.SelectedOsConfigurationInfo = this.OsConfigs.First();
            }

            this.InitializeOsConfigurationModels();
            this.InitializePathMapModels();

            this.SelectedOsConfigurationInfo = this._definition.BestFittingOsConfigurationInfo;
        }

        public bool IsInCloud { get { return this._programInfoVM.IsInCloud; } }

        public bool IsLinked { get { return this._definition.IsLinked; } }

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

        public IDictionary<IOsConfigurationInfo, OsConfiguration.Model> OsConfigInfoToOsConfigModelMap
        {
            get;
            private set;
        }

        public IDictionary<IOsConfigurationInfo, PathMap.Model> OsConfigInfoToPathMapModelMap
        {
            get;
            private set;
        }

        public IEnumerable<IOsConfigurationInfo> OsConfigs { get; private set; }

        private void RaisePropertiesChanged()
        {
            this.RaisePropertyChanged( "IsInCloud" );
            this.RaisePropertyChanged( "IsLinked" );
            (this.MoveToCloudCommand as DelegateCommand).RaiseCanExecuteChanged();
            this.RaisePropertyChanged( nameof( this.CanConfigBeChanged ) );
        }

        private void RegisterToPropertyChangedEvent( OsConfiguration.Model osConfigModel )
        {
            osConfigModel.PropertyChanged += ( s, e ) =>
            {
                if ( e.PropertyName == nameof( osConfigModel.IsLinked ) )
                {
                    this.RaisePropertyChanged( nameof( this.IsLinked ) );
                }
            };
        }

        private void RegisterToPropertyChangedEvents()
        {
            var osConfigModels = this.OsConfigInfoToOsConfigModelMap.Values;
            foreach ( var osConfigModel in osConfigModels )
            {
                this.RegisterToPropertyChangedEvent( osConfigModel );
            }

            this.PropertyChanged += ( s, e ) =>
            {
                if ( e.PropertyName == nameof( this.IsLinked ) )
                {
                    this.RaisePropertyChanged( nameof( this.CanConfigBeChanged ) );
                }
            };
        }

        private IOsConfigurationInfo _selectedOsConfigurationInfo;
        public IOsConfigurationInfo SelectedOsConfigurationInfo
        {
            get { return this._selectedOsConfigurationInfo; }
            set
            {
                this._selectedOsConfigurationInfo = value;
                this.RaisePropertyChanged( nameof( this.SelectedOsConfigurationInfo ) );
            }
        }

        public SupportedOperatingSystems.ViewModel SupportedOSsVM { get; private set; }

        private IDefinition _definition;
        private bool _isInstalled;
        private IFactory<OsConfiguration.Model, OsConfiguration.IModelParameters> _osConfigModelFactory;
        private ProgramInfoViewModel _programInfoVM;
    }
#endregion
}
