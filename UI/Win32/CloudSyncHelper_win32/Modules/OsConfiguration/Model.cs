using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;
using XElement.CloudSyncHelper.DataTypes;
using XElement.CloudSyncHelper.Logic;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using NotifyPropertyChanged = XElement.Common.UI.ViewModelBase;

namespace XElement.CloudSyncHelper.UI.Win32.Modules.OsConfiguration
{
#region not unit-tested
    public class Model : NotifyPropertyChanged
    {
        public Model( ModelParametersDTO parameters, 
                      ModelDependenciesDTO dependencies )
        {
            this.Initialize( parameters, dependencies );

            this.UpdateCachedProperties();
        }

        private void Initialize( ModelParametersDTO @params, ModelDependenciesDTO dependencies )
        {
            this.InitializeCommands();
            this.InitializePrivateProperties( @params, dependencies );
            this.InitializePublicProperties( @params );
        }

        private void InitializeCommands()
        {
            this.LinkCommand = new DelegateCommand( this.LinkCommand_Execute, 
                                                    this.LinkCommand_CanExecute );
            this.MoveToCloudCommand = new DelegateCommand( this.MoveToCloudCommand_Execute, 
                                                           this.MoveToCloudCommand_CanExecute );
            this.UnlinkCommand = new DelegateCommand( this.UnlinkCommand_Execute, 
                                                      this.UnlinkCommand_CanExecute );
        }

        private void InitializePrivateProperties( ModelParametersDTO @params, ModelDependenciesDTO dependencies )
        {
            this._linkFactory = dependencies.LinkFactory;
            this._osChecker = dependencies.OsChecker;

            var factoryParam = new OsConfigurationParameters
            {
                ApplicationInfo = @params.ApplicationInfo,
                OsConfigurationInfo = @params.OsConfigurationInfo
            };
            this._osConfiguration = dependencies.OsConfigurationFactory.Get( factoryParam );

            this._osConfigurationInfo = @params.OsConfigurationInfo;
        }

        private void InitializePublicProperties( ModelParametersDTO @params )
        {
            this.IsInstalled = @params.IsInstalled;

            var links = new List<ILink>();
            foreach ( var linkInfo in this._osConfigurationInfo.Links )
            {
                var paramsDTO = new Win32.Model.LinkParametersDTO
                {
                    ApplicationInfo = @params.ApplicationInfo, 
                    LinkInfo = linkInfo
                };
                var link = this._linkFactory.Get( paramsDTO );
                links.Add( link );
            }
            this.Links = links;
        }

        private bool IsInCloud { get; set; }

        private bool IsInstalled { get; set; }

        private bool _isLinked;
        public bool IsLinked
        {
            get { return this._isLinked; }
            set
            {
                this._isLinked = value;
                this.RaisePropertyChanged( nameof( this.IsLinked ) );
            }
        }

        private bool IsSuitableForOs { get; set; }

        public ICommand LinkCommand { get; private set; }
        private bool LinkCommand_CanExecute()
        {
            return this.IsInstalled && 
                this.IsSuitableForOs && 
                this.IsInCloud && 
                !this.IsLinked;
        }
        private void LinkCommand_Execute()
        {
            this._osConfiguration.Do();
            this.UpdateCachedProperties();
            this.RaisePropertiesChanged();
        }

        public IEnumerable<ILink> Links { get; private set; }

        //  TODO: Copy cloud files to local
        public ICommand UnlinkCommand { get; private set; }
        private bool UnlinkCommand_CanExecute()
        {
            return this.IsSuitableForOs && 
                this.IsLinked;
        }
        private void UnlinkCommand_Execute()
        {
            this._osConfiguration.Undo();
            this.UpdateCachedProperties();
            this.RaisePropertiesChanged();
        }

        private void UpdateCachedProperties()
        {
            this.IsInCloud = this._osConfiguration.IsInCloud;
            this.IsLinked = this._osConfiguration.IsLinked;
            this.IsSuitableForOs = this._osChecker.IsSuitableForOs( this._osConfigurationInfo );
        }

        private void RaisePropertiesChanged()
        {
            (this.LinkCommand as DelegateCommand).RaiseCanExecuteChanged();
            (this.UnlinkCommand as DelegateCommand).RaiseCanExecuteChanged();
        }

        private IFactory<ILink, Win32.Model.LinkParametersDTO> _linkFactory;
        private IOsChecker _osChecker;
        private IOsConfiguration _osConfiguration;
        private IOsConfigurationInfo _osConfigurationInfo;


        private class OsConfigurationParameters : Win32.Model.IOsConfigurationParameters
        {
            public IApplicationInfo ApplicationInfo { get; set; }

            public IOsConfigurationInfo OsConfigurationInfo { get; set; }
        }
#endregion


        public ICommand MoveToCloudCommand { get; private set; }

        private bool MoveToCloudCommand_CanExecute()
        {
            return this.IsInstalled &&
                this.IsSuitableForOs &&
                !this.IsInCloud;
        }

        private void MoveToCloudCommand_Execute()
        {
            this._osConfiguration.MoveToCloud();
            (this.LinkCommand as DelegateCommand).RaiseCanExecuteChanged();
            (this.MoveToCloudCommand as DelegateCommand).RaiseCanExecuteChanged();
        }
    }
}
